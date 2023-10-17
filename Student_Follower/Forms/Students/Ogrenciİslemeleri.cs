using Student_Follower.Forms.Courses;
using Student_Follower.Forms.Students;
using System;
using System.Windows.Forms;

namespace Student_Follower
{
    public partial class Ogrenciİslemeleri : Form
    {
        public Ogrenciİslemeleri()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "Müdür İşlemleri";
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentList studentList = new StudentList();
            studentList.Show();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentAdd studentAdd = new StudentAdd();
            studentAdd.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentDelete studentDelete = new StudentDelete();
            studentDelete.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentUpdate studentUpdate = new StudentUpdate();
            studentUpdate.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CoursesNotes coursesNotes = new CoursesNotes();
            coursesNotes.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            CoursePlan coursePlan = new CoursePlan();
            coursePlan.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentDataAnalysis studentDataAnalysis = new StudentDataAnalysis();
            studentDataAnalysis.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentSearch studentSearch = new StudentSearch();
            studentSearch.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login =new Login();
            login.Show();
        }
    }
}
