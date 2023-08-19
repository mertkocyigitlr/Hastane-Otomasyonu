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
    public partial class MaaşZamları : Form
    {
        private string connectionString = "Server=localhost;Database=pdks;Uid=root;Pwd=Adimor1234?;";
        public MaaşZamları()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rdoYuzde_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoYuzde.Checked)
            {
                // Yüzde RadioButton seçildiğinde fiyat alanını gizle
                txtFiyat.Visible = false;
                lblFiyat.Visible = false;
                txtYuzde.Visible = true;
                lblYuzde.Visible = true;
            }
        }

        private void rdoFiyat_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFiyat.Checked)
            {
                // Yüzde RadioButton seçildiğinde fiyat alanını gizle
                txtFiyat.Visible = true;
                lblFiyat.Visible = true;
                txtYuzde.Visible = false;
                lblYuzde.Visible = false;
            }
        }

        private void btn_bilgiGetir_Click(object sender, EventArgs e)
        {
            string tcKimlikNo = txt_kimlik.Text;

            if (tcKimlikNo.Length == 11) // TC Kimlik Numarası 11 haneli mi kontrolü
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string selectQuery = "SELECT p.*, m.tarih AS tarih, m.maas_acıklama AS aciklama FROM personel p " +
                                             "LEFT JOIN maashareketleri m ON p.tc_kimlik_no = m.tc_kimlik_no " +
                                             "WHERE p.tc_kimlik_no = @TCKimlikNo " +
                                             "ORDER BY m.tarih DESC LIMIT 1";

                        MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                        cmd.Parameters.AddWithValue("@TCKimlikNo", tcKimlikNo);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Veritabanında kayıt bulunduysa
                            {
                                // Veritabanından çekilen bilgileri TextBox'lara yerleştir
                                txtad.Text = reader["ad"].ToString();
                                txtsoyad.Text = reader["soyad"].ToString();
                                txtmaas.Text = reader["maas_tutarı"].ToString();
                                txtacıklama.Text = reader["aciklama"].ToString();

                                // Tarih bilgisini çekmeden önce null kontrolü yapın
                                if (!reader.IsDBNull(reader.GetOrdinal("tarih")))
                                {
                                    DateTime tarihFromDatabase = reader.GetDateTime(reader.GetOrdinal("tarih"));
                                    dtpTarih.Value = tarihFromDatabase;
                                }
                                else
                                {
                                    // Null tarih durumuyla ilgili işlemi burada yapabilirsiniz
                                    // Örneğin, varsayılan bir tarih atayabilirsiniz.
                                    dtpTarih.Value = DateTime.Today;
                                }

                                // Diğer alanları da benzer şekilde ekleyebilirsiniz
                            }
                            else
                            {
                                MessageBox.Show("Kayıt bulunamadı.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanı hatası: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir TC Kimlik Numarası giriniz.");
            }
        }



        private void btn_onay_Click(object sender, EventArgs e)
        {
            string tcKimlikNo = txt_kimlik.Text;

            if (tcKimlikNo.Length == 11)
            {
                if (rdoYuzde.Checked || rdoFiyat.Checked) // Herhangi biri seçildiyse
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            string selectQuery = "SELECT * FROM personel WHERE tc_kimlik_no = @TCKimlikNo";
                            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                            cmd.Parameters.AddWithValue("@TCKimlikNo", tcKimlikNo);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    double maas = Convert.ToDouble(reader["maas_tutarı"]);
                                    double yeniMaas = 0;
                                    // İlk DataReader işi bittiğinde kapat
                                    reader.Close();

                                    if (rdoYuzde.Checked)
                                    {
                                        double yuzde = Convert.ToDouble(txtYuzde.Text);
                                        double zamMiktari = maas * (yuzde / 100);
                                        yeniMaas = maas + zamMiktari;
                                    }
                                    else if (rdoFiyat.Checked)
                                    {
                                        double fiyatArtisi = Convert.ToDouble(txtFiyat.Text);
                                        yeniMaas = maas + fiyatArtisi;
                                    }

                                    // Açıklama verisini al
                                    string maasAciklama = txtacıklama.Text;

                                    // Yeni maaşı veritabanına kaydet
                                    string updateQuery = "UPDATE personel SET maas_tutarı = @YeniMaas WHERE tc_kimlik_no = @TCKimlikNo";
                                    MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, connection);
                                    cmdUpdate.Parameters.AddWithValue("@YeniMaas", yeniMaas);
                                    cmdUpdate.Parameters.AddWithValue("@TCKimlikNo", tcKimlikNo);
                                    cmdUpdate.ExecuteNonQuery();

                                    txtZamlıMaas.Text = yeniMaas.ToString();

                                    // Maaş hareketlerini maashareketleri tablosuna kaydet
                                    string insertQuery = "INSERT INTO maashareketleri (tc_kimlik_no, eski_maas, yeni_maas, tarih, maas_acıklama) VALUES (@TCKimlikNo, @EskiMaas, @YeniMaas, @Tarih, @maas_acıklama)";
                                    MySqlCommand cmdInsert = new MySqlCommand(insertQuery, connection);
                                    cmdInsert.Parameters.AddWithValue("@TCKimlikNo", tcKimlikNo);
                                    cmdInsert.Parameters.AddWithValue("@EskiMaas", maas);
                                    cmdInsert.Parameters.AddWithValue("@YeniMaas", yeniMaas);
                                    cmdInsert.Parameters.AddWithValue("@Tarih", dtpTarih.Value);
                                    cmdInsert.Parameters.AddWithValue("@maas_acıklama", maasAciklama);

                                    cmdInsert.ExecuteNonQuery();

                                    MessageBox.Show("Maaş güncellendi ve maaş hareketleri kaydedildi.");
                                }
                                else
                                {
                                    MessageBox.Show("Kayıt bulunamadı.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Veritabanı hatası: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen maaş artış türünü seçiniz.");
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir TC Kimlik Numarası giriniz.");
            }
        }



    }
}
    

