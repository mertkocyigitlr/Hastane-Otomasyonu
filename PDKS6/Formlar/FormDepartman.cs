using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PDKS6.Formlar
{
    public partial class FormDepartman : Form
    {
        private string connectionString = "Server=localhost;Database=pdks;Uid=root;Pwd=root;";

        public FormDepartman()
        {
            InitializeComponent();
            PopulateDataGridView();
        }

        private void btn_dptEkle_Click(object sender, EventArgs e)
        {
            string yeniDepartmanAdi = txtdepartman.Text;
            string yeniDepartmanID = txtdptID.Text;
            string yeniAcıklama = txtdptacıklama.Text;

            // Girdi alanlarını kontrol et
            if (string.IsNullOrEmpty(yeniDepartmanAdi) || string.IsNullOrEmpty(yeniDepartmanID) || string.IsNullOrEmpty(yeniAcıklama))
            {
                MessageBox.Show("Departman adı, ID ve açıklama alanları boş bırakılamaz.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Aynı ID'ye sahip departmanın olup olmadığını kontrol et
                    string checkQuery = "SELECT COUNT(*) FROM departmanlar WHERE departman_Id = @departmanID";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@departmanID", yeniDepartmanID);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Bu ID'ye sahip bir departman zaten var.");
                        return;
                    }

                    // Yeni departman eklemesi yap
                    string insertQuery = "INSERT INTO departmanlar (departman_Id, departman_adi , acıklama) VALUES (@departmanID, @departmanAdi , @departmanAcıklama)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@departmanID", yeniDepartmanID);
                    cmd.Parameters.AddWithValue("@departmanAdi", yeniDepartmanAdi);
                    cmd.Parameters.AddWithValue("@departmanAcıklama", yeniAcıklama);

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Departman başarıyla eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Departman eklenirken bir hata oluştu.");
                    }

                    // Yeni departman ekledikten sonra DataGridView'i güncelle
                    PopulateDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }


        private void PopulateDataGridView()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectQuery = "SELECT departman_Id AS 'Departman ID', departman_adi AS 'Departman Adı', acıklama AS 'Açıklama' FROM departmanlar";
                    MySqlCommand cmd = new MySqlCommand(selectQuery, connection);

                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }

        private void btn_dptGuncelle_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

            string departmanId = selectedRow.Cells["Departman ID"].Value.ToString();
            string yeniDepartmanAdi = txtdepartman.Text;
            string yeniAciklama = txtdptacıklama.Text;

            // Girdi alanlarını kontrol et
            if (string.IsNullOrEmpty(yeniDepartmanAdi) || string.IsNullOrEmpty(yeniAciklama))
            {
                MessageBox.Show("Departman adı ve Açıklama alanları boş bırakılamaz.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE departmanlar SET departman_adi = @departmanAdi, acıklama = @aciklama WHERE departman_Id = @departmanID";
                    MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                    cmd.Parameters.AddWithValue("@departmanID", departmanId);
                    cmd.Parameters.AddWithValue("@departmanAdi", yeniDepartmanAdi);
                    cmd.Parameters.AddWithValue("@aciklama", yeniAciklama);

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Departman başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Departman güncellenirken bir hata oluştu.");
                    }

                    // Güncelleme işleminden sonra DataGridView'i güncelle
                    PopulateDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }

        private void btn_dptSil_Click(object sender, EventArgs e)
        {
            string silinecekDepartmanId = txtdptID.Text;

            // Girdi alanını kontrol et
            if (string.IsNullOrEmpty(silinecekDepartmanId))
            {
                MessageBox.Show("Silinecek departmanın ID'sini girin.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM departmanlar WHERE departman_Id = @departmanID";
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                    cmd.Parameters.AddWithValue("@departmanID", silinecekDepartmanId);

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Departman başarıyla silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Departman silinirken bir hata oluştu veya belirtilen ID bulunamadı.");
                    }

                    PopulateDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }

    }
}
