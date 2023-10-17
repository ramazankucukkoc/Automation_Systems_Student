using Newtonsoft.Json;
using Student_Follower.Entities;
using Student_Follower.Entities.Courses;
using Student_Follower.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Follower.Forms.Courses
{
    public partial class CoursesNotes : Form
    {
        private readonly CoursesApiService _courseApiService;
        private readonly StudentApiService _studentApiService;
        private readonly StudentCoursesApiService _studentCoursesApiService;
        private string FormName;
        public CoursesNotes(string formName)
        {
            FormName = formName;
            InitializeComponent();
            _studentCoursesApiService = new StudentCoursesApiService();
            _studentApiService = new StudentApiService();
            _courseApiService = new CoursesApiService();
        }

        public CoursesNotes()
        {
            _studentCoursesApiService = new StudentCoursesApiService();
            _studentApiService = new StudentApiService();
            _courseApiService = new CoursesApiService();
            InitializeComponent();
        }
        int studentId = 0;
        int courseId = 0;
        private void CoursesNotes_Load(object sender, EventArgs e)
        {
            this.Text = "NOT İŞLEMLERİ";
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            GetAllStudents();
            GetAllCourses();
            GetAllStudentCourses();
        }
        private async Task GetAllStudents()
        {
            ResponseStatusCode responseStatusCode = await _studentApiService.GetResponse("GetAll");
            if (responseStatusCode.StatusCode == 200)
            {

                List<ListStudent> datalist = GenericApiService.SuccessListService<ListStudent>(responseStatusCode);
                comboBox2.Items.AddRange(datalist.Select(x => x.Id + "-" + x.FirstName + " " + x.LastName).ToArray());

            }
            else
                GenericApiService.ErrorService(responseStatusCode);
        }
        private async Task GetAllCourses()
        {
            ResponseStatusCode responseStatusCode = await _courseApiService.GetResponse("GetAllCourse");
            if (responseStatusCode.StatusCode == 200)
            {
                List<CourseList> datalist = JsonConvert.DeserializeObject<List<CourseList>>(responseStatusCode.Content);
                comboBox3.Items.AddRange(datalist.Select(x => x.Id + "-" + x.Name).ToArray());
            }
            else
                GenericApiService.ErrorService(responseStatusCode);

        }
        private async Task GetAllStudentCourses()
        {

            ResponseStatusCode responseStatusCode = await _courseApiService.GetResponse("GetAll");
            if (responseStatusCode.StatusCode == 200)
            {

                dataGridView1.DataSource = GenericApiService.SuccessListService<CourseStudentList>(responseStatusCode);
                dataGridView1.Columns["StudentId"].Visible = false;
                dataGridView1.Columns["CourseId"].Visible = false;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            else
                GenericApiService.ErrorService(responseStatusCode);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (FormName == "PersonelIslemleri")
            {
                this.Close();
                PersonelIslemleri personel = new PersonelIslemleri();
                personel.Show();
            }
            else
            {
                this.Close();
                Ogrenciİslemeleri form = new Ogrenciİslemeleri();
                form.Show();
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                studentId = Convert.ToInt32(selectedRow.Cells["StudentId"].Value);
                courseId = Convert.ToInt32(selectedRow.Cells["CourseId"].Value);
                var studentName = selectedRow.Cells["StudentName"].Value;
                var courseName = selectedRow.Cells["CourseName"].Value;
                var note1 = selectedRow.Cells["Note1"].Value;
                var note2 = selectedRow.Cells["Note2"].Value;
                var average = selectedRow.Cells["Average"].Value;
                var status = selectedRow.Cells["Status"].Value;

                comboBox2.Text = studentName.ToString();
                comboBox3.Text = courseName.ToString();
                numericUpDown1.Value = Convert.ToDecimal(note1.ToString());
                numericUpDown2.Value = Convert.ToDecimal(note2.ToString());
                textBox3.Text = average.ToString();
                textBox2.Text = status.ToString();
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                textBox2.Enabled = false;

            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            double sonuc = (((double)numericUpDown1.Value + (double)numericUpDown2.Value) / 2);
            textBox3.Text = sonuc.ToString();
            if (sonuc >= 50 && sonuc <= 100)
                textBox2.Text = "Geçti";
            else
                textBox2.Text = "Kaldı";

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            CourseStudentAdd courseAdd = new CourseStudentAdd();
            courseAdd.Note1 = (double)numericUpDown1.Value;
            courseAdd.Note2 = (double)numericUpDown2.Value;

            string studentId = comboBox2.SelectedItem.ToString();
            string courseId = comboBox3.SelectedItem.ToString();
            int indeks1 = studentId.IndexOf('-');
            int indeks2 = courseId.IndexOf('-');
            string alinanVeriStudentId = studentId.Substring(0, indeks1).Trim();
            string alinanCourseId = courseId.Substring(0, indeks2).Trim();
            courseAdd.StudentId = int.Parse(alinanVeriStudentId);
            courseAdd.CourseId = int.Parse(alinanCourseId);

            ResponseStatusCode responseStatusCode = await _studentCoursesApiService.Response(courseAdd, "Add");
            if (responseStatusCode.StatusCode == 200)
                MessageBox.Show($"{comboBox2.Text} isimli ögrenci başarılı şekilde notu eklendi....", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                GenericApiService.ErrorService(responseStatusCode);
            GetAllStudentCourses();
        }

        private async void button4_Click(object sender, EventArgs e)
        {

            CourseUpdate courseUpdate = new CourseUpdate();
            courseUpdate.StudentId = studentId;
            courseUpdate.CourseId = courseId;
            courseUpdate.Note1 = (double)numericUpDown1.Value;
            courseUpdate.Note2 = (double)numericUpDown2.Value;

            ResponseStatusCode responseStatusCode = await _studentCoursesApiService.Response(courseUpdate, "Update");
            if (responseStatusCode.StatusCode == 200)
                MessageBox.Show($"{comboBox2.Text} isimli ögrenci başarılı şekilde notu güncellendi....", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                GenericApiService.ErrorService(responseStatusCode);

            GetAllStudentCourses();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            CourseDelete courseDelete = new CourseDelete();
            courseDelete.CourseName = comboBox3.Text;
            ResponseStatusCode responseStatusCode = await _studentCoursesApiService.Response(courseDelete, $"Delete/{comboBox3.Text}");

            if (responseStatusCode.StatusCode == 200)
                MessageBox.Show($"{comboBox2.Text} isimli ögrenci başarılı şekilde silindi....", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                GenericApiService.ErrorService(responseStatusCode);

            GetAllStudentCourses();

        }
    }
}
