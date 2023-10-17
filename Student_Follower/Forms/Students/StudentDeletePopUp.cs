using Student_Follower.Entities;
using Student_Follower.Services;
using System;
using System.Windows.Forms;

namespace Student_Follower
{
    public partial class StudentDeletePopUp : Form
    {
        private readonly StudentApiService _studentApiService;

        public string TCNo, LastName, FirstName, PhoneNo, Email;
        public DateTime BirhtDay;

        public StudentDeletePopUp(DateTime birhtDay, string tcNo, string firstName, string lastName, string phoneNo, string email)
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


        private void StudentDeletePopUp_Load(object sender, EventArgs e)
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

            DeleteStudent studentDelete = new DeleteStudent();
            studentDelete.TCNo = textBox1.Text;

            ResponseStatusCode responseStatusCode = await _studentApiService.Response(studentDelete, "Delete" + $"/{TCNo}");
            if (responseStatusCode.StatusCode == 200)
            {
                MessageBox.Show($"{FirstName} {LastName} isimli ögrenci başarılı silindi...", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
