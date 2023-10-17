using Student_Follower.Forms.Teachers;
using System;
using System.Windows.Forms;

namespace Student_Follower
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Teacher teacher = new Teacher();
            teacher.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Ogrenciİslemeleri form3 = new Ogrenciİslemeleri();
            form3.Show();

        }
    }
}
