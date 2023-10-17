using Student_Follower.Entities;
using Student_Follower.Entities.Teachers;
using Student_Follower.Services;
using System;
using System.Windows.Forms;

namespace Student_Follower.Forms.Teachers
{
    public partial class TeacherAdd : Form
    {
        private readonly UserApiService _service;
        private readonly UserOperationClaimService userOperationClaimService;
        public TeacherAdd()
        {
            this.userOperationClaimService = new UserOperationClaimService();
            _service = new UserApiService();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Teacher teacher = new Teacher();
            teacher.Show();
        }
        private void TeacherAdd_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            AddTeacher addTeacher = new AddTeacher();
            addTeacher.TCNo = maskedTextBox2.Text;
            addTeacher.FirstName = textBox2.Text;
            addTeacher.LastName = textBox3.Text;
            addTeacher.PhoneNo = maskedTextBox1.Text;
            addTeacher.Email = textBox5.Text;
            addTeacher.BirthDay = dateTimePicker1.Value;
            addTeacher.Password = textBox1.Text;
            if (textBox1.Text == textBox4.Text)
            {
                ResponseStatusCode responseStatusCode = await _service.Response(addTeacher, "Register");
                if (responseStatusCode.StatusCode == 200)
                {
                    MessageBox.Show($"{addTeacher.FirstName} {addTeacher.LastName} isimli personel başarılı eklendi...", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CreateUserOperationClaim createUserOperationClaim = new CreateUserOperationClaim()
                    {
                        Email = textBox5.Text,
                        RoleName = "personel"
                    };
                    await userOperationClaimService.Add(createUserOperationClaim);
                    this.Close();
                    TeacherList teacherList = new TeacherList();
                    teacherList.Show();
                }
                else
                    GenericApiService.ErrorService(responseStatusCode);
            }
            else
                MessageBox.Show($"{addTeacher.FirstName} {addTeacher.LastName} şifreniz birbiriyle eşleşmiyor lütfen tekrar giriniz...", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}