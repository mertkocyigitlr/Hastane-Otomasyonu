using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace PDKS6.Formlar
{
    public partial class MesaiEkle : Form
    {
        private string connectionString = "Server=localhost;Database=pdks;Uid=root;Pwd=root;";

        public MesaiEkle()
        {
            InitializeComponent();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            string tcKimlikNo = txtpersonelTC.Text;
            double mesaiSaatUcreti = Convert.ToDouble(txtMesaiSaatücreti.Text);
            string mesaiAcıklama = txtMesaiAcıklama.Text;

            // Tarih seçimini al
            DateTime mesaiTarihi = dtpMesaiTarihi.Value;

            // MaskedTextBox'lardan seçilen saatleri al
            string baslangicSaatiText = dptbaşlangıçsaati.Text;
            string bitisSaatiText = dtpbitişsaati.Text;

            // Zaman farkını hesapla
            DateTime baslangicSaati = DateTime.ParseExact(baslangicSaatiText, "HH:mm", null);
            DateTime bitisSaati = DateTime.ParseExact(bitisSaatiText, "HH:mm", null);
            TimeSpan calismaSuresi = bitisSaati - baslangicSaati;

            // Mesai tutarını hesapla
            double mesaiTutari = calismaSuresi.TotalHours * mesaiSaatUcreti;

            if (tcKimlikNo.Length == 11)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO mesai_islemleri (personel_tc, mesai_saat_ucreti, mesai_tutarı, mesai_acıklama, baslangıç_saati, bitiş_saati, mesai_tarihi) " +
                            "VALUES (@TCKimlikNo, @MesaiSaatUcreti, @MesaiTutarı, @Mesai_Acıklama, @BaslangicSaati, @BitisSaati, @MesaiTarihi)";
                        MySqlCommand cmdInsert = new MySqlCommand(insertQuery, connection);
                        cmdInsert.Parameters.AddWithValue("@TCKimlikNo", tcKimlikNo);
                        cmdInsert.Parameters.AddWithValue("@MesaiSaatUcreti", mesaiSaatUcreti);
                        cmdInsert.Parameters.AddWithValue("@MesaiTutarı", mesaiTutari);
                        cmdInsert.Parameters.AddWithValue("@Mesai_Acıklama", mesaiAcıklama);
                        cmdInsert.Parameters.AddWithValue("@MesaiTarihi", mesaiTarihi);

                        // DateTime nesnesini MySQL datetime formatına çevir
                        cmdInsert.Parameters.AddWithValue("@BaslangicSaati", baslangicSaati.ToString("HH:mm:ss"));
                        cmdInsert.Parameters.AddWithValue("@BitisSaati", bitisSaati.ToString("HH:mm:ss"));

                        cmdInsert.ExecuteNonQuery();

                        // Hesaplanan tutarı hem veritabanına ekledik hem de textbox'a yazdık
                        txtMesaiTutarı.Text = mesaiTutari.ToString();

                        MessageBox.Show("Mesai kaydı başarıyla eklendi.");
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

        private void MesaiEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
