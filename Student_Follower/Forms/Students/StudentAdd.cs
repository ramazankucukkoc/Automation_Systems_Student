using Student_Follower.Entities;
using Student_Follower.Services;
using System;
using System.Windows.Forms;

namespace Student_Follower
{
    public partial class StudentAdd : Form
    {
        private StudentApiService _studentApiService;
        public StudentAdd()
        {
            _studentApiService = new StudentApiService();
            InitializeComponent();
        }
        private void StudentAdd_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            AddStudent studentAdd = new AddStudent();
            studentAdd.TCNo = maskedTextBox2.Text;
            studentAdd.FirstName = textBox2.Text;
            studentAdd.LastName = textBox3.Text;
            studentAdd.PhoneNo = maskedTextBox1.Text;
            studentAdd.Email = textBox5.Text;
            studentAdd.BirthDay = dateTimePicker1.Value;

            ResponseStatusCode responseStatusCode = await _studentApiService.Response(studentAdd, "Add");
            if (responseStatusCode.StatusCode == 200)
            {
                MessageBox.Show($"{studentAdd.FirstName} {studentAdd.LastName} isimli ögrenci başarılı eklendi...", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                StudentList studentList = new StudentList();
                studentList.Show();
            }
            else
            {
                GenericApiService.ErrorService(responseStatusCode);
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Ogrenciİslemeleri form3 = new Ogrenciİslemeleri();
            form3.Show();
        }
    }
}
