using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PDKS6.Formlar
{
    public partial class Mesaiİşlemleri : Form
    {
        private string connectionString = "server=localhost;user=root;password=root;database=pdks;";

        public Mesaiİşlemleri()
        {
            InitializeComponent();
        }

        private void Mesaiİşlemleri_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void FillDataGridView()
        {
            string query = "SELECT mi.Mesai_ID AS 'Mesai ID', p.ad AS 'Personel AD', mi.personel_tc AS 'TC Kimlik No', mi.mesai_saat_ucreti AS 'Mesai Saat Ücreti', mi.mesai_tutarı AS 'Mesai Tutarı', mi.mesai_acıklama AS 'Açıklama', mi.baslangıç_saati AS 'Başlangıç Saati', mi.bitiş_saati AS 'Bitiş Saati', mi.mesai_tarihi AS 'Mesai Tarihi' FROM mesai_islemleri mi INNER JOIN personel p ON mi.personel_tc = mi.personel_tc";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtMesaiID.Text = row.Cells["Mesai ID"].Value.ToString();
                txtAdSoyad.Text = row.Cells["Personel AD"].Value.ToString();
                txtTc.Text = row.Cells["TC Kimlik No"].Value.ToString();
                txtSaatUcreti.Text = row.Cells["Mesai Saat Ücreti"].Value.ToString();
                txtTutar.Text = row.Cells["Mesai Tutarı"].Value.ToString();
                textBox6.Text = row.Cells["Açıklama"].Value.ToString();
                maskedbaşlangıç.Text = row.Cells["Başlangıç Saati"].Value.ToString();
                maskedbitiş.Text = row.Cells["Bitiş Saati"].Value.ToString();

                // dateTimePicker1'in değerini de set edelim
                // dateTimePicker1.Value = DateTime.ParseExact(row.Cells["Mesai Tarihi"].Value.ToString(),"dd.MM.yyyy",CultureInfo.InvariantCulture);
                try
                {
                    string mesaiTarihiStr = row.Cells["Mesai Tarihi"].Value.ToString();
                    DateTime mesaiTarihi = DateTime.ParseExact(mesaiTarihiStr, "yyyy.MM.dd", CultureInfo.InvariantCulture);
                    dateTimePicker1.Value = mesaiTarihi;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tarih dönüşümünde hata oluştu: " + ex.Message);
                }
            }
        
            MessageBox.Show("Tıklandı");
        }

        private void btn_mesaiGüncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMesaiID.Text))
            {
                MessageBox.Show("Lütfen bir mesai kaydı seçin.");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE mesai_islemleri SET mesai_saat_ucreti = @saat_ucreti, mesai_tutarı = @mesai_tutarı, mesai_acıklama = @aciklama, baslangıç_saati = @baslangic_saati, bitiş_saati = @bitis_saati WHERE Mesai_ID = @mesai_id";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        double saatUcreti = Convert.ToDouble(txtSaatUcreti.Text);

                        DateTime baslangicSaati = DateTime.ParseExact(maskedbaşlangıç.Text, "HH:mm", CultureInfo.InvariantCulture);
                        DateTime bitisSaati = DateTime.ParseExact(maskedbitiş.Text, "HH:mm", CultureInfo.InvariantCulture);
                        TimeSpan calisilanSure = bitisSaati - baslangicSaati;
                        double calisilanSaat = calisilanSure.TotalHours;
                        double tutar = saatUcreti * calisilanSaat;


                        command.Parameters.AddWithValue("@saat_ucreti", saatUcreti);
                        command.Parameters.AddWithValue("@mesai_tutarı", tutar);
                        command.Parameters.AddWithValue("@aciklama", textBox6.Text);
                        command.Parameters.AddWithValue("@baslangic_saati", baslangicSaati);
                        command.Parameters.AddWithValue("@bitis_saati", bitisSaati);
                        command.Parameters.AddWithValue("@mesai_id", txtMesaiID.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Mesai kaydı güncellendi.");
                            FillDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Mesai kaydı güncellenemedi.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        /*private void txtTutar(object sender, EventArgs e)
        {
            CalculateTutar();
        }*/
        private void txtSaatUcreti_TextChanged(object sender, EventArgs e)
        {
            CalculateTutar();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CalculateTutar();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            CalculateTutar();
        }

        private void CalculateTutar()
        {
            if (double.TryParse(txtSaatUcreti.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double saatUcreti))
            {
                if (maskedbaşlangıç.MaskCompleted && maskedbitiş.MaskCompleted)
                {
                    DateTime baslangicSaati = DateTime.ParseExact(maskedbaşlangıç.Text, "HH:mm", CultureInfo.InvariantCulture);
                    DateTime bitisSaati = DateTime.ParseExact(maskedbitiş.Text, "HH:mm", CultureInfo.InvariantCulture);

                    TimeSpan calisilanSure = bitisSaati - baslangicSaati;
                    double calisilanSaat = calisilanSure.TotalHours;

                    double tutar = saatUcreti * calisilanSaat;
                    txtTutar.Text = tutar.ToString("F2", CultureInfo.InvariantCulture);
                }
                else
                {
                    txtTutar.Clear();
                }
            }
        }



        private void btn_mesaiÖde_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMesaiID.Text))
            {
                MessageBox.Show("Lütfen bir mesai kaydı seçin.");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE mesai_islemleri SET durum = CASE WHEN durum = 'Ödendi' THEN 'Ödenmedi' ELSE 'Ödendi' END WHERE Mesai_ID = @mesai_id";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@mesai_id", txtMesaiID.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Mesai kaydının durumu güncellendi.");
                            FillDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Mesai kaydının durumu güncellenemedi.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btn_mesaiSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMesaiID.Text))
            {
                MessageBox.Show("Lütfen bir mesai kaydı seçin.");
                return;
            }

            DialogResult result = MessageBox.Show("Seçili mesai kaydını silmek istediğinizden emin misiniz?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM mesai_islemleri WHERE Mesai_ID = @mesai_id";

                        using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@mesai_id", txtMesaiID.Text);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Mesai kaydı silindi.");
                                ClearFields();
                                FillDataGridView();
                            }
                            else
                            {
                                MessageBox.Show("Mesai kaydı silinemedi.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void ClearFields()
        {
            txtMesaiID.Clear();
            txtAdSoyad.Clear();
            txtTc.Clear();
            txtSaatUcreti.Clear();
            txtTutar.Clear();
            textBox6.Clear();
            maskedbaşlangıç.Text = DateTime.Now.ToString("HH:mm");
            maskedbitiş.Text = DateTime.Now.ToString("HH:mm");
        }
            private void btn_tümMesaileriÖde_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tüm mesai kayıtlarını ödendi olarak işaretleme isteğinizden emin misiniz?", "Tüm Mesai Kayıtlarını Öde", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string updateQuery = "UPDATE mesai_islemleri SET durum = 'Ödendi'";

                        using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Tüm mesai kayıtları ödendi olarak güncellendi.");
                                FillDataGridView();
                            }
                            else
                            {
                                MessageBox.Show("Tüm mesai kayıtları güncellenemedi.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

    }
}
