using Newtonsoft.Json;
using Student_Follower.Entities;
using Student_Follower.Roles;
using Student_Follower.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Follower
{
    public partial class Login : Form
    {
        private readonly UserApiService _userApiService;

        public Login()
        {
            InitializeComponent();
            _userApiService = new UserApiService();
        }
        public static string adi, soyadi, yetki;

        int hak = 3;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register form1 = new Register();
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

            ResponseStatusCode responseStatusCode = await _userApiService.Response(userForLogin, "Login");

            if (hak != 0)
            {
                if (responseStatusCode.StatusCode == 200)
                {
                    LoginDto datalist = JsonConvert.DeserializeObject<LoginDto>(responseStatusCode.Content);
                    List<string> getByRols = GetByRols.Roles(datalist.AccessToken.Token);
                    string mudur = "müdür";
                    if (getByRols[3].ToLower().Trim() == mudur)
                    {
                        this.Hide();
                        Form2 form2 = new Form2();
                        form2.Show();

                    }
                    if (getByRols[3].ToLower().Trim() == "personel")
                    {
                        this.Hide();
                        PersonelIslemleri teacher = new PersonelIslemleri();
                        teacher.Show();
                    }
                }
                else
                {
                    GenericApiService.ErrorService(responseStatusCode);
                    hak++;
                }
            }

            label5.Text = Convert.ToString(hak);

            if (hak == 0)
            {
                button1.Enabled = false;
                MessageBox.Show("Giriş Hakkı Kalmadı Kaydınız Bloke olmuştur...!", "Ögrenci Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SifremiUnuttum sifremiUnuttum = new SifremiUnuttum();
            sifremiUnuttum.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        bool durum = false;
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Kullanıcı Girişi....";
            // this.AcceptButton = button1;

            toolTip1.SetToolTip(this.textBox1, "Email işlemlerinde @gmail.com ile biter.");

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

        }
    }
}
