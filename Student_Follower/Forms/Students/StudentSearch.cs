using Newtonsoft.Json;
using Student_Follower.Entities;
using Student_Follower.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Follower.Forms.Students
{
    public partial class StudentSearch : Form
    {
        private readonly StudentApiService _studentApiService;
        private string FormName;
        public StudentSearch(string formName)
        {
            FormName = formName;
            _studentApiService = new StudentApiService();
            InitializeComponent();
        }

        public StudentSearch()
        {
            _studentApiService = new StudentApiService();
            InitializeComponent();
        }


        private void StudentSearch_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            GetAllStudents();
        }
        private async Task GetAllStudents()
        {
            ResponseStatusCode responseStatusCode = await _studentApiService.GetResponse("GetAll");
            if (responseStatusCode.StatusCode == 200)
            {
                List<ListStudent> datalist = JsonConvert.DeserializeObject<List<ListStudent>>(responseStatusCode.Content);
                dataGridView1.DataSource = datalist;
            }
            else
                GenericApiService.ErrorService(responseStatusCode);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FormName == "PersonelIslemleri")
            {
                this.Close();
                PersonelIslemleri personel = new PersonelIslemleri();
                personel.Show();
            }
            else
            {
                this.Close();
                Ogrenciİslemeleri form = new Ogrenciİslemeleri();
                form.Show();
            }         
        }
    }

}
