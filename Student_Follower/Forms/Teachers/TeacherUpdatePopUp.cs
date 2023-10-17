using Student_Follower.Entities;
using Student_Follower.Entities.Teachers;
using Student_Follower.Services;
using System;
using System.Windows.Forms;

namespace Student_Follower.Forms.Teachers
{
    public partial class TeacherUpdatePopUp : Form
    {
        private readonly TeacherApiService _service;
        public string TCNo, LastName, FirstName, PhoneNo, Email;
        public DateTime BirhtDay;

        public TeacherUpdatePopUp(DateTime birhtDay, string tcNo, string firstName, string lastName, string phoneNo, string email)
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

        private void TeacherUpdatePopUp_Load(object sender, EventArgs e)
        {
            this.Text = FirstName + " " + LastName;
            button1.Text = FirstName + " " + LastName + " Güncelle";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            maskedTextBox2.Text = TCNo;
            maskedTextBox2.Enabled = true;
            textBox2.Text = FirstName;
            textBox3.Text = LastName;
            maskedTextBox1.Text = PhoneNo;
            textBox5.Text = Email;
            dateTimePicker1.Value = BirhtDay;

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            UpdateTeacher updateTeacher = new UpdateTeacher();
            updateTeacher.TCNo = maskedTextBox2.Text;
            updateTeacher.FirstName = textBox2.Text;
            updateTeacher.LastName = textBox3.Text;
            updateTeacher.PhoneNo = maskedTextBox1.Text;
            updateTeacher.Email = textBox5.Text;
            updateTeacher.BirthDay = dateTimePicker1.Value;

            ResponseStatusCode responseStatusCode = await _service.Response(updateTeacher, "Update");
            if (responseStatusCode.StatusCode == 200)
            {
                MessageBox.Show($"{FirstName} {LastName} isimli personel başarılı güncellendi...", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
