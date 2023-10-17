using Student_Follower.Forms.Courses;
using Student_Follower.Forms.Students;
using System;
using System.Windows.Forms;

namespace Student_Follower
{
    public partial class PersonelIslemleri : Form
    {
        public PersonelIslemleri()
        {
            InitializeComponent();
        }
        private void PersonelIslemleri_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            StudentList studentList = new StudentList("PersonelIslemleri");
            studentList.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentDataAnalysis dataAnalysis = new StudentDataAnalysis("PersonelIslemleri");
            dataAnalysis.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CoursesNotes coursesNotes = new CoursesNotes("PersonelIslemleri");
            coursesNotes.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentSearch studentSearch = new StudentSearch("PersonelIslemleri");
            studentSearch.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
