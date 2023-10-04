using Student_Follower.Entities;
using Student_Follower.Services;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Student_Follower
{
    public partial class Form2 : Form
    {
        private readonly UserApiService _userApiService;

        public Form2()
        {
            InitializeComponent();
            _userApiService = new UserApiService();
        }
        public static string adi, soyadi, yetki;

        int hak = 3;
        const string roleNameYonetici = "yönetici";
        const string roleNamePersonel = "personel";

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            UserForLogin userForLogin = new UserForLogin();
            userForLogin.Email = textBox1.Text;
            userForLogin.Password = textBox2.Text;
            bool IsLogin = await _userApiService.Login(userForLogin);
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            string email = textBox1.Text;
            if (hak != 0)
            {
                if (Regex.IsMatch(email, pattern))
                {
                    string password = textBox2.Text;

                    if (password.Length < 8)
                    {
                        MessageBox.Show("Şifre en az 8 karakter olur", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    if (IsLogin)
                    {
                        MessageBox.Show("Giriş İşlemi Başarılı", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Form4 form4 = new Form4();
                        form4.Show();
                    }
                    else
                    {
                        MessageBox.Show("Şifre veya Email yanlış girdiniz kontrol ediniz.. ", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir Gmail e-posta adresi girin.", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            label5.Text = Convert.ToString(hak);
            
            if (hak == 0)
            {
                button1.Enabled = false;
                MessageBox.Show("Giriş Hakkı Kalmadı!", "Ögrenci Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

            }



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SifremiUnuttum sifremiUnuttum = new SifremiUnuttum();
            sifremiUnuttum.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        bool durum = false;
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Kullanıcı Girişi....";
            this.AcceptButton = button1;
            this.CancelButton = button2;
            radioButton1.Checked = true;
            toolTip1.SetToolTip(this.textBox1, "Email işlemlerinde @gmail.com ile biter.");

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

        }
    }
}
