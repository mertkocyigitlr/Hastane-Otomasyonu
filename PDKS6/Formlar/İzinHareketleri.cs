using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDKS6.Formlar
{
    public partial class İzinHareketleri : Form
    {
        private int seciliSatirIndex = -1; // Seçili satırın indeksini tutmak için

        private string connectionString = "Server=localhost;Database=pdks;Uid=root;Pwd=root;";

        public İzinHareketleri()
        {
            InitializeComponent();
            VerileriCek();
        }
        private bool IsValidKimlikNo(string kimlikNo)
        {
            return kimlikNo.Length == 11 && kimlikNo.All(char.IsDigit);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txt_acıklama.Text = "Ücretli İzin Seçildi";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                txt_acıklama.Text = "Ücretsiz İzin Seçildi";
            }
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    if (!IsValidKimlikNo(txtkimlik.Text))
                    {
                        MessageBox.Show("Geçerli bir kimlik numarası giriniz (11 haneli ve sadece rakamlar).");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtkimlik.Text) || string.IsNullOrWhiteSpace(cmb_ızınAdı.Text) || string.IsNullOrWhiteSpace(txt_acıklama.Text))
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurun.");
                        return;
                    }

                    string insertQuery = "INSERT INTO ızınhareketleri (tc_kimlik_no, ızın_adı, baslangic_tarihi, bitis_tarihi, acıklama) VALUES (@tc_kimlik_no, @ızın_adı, @baslangic_tarihi, @bitis_tarihi, @acıklama)";

                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@tc_kimlik_no", txtkimlik.Text);
                    command.Parameters.AddWithValue("@ızın_adı", cmb_ızınAdı.Text);
                    command.Parameters.AddWithValue("@baslangic_tarihi", dtp_başlangıç.Value);
                    command.Parameters.AddWithValue("@bitis_tarihi", dtp_bitiş.Value);
                    command.Parameters.AddWithValue("@acıklama", txt_acıklama.Text);

                    int etkilenenSatirSayisi = command.ExecuteNonQuery();

                    if (etkilenenSatirSayisi > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla eklendi.");
                        VerileriCek();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt eklenemedi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void VerileriCek()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectQuery = "SELECT IZIN_ID AS 'İzin ID', tc_kimlik_no AS 'Kimlik No', ızın_adı AS 'İzin Adı', baslangic_tarihi AS 'Başlangıç Tarihi', bitis_tarihi AS 'Bitiş Tarihi', acıklama AS 'Açıklama' FROM ızınhareketleri";
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekme hatası: " + ex.Message);
                }
            }
        }

        // DataGridView hücresine tıklandığında
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (selectedCell != null && !selectedCell.ReadOnly)
                {
                    txtkimlik.Text = dataGridView1.Rows[e.RowIndex].Cells["Kimlik No"].Value.ToString();
                    cmb_ızınAdı.Text = dataGridView1.Rows[e.RowIndex].Cells["İzin Adı"].Value.ToString();
                    dtp_başlangıç.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["Başlangıç Tarihi"].Value);
                    dtp_bitiş.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["Bitiş Tarihi"].Value);
                    txt_acıklama.Text = dataGridView1.Rows[e.RowIndex].Cells["Açıklama"].Value.ToString();
                }
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    if (string.IsNullOrWhiteSpace(cmb_ızınAdı.Text) || string.IsNullOrWhiteSpace(txt_acıklama.Text))
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurun.");
                        return;
                    }

                    string updateQuery = "UPDATE ızınhareketleri SET ızın_adı = @ızın_adı, baslangic_tarihi = @baslangic_tarihi, bitis_tarihi = @bitis_tarihi, acıklama = @acıklama WHERE IZIN_ID = @izin_id";

                    MySqlCommand command = new MySqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@ızın_adı", cmb_ızınAdı.Text);
                    command.Parameters.AddWithValue("@baslangic_tarihi", dtp_başlangıç.Value);
                    command.Parameters.AddWithValue("@bitis_tarihi", dtp_bitiş.Value);
                    command.Parameters.AddWithValue("@acıklama", txt_acıklama.Text);
                    command.Parameters.AddWithValue("@izin_id", dataGridView1.CurrentRow.Cells["İzin ID"].Value);

                    int etkilenenSatirSayisi = command.ExecuteNonQuery();

                    if (etkilenenSatirSayisi > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla güncellendi.");
                        VerileriCek();
                        txtkimlik.Clear();
                        cmb_ızınAdı.SelectedIndex = -1;
                        dtp_başlangıç.Value = DateTime.Now;
                        dtp_bitiş.Value = DateTime.Now;
                        txt_acıklama.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt güncellenemedi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }


        private void btn_sil_Click(object sender, EventArgs e)
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
                            string izin_id = selectedRow.Cells["İzin ID"].Value.ToString();

                            string deleteQuery = "DELETE FROM ızınhareketleri WHERE IZIN_ID = @izin_id";

                            MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, connection);
                            cmdDelete.Parameters.AddWithValue("@izin_id", izin_id);
                            int etkilenenSatirSayisi = cmdDelete.ExecuteNonQuery();

                            if (etkilenenSatirSayisi > 0)
                            {
                                MessageBox.Show("Kişi silindi.");
                                VerileriCek();
                            }
                            else
                            {
                                MessageBox.Show("Kişi silinemedi.");
                            }
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
