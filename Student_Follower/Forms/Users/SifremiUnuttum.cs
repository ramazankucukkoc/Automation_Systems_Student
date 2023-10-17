using Student_Follower.Entities;
using Student_Follower.Services;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Student_Follower
{
    public partial class SifremiUnuttum : Form
    {
        private readonly UserApiService _userApiService;

        public SifremiUnuttum()
        {
            InitializeComponent();
            _userApiService = new UserApiService();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Email = email;
            bool IsForgotPassword = await _userApiService.ForgotPassword(forgotPassword);

            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            if (Regex.IsMatch(email, pattern))
            {
                if (IsForgotPassword)
                {
                    MessageBox.Show("Mail Adresinize Şifreniz İletildi. Giriş Yapabilirsiniz yeni şifrenizle", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Login form2 = new Login();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Email yanlış girdiniz kontrol ediniz.. ", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            else
            {
                MessageBox.Show("Lütfen geçerli bir Gmail e-posta adresi girin.", "Ögrenci Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void SifremiUnuttum_Load(object sender, EventArgs e)
        {
            this.Text = "Şifremi Unuttum....";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }
    }
}
