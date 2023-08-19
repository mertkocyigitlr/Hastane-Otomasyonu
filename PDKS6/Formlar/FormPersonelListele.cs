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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PDKS6.Formlar
{
    public partial class FormPersonelListele : Form
    {
        private string connectionString = "Server=localhost;Database=pdks;Uid=root;Pwd=root;";
        public FormPersonelListele()
        {
            InitializeComponent();
            FormPersonelListele_Load(this, EventArgs.Empty); // Form yüklendiğinde olayı çağır
            cmbDoldur();

        }

        private void FormPersonelListele_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectQuery = "SELECT personel_Id AS 'Personel ID', ad AS 'Ad', soyad AS 'Soyad', tel_no AS 'Telefon' , tc_kimlik_no AS 'TC Kimlik No' , email AS 'Email', acık_adres AS 'Adres' , departman AS 'Departman', maas_tutarı 'Maas'  , ise_giris_tarihi AS 'İşe Giriş Tarihi', acıklama  AS 'AÇIKLAMA' FROM personel";
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satıra tıklanıldığını kontrol ediyoruz
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                txtPersonelID.Text = selectedRow.Cells["Personel ID"].Value.ToString();
                txtAd.Text = selectedRow.Cells["Ad"].Value.ToString();
                txtSoyad.Text = selectedRow.Cells["Soyad"].Value.ToString();
                txtTelefon.Text = selectedRow.Cells["Telefon"].Value.ToString();
                txtkimlikno.Text = selectedRow.Cells["TC Kimlik No"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtAdres.Text = selectedRow.Cells["Adres"].Value.ToString();
                txtDepartman.Text = selectedRow.Cells["Departman"].Value.ToString();
                txtMaas.Text = selectedRow.Cells["Maas"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells["İşe Giriş Tarihi"].Value);
                txtAciklama.Text = selectedRow.Cells["AÇIKLAMA"].Value.ToString();
            }
            MessageBox.Show("Cell clicked!");
        }
        private void cmbDoldur()
        {

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand doldur = new MySqlCommand("SELECT departman_adi FROM departmanlar", connection);
            MySqlDataReader dr = doldur.ExecuteReader();
            while (dr.Read())
            {
                txtDepartman.Items.Add(dr[0]);
            }

            connection.Close();

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Seçilen satırı veritabanında güncelle
                    string updateQuery = "UPDATE personel SET ad = @Ad, soyad = @Soyad, tel_no = @Telefon, tc_kimlik_no = @TCKimlikNo, email = @Email, acık_adres = @Adres, departman = @Departman, maas_tutarı = @Maas, ise_giris_tarihi = @IseGirisTarihi, acıklama = @Aciklama WHERE personel_Id = @PersonelID";
                    MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, connection);

                    cmdUpdate.Parameters.AddWithValue("@Ad", txtAd.Text);
                    cmdUpdate.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                    cmdUpdate.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                    cmdUpdate.Parameters.AddWithValue("@TCKimlikNo", txtkimlikno.Text);
                    cmdUpdate.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmdUpdate.Parameters.AddWithValue("@Adres", txtAdres.Text);
                    cmdUpdate.Parameters.AddWithValue("@Departman", txtDepartman.Text);
                    cmdUpdate.Parameters.AddWithValue("@Maas", txtMaas.Text);
                    cmdUpdate.Parameters.AddWithValue("@IseGirisTarihi", dateTimePicker1.Value);
                    cmdUpdate.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                    cmdUpdate.Parameters.AddWithValue("@PersonelID", txtPersonelID.Text);

                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Kayıt güncellendi.");

                    // DataGridView'ı yeniden güncelle
                    FormPersonelListele_Load(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }

        private void btn__sil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seçili kişiyi silmek istediğinizden emin misiniz?", "Kişi Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                            string personelID = selectedRow.Cells["Personel ID"].Value.ToString();

                            string deleteQuery = "DELETE FROM personel WHERE personel_Id = @PersonelID";
                            MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, connection);
                            cmdDelete.Parameters.AddWithValue("@PersonelID", personelID);
                            cmdDelete.ExecuteNonQuery();

                            MessageBox.Show("Kişi silindi.");

                            // DataGridView'ı yeniden güncelle
                            FormPersonelListele_Load(this, EventArgs.Empty);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Veritabanı hatası: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kişiyi seçin.");
            }
        }

    }


}
