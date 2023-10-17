using Newtonsoft.Json;
using Student_Follower.Entities;
using Student_Follower.Entities.Teachers;
using Student_Follower.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Follower.Forms.Teachers
{
    public partial class TeacherSearch : Form
    {
        private readonly TeacherApiService _service;
        public TeacherSearch()
        {
            _service = new TeacherApiService();
            InitializeComponent();
        }
        public string TCNo = string.Empty;
        private void TeacherSearch_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;


            GetAllTeachers();

        }
        private async Task GetAllTeachers()
        {
            ResponseStatusCode responseStatusCode = await _service.GetResponse("GetAll");
            if (responseStatusCode.StatusCode == 200)
            {
                List<ListTeacher> datalist = JsonConvert.DeserializeObject<List<ListTeacher>>(responseStatusCode.Content);
                dataGridView1.DataSource = datalist;
            }
            else
                GenericApiService.ErrorService(responseStatusCode);
        }
        private async void GetTCNo()
        {
            TCNo = maskedTextBox1.Text;
            ResponseStatusCode responseStatusCode = await _service.GetResponse("GetByTCNo" + $"/{TCNo}");
            if (responseStatusCode.StatusCode == 200)
            {
                ListTeacher datalist = JsonConvert.DeserializeObject<ListTeacher>(responseStatusCode.Content);
                dataGridView1.DataSource = datalist;
            }
            else
                GenericApiService.ErrorService(responseStatusCode);
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            GetTCNo();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Teacher teacher = new Teacher();
            teacher.Show();
        }
    }
}
