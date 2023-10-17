using Newtonsoft.Json;
using Student_Follower.Entities;
using Student_Follower.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Follower
{
    public partial class Register : Form
    {
        private readonly UserApiService _userApiService;
        private readonly UserOperationClaimService userOperationClaimService;
        public Register()
        {
            InitializeComponent();
            _userApiService = new UserApiService();
            this.userOperationClaimService = new UserOperationClaimService();
        }
        const string roleNameMudur = "müdür";
        const string roleNamePersonel = "personel";
        private async void kullanicilari_goster()
        {
            List<UserList> dataList = await _userApiService.GetAll();
            // dataGridView1.DataSource = dataList;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kullanıcı İşlemleri....";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            kullanicilari_goster();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            RegisterUser userAdd = new RegisterUser();
            userAdd.FirstName = textBox1.Text;
            userAdd.LastName = textBox2.Text;
            userAdd.Email = textBox3.Text;
            userAdd.Password = textBox4.Text;

            ResponseStatusCode responseStatusCode = await _userApiService.Response(userAdd, "Register");
            if (responseStatusCode.StatusCode == 200)
            {
                RegisteredDto datalist = JsonConvert.DeserializeObject<RegisteredDto>(responseStatusCode.Content);

                MessageBox.Show($"Kullanıcı {textBox1.Text + " " + textBox2.Text} başarıyla eklendi.", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (radioButton1.Checked)
                {
                    CreateUserOperationClaim createUserOperationClaim = new CreateUserOperationClaim()
                    {
                        Email = textBox3.Text,
                        RoleName = roleNameMudur
                    };
                    await userOperationClaimService.Add(createUserOperationClaim);

                    this.Hide();
                    Login form2 = new Login();
                    form2.Show();
                }
                if (radioButton2.Checked)
                {
                    CreateUserOperationClaim createUserOperationClaim = new CreateUserOperationClaim()
                    {
                        Email = textBox3.Text,
                        RoleName = roleNamePersonel
                    };
                    await userOperationClaimService.Add(createUserOperationClaim);
                    this.Hide();
                    Login form2 = new Login();
                    form2.Show();
                }
            }
            else
            {
                GenericApiService.ErrorService(responseStatusCode);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Eğer girilen karakter harf, rakam, nokta (.) veya @ sembolü değilse ve backspace (silme) tuşu değilse,
            // olayı işlemeyi engelleyin.
            char enterdeChar = e.KeyChar;
            if (!char.IsLetterOrDigit(enterdeChar) && enterdeChar != '.' && enterdeChar != '@' && enterdeChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 8)
                errorProvider1.SetError(textBox4, "Kullanıcı Şifresi 8 Karakter olmalı !");
            else
                errorProvider1.Clear();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            this.Top = -vScrollBar1.Value;
        }
    }
}
