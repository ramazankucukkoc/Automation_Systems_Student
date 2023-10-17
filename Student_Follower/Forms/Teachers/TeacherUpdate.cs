﻿using Newtonsoft.Json;
using Student_Follower.Entities;
using Student_Follower.Entities.Teachers;
using Student_Follower.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Follower.Forms.Teachers
{
    public partial class TeacherUpdate : Form
    {
        private readonly TeacherApiService _teacherApiService;
        public TeacherUpdate()
        {
            _teacherApiService = new TeacherApiService();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Teacher teacher = new Teacher();
            teacher.Show();
        }

        private void TeacherUpdate_Load(object sender, EventArgs e)
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
            {
                GenericApiService.ErrorService(responseStatusCode);
            }
        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
                TeacherUpdatePopUp teacherUpdatePopUp = new TeacherUpdatePopUp(birthDay, tcNo, firstName, lastName, phoneNo, email);
                this.Close();

                teacherUpdatePopUp.Show();


            }
        }
    }
}
