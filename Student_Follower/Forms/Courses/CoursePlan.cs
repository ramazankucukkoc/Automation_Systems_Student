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
    public partial class CoursePlan : Form
    {
        private readonly CoursesApiService _courseApiService;
        private readonly TeacherApiService _teacherApiService;
        private readonly StudentCoursesApiService _studentCoursesApiService;
        private string FormName;
        private int saatIndex;
        private int gunIndex;
        private int courseId;

        public CoursePlan(string formName)
        {
            FormName = formName;
            InitializeComponent();
            _studentCoursesApiService = new StudentCoursesApiService();
            _teacherApiService = new TeacherApiService();
            _courseApiService = new CoursesApiService();
        }

        public CoursePlan()
        {
            _studentCoursesApiService = new StudentCoursesApiService();
            _teacherApiService = new TeacherApiService();
            _courseApiService = new CoursesApiService();
            InitializeComponent();
        }
        private void CoursePlan_Load(object sender, EventArgs e)
        {
            this.Text = "DERS PLANLAMA İŞLEMLERİ";
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            GetAllCourses();
            Gunler();
            Hours();
            CoursesPlan();
        }
        private async Task CoursesPlan()
        {
            ResponseStatusCode responseStatusCode = await _courseApiService.GetResponse("GetById");
            if (responseStatusCode.StatusCode == 200)
            {
                List<CourseDayHourAddlList> datalist = GenericApiService.SuccessListService<CourseDayHourAddlList>(responseStatusCode);
                foreach (var item in datalist)
                {
                    item.HourId--;
                    for (int i = 0; i < datalist.Count; i++)
                        dataGridView1.Rows[item.HourId].Cells[item.DayId].Value = item.CourseName;
                }
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
                comboBox2.Items.AddRange(datalist.Select(x => x.Id + "-" + x.Name).ToArray());
            }
            else
                GenericApiService.ErrorService(responseStatusCode);

        }
        private void Hours()
        {
            string[] sabahcılar = { "08:00-08:40", "09:00-09:40", "10:00-10:40", "11:00-11:40", "Ögle-Arası", "13:00-13:40", "14:00-14:40", "15:00-15:40", "16:00-16:40" };
            comboBox3.Items.AddRange(sabahcılar);

            for (int i = 0; i < sabahcılar.Length; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["Çalışma Saatleri"].Value = sabahcılar[i];

            }
        }
        private void Gunler()
        {
            string[] gunler = { "1-Pazartesi", "2-Salı", "3-Çarşamba", "4-Perşembe", "5-Cuma" };
            comboBox4.Items.AddRange(gunler);
            string[] days = { "Çalışma Saatleri", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" };

            foreach (var day in days)
                dataGridView1.Columns.Add(day, day);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string input = comboBox2.Text;
            int dashIndex = input.IndexOf('-');
            string result = input.Substring(dashIndex + 1);
            saatIndex = comboBox3.SelectedIndex;
            gunIndex = comboBox4.SelectedIndex + 1;
            dataGridView1.Rows[saatIndex].Cells[gunIndex].Value = result;

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string courseId = comboBox2.SelectedItem.ToString();
            int indeks2 = courseId.IndexOf('-');
            string alinanCourseId = courseId.Substring(0, indeks2).Trim();

            CourseDayHourAdd courseDayHourAdd = new CourseDayHourAdd();
            courseDayHourAdd.HourId = saatIndex;
            saatIndex++;
            courseDayHourAdd.CourseId = int.Parse(alinanCourseId);
            courseDayHourAdd.DayId = gunIndex;


            ResponseStatusCode responseStatusCode = await _courseApiService.Response(courseDayHourAdd, "Add");
            if (responseStatusCode.StatusCode == 200)
            {
                MessageBox.Show($"Ders Programı Eklendi.", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CoursesPlan();
            }
            else
                GenericApiService.ErrorService(responseStatusCode);
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
