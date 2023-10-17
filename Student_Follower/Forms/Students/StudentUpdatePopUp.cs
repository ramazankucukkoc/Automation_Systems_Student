using Student_Follower.Entities;
using Student_Follower.Services;
using System;
using System.Windows.Forms;

namespace Student_Follower
{
    public partial class StudentUpdatePopUp : Form
    {
        private readonly StudentApiService _studentApiService;

        public string TCNo, LastName, FirstName, PhoneNo, Email;
        public DateTime BirhtDay; public StudentUpdatePopUp(DateTime birhtDay, string tcNo, string firstName, string lastName, string phoneNo, string email)
        {
            TCNo = tcNo;
            FirstName = firstName;
            LastName = lastName;
            PhoneNo = phoneNo;
            Email = email;
            BirhtDay = birhtDay;
            BirhtDay = birhtDay;
            InitializeComponent();
            _studentApiService = new StudentApiService();
        }
        private void StudentUpdate_Load(object sender, EventArgs e)
        {
            this.Text = FirstName + " " + LastName;
            button1.Text = FirstName + " " + LastName + " Güncelle";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            maskedTextBox2.Enabled = false;
            maskedTextBox2.Text = TCNo;
            textBox2.Text = FirstName;
            textBox3.Text = LastName;
            maskedTextBox1.Text = PhoneNo;
            textBox5.Text = Email;
            dateTimePicker1.Value = BirhtDay;

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            UpdateStudent studentUpdate = new UpdateStudent();
            studentUpdate.TCNo = maskedTextBox2.Text;
            studentUpdate.FirstName = textBox2.Text;
            studentUpdate.LastName = textBox3.Text;
            studentUpdate.PhoneNo = maskedTextBox1.Text;
            studentUpdate.Email = textBox5.Text;
            studentUpdate.BirthDay = dateTimePicker1.Value;

            ResponseStatusCode responseStatusCode = await _studentApiService.Response(studentUpdate, "Update");
            if (responseStatusCode.StatusCode == 200)
            {
                MessageBox.Show($"{FirstName} {LastName} isimli ögrenci başarılı güncellendi...", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                StudentList studentList = new StudentList();
                studentList.Show();
            }
            else
                GenericApiService.ErrorService(responseStatusCode);

            this.Hide();
        }
    }
}
