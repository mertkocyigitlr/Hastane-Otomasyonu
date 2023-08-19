using System;
using MySql.Data.MySqlClient; // MySQL veritabanı kullanılıyorsa bu kütüphaneyi ekleyin
using System.Windows.Forms;

namespace PDKS6.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=pdks;Uid=root;Pwd=root;";
            // Yukarıdaki satırı MySQL sunucu adresi, veritabanı adı, kullanıcı adı ve şifre ile güncelleyin.

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string username = UsernameTextBox.Text;
                    string password = PasswordTextBox.Text;

                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                    // Yukarıdaki sorguyu, kullanıcı tablosu adını ve alan adlarınızı kullanarak güncelleyin.

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());


                        if (count > 0)
                        {
                             // / Giriş başarılı olduğunda Form1'i aç
                            Form1 form1 = new Form1();
                            form1.Show();

                            // LoginForm'ı gizle veya kapat
                            this.Hide(); // veya this.Close();



                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
