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
    public partial class TeacherList : Form
    {
        private readonly TeacherApiService _teacherApiService;
        public TeacherList()
        {
            _teacherApiService = new TeacherApiService();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Teacher teacher = new Teacher();
            teacher.Show();
        }

        private void TeacherList_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            GetAllTeachers();
        }
        private async Task GetAllTeachers()
        {
            ResponseStatusCode responseStatusCode = await _teacherApiService.GetResponse("GetAll");
            if (responseStatusCode.StatusCode == 200)
            {
                List<ListTeacher> datalist = JsonConvert.DeserializeObject<List<ListTeacher>>(responseStatusCode.Content);
                dataGridView1.DataSource = datalist;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            else
                GenericApiService.ErrorService(responseStatusCode);

        }

    }
}
