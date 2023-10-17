using System;
using System.Windows.Forms;

namespace Student_Follower.Forms.Teachers
{
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            this.Text = "Personel İşlemleri";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void kayıtEkleme_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherAdd teacherAdd = new TeacherAdd();
            teacherAdd.Show();
        }

        private void kayırSilme_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherDelete teacherDelete = new TeacherDelete();
            teacherDelete.Show();
        }

        private void kayıtGuncelleme_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherUpdate teacherUpdate = new TeacherUpdate();
            teacherUpdate.Show();
        }

        private void kayıtListeleme_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherList teacherList = new TeacherList();
            teacherList.Show();
        }

        private void kayıtArama_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherSearch teacherSearch = new TeacherSearch();
            teacherSearch.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login =new Login();
            login.Show();
        }
    }
}
