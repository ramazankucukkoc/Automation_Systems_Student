using Newtonsoft.Json;
using Student_Follower.Entities;
using Student_Follower.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Follower
{
    public partial class StudentList : Form
    {
        private readonly StudentApiService _studentApiService;

        public StudentList(string formName)
        {
            SenderForm = formName;
            _studentApiService = new StudentApiService();
            InitializeComponent();
        }

        public StudentList()
        {
            _studentApiService = new StudentApiService();
            InitializeComponent();
        }
        public string SenderForm { get; set; }

        private void StudentList_Load(object sender, EventArgs e)
        {
            this.Text = "Ögrenci Listesi";
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
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            else
            {
                GenericApiService.ErrorService(responseStatusCode);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (SenderForm == "PersonelIslemleri")
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
