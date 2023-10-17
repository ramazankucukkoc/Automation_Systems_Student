using Newtonsoft.Json;
using Student_Follower.Entities;
using Student_Follower.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Follower
{
    public partial class StudentUpdate : Form
    {
        private readonly StudentApiService _studentApiService;
        public StudentUpdate()
        {
            _studentApiService = new StudentApiService();
            InitializeComponent();
        }

        private void StudentUpdate_Load(object sender, EventArgs e)
        {
            this.Text = "Güncelleme İşlemleri ...";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Seçilen satırın verilerini alabilirsiniz
                string email = selectedRow.Cells["Email"].Value.ToString();
                string firstName = selectedRow.Cells["FirstName"].Value.ToString();
                string lastName = selectedRow.Cells["LastName"].Value.ToString();
                string tcNo = selectedRow.Cells["TCNo"].Value.ToString();
                string phoneNo = selectedRow.Cells["PhoneNo"].Value.ToString();
                DateTime birthDay = (DateTime)selectedRow.Cells["BirthDay"].Value;
                StudentUpdatePopUp studentUpdatePopUp = new StudentUpdatePopUp(birthDay, tcNo, firstName, lastName, phoneNo, email);
                this.Close();

                studentUpdatePopUp.Show();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Ogrenciİslemeleri form3 = new Ogrenciİslemeleri();
            form3.Show();
        }
    }
}
