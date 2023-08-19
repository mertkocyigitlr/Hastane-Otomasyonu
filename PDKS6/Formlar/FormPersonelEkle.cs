using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDKS6.Formlar
{
    public partial class FormPersonelEkle : Form
    {
        

        private string connectionString = "Server=localhost;Database=pdks;Uid=root;Pwd=root;";
        public FormPersonelEkle()
        {
            InitializeComponent();
            cmbDoldur();
        }

        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_personel_ekle_Click(object sender, EventArgs e)
        {

            string personelAd = txtAd.Text;
            string personelSoyad = txtSoyad.Text;
            string tcKimlikNo = txtTCKimlikNo.Text;
            string telNo = txtTelNo.Text;
            string email = txtEmail.Text;
            string acikAdres = txtAcikAdres.Text;
            string maas = txtmaas.Text;
            string acıklama = txtacıklama.Text;


            // Girdi alanlarını kontrol et
            if (string.IsNullOrEmpty(personelAd) || string.IsNullOrEmpty(personelSoyad) || string.IsNullOrEmpty(tcKimlikNo) || string.IsNullOrEmpty(telNo) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(acikAdres) || string.IsNullOrEmpty(maas) || string.IsNullOrEmpty(acıklama))
            {
                MessageBox.Show("Ad, Soyad, Kimlik No ve Telefon Numarası alanları boş bırakılamaz.");
                return;
            }

            if (tcKimlikNo.Length != 11 || !tcKimlikNo.All(char.IsDigit))
            {
                MessageBox.Show("TC Kimlik Numarası 11 haneli olmalı ve sadece rakamlardan oluşmalıdır.");
                return;
            }
            // ComboBox'dan seçili departman adını al
            string secilenDepartman = comboBox1.SelectedItem?.ToString();


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Aynı TC kimlik numarasına sahip personel var mı kontrol et
                    string checkQuery = "SELECT COUNT(*) FROM personel WHERE tc_kimlik_no = @tcKimlikNo";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@tcKimlikNo", tcKimlikNo);

                    // İşe giriş için 
                    DateTime ise_giris_tarihi = dateTimePicker1.Value;
                    string ise_giris_tarihiString = ise_giris_tarihi.ToString("yyyy-MM-dd");

                    // doğum tarihi 
                    DateTime dogumTarihi = dateTimePicker2.Value;
                    string dogumTarihiString = dogumTarihi.ToString("yyyy-MM-dd");

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Bu TC kimlik numarasına sahip bir personel zaten var.");
                        return;
                    }

                    // Yeni personeli veritabanına ekle
                    string insertQuery = "INSERT INTO personel (ad, soyad, tc_kimlik_no, tel_no, email, acık_adres, maas_tutarı, ise_giris_tarihi, dogumTarihi, acıklama, departman) " +
                                  "VALUES (@ad, @soyad, @tc_kimlik_no, @tel_no, @email, @acık_adres, @maas_tutarı, @ise_giris_tarihi, @dogumTarihi, @acıklama, @departman)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@ad", personelAd);
                    cmd.Parameters.AddWithValue("@soyad", personelSoyad);
                    cmd.Parameters.AddWithValue("@tc_kimlik_no", tcKimlikNo);
                    cmd.Parameters.AddWithValue("@tel_no", telNo);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@acık_adres", acikAdres);
                    cmd.Parameters.AddWithValue("@maas_tutarı", maas);
                    cmd.Parameters.AddWithValue("@ise_giris_tarihi", ise_giris_tarihi);
                    cmd.Parameters.AddWithValue("@dogumTarihi", dogumTarihi);
                    cmd.Parameters.AddWithValue("@acıklama", acıklama);
                    cmd.Parameters.AddWithValue("@departman", secilenDepartman); // Seçilen departman adını kaydet


                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Personel başarıyla eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Personel eklenirken bir hata oluştu.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }



        // Bu Kod Bloğunu silme combobox hata veriyor
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
         {
            /* try
             {
                 comboBox1.Items.Clear();
                 using (MySqlConnection connection = new MySqlConnection(connectionString))
                 {
                     connection.Open();

                     string selectQuery = "SELECT departman_adi FROM departmanlar"; // Departman adlarını getir
                     MySqlCommand cmd = new MySqlCommand(selectQuery, connection);

                     using (MySqlDataReader reader = cmd.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             comboBox1.Items.Add(reader["departman_adi"].ToString()); // ComboBox'a verileri ekle
                         }
                     }
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Veritabanı hatası: " + ex.Message);
             }*/
         }
        private void cmbDoldur()
        {

            MySqlConnection connection = new MySqlConnection(connectionString);
           connection.Open();

            MySqlCommand doldur = new MySqlCommand("SELECT departman_adi FROM departmanlar", connection);
            MySqlDataReader dr = doldur.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }

            connection.Close();

        }

        private void FormPersonelEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
