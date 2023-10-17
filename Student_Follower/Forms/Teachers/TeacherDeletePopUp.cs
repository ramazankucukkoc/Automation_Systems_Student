using Student_Follower.Entities;
using Student_Follower.Entities.Teachers;
using Student_Follower.Services;
using System;
using System.Windows.Forms;

namespace Student_Follower.Forms.Teachers
{
    public partial class TeacherDeletePopUp : Form
    {
        private readonly TeacherApiService _service;

        public string TCNo, LastName, FirstName, PhoneNo, Email;



        public DateTime BirhtDay;
        public TeacherDeletePopUp(DateTime birhtDay, string tcNo, string firstName, string lastName, string phoneNo, string email)
        {
            TCNo = tcNo;
            FirstName = firstName;
            LastName = lastName;
            PhoneNo = phoneNo;
            Email = email;
            BirhtDay = birhtDay;
            BirhtDay = birhtDay;
            InitializeComponent();
            _service = new TeacherApiService();
        }
        private void TeacherDeletePopUp_Load(object sender, EventArgs e)
        {
            this.Text = FirstName + " " + LastName;
            button1.Text = FirstName + " " + LastName + " Sil";

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox1.Text = TCNo;
            textBox2.Text = FirstName;
            textBox3.Text = LastName;
            textBox4.Text = PhoneNo;
            textBox5.Text = Email;
            dateTimePicker1.Value = BirhtDay;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            DeleteTeacher deleteTeacher = new DeleteTeacher();
            deleteTeacher.TCNo = textBox1.Text;

            ResponseStatusCode responseStatusCode = await _service.Response(deleteTeacher, "Delete" + $"/{TCNo}");
            if (responseStatusCode.StatusCode == 200)
            {
                MessageBox.Show($"{FirstName} {LastName} isimli personel başarılı silindi...", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                TeacherList teacherList = new TeacherList();
                teacherList.Show();
            }
            else
            {
                GenericApiService.ErrorService(responseStatusCode);
            }
            this.Hide();
        }
    }
}
