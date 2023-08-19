using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PDKS6.Formlar
{
    public partial class FromGirisCıkıs : Form
    {
        private string connectionString = "Server=localhost;Database=pdks;Uid=root;Pwd=root;";
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        public FromGirisCıkıs()
        {
            InitializeComponent();
            VeritabaniHazirla();
            VerileriYukle();
        }

        private void VeritabaniHazirla()
        {
            connection = new MySqlConnection(connectionString);
            command = new MySqlCommand();
            adapter = new MySqlDataAdapter(command);
            dataTable = new DataTable();
            command.Connection = connection;
        }

        private void VerileriYukle()
        {
            try
            {
                connection.Open();

                // Verilerin alınacağı tabloya göre "tablo_adi" kısmını güncelleyin
                command.CommandText = "SELECT * FROM giriş_çıkış";
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void FromGirisCıkıs_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Dispose();
            command.Dispose();
            adapter.Dispose();
        }

        private void btn_bul_Click(object sender, EventArgs e)
        {
            string tcKimlikNo = txtTCKimlikNo.Text;

            if (!string.IsNullOrEmpty(tcKimlikNo))
            {
                dataGridView1.ClearSelection();

                int rowIndex = -1;
                bool kullaniciBulundu = false;

                // TC Kimlik No sütununun indeksine göre veriyi bulma
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    object cellValue = dataGridView1.Rows[i].Cells["tc_kimlik_no"].Value;
                    if (cellValue != null && cellValue.ToString() == tcKimlikNo)
                    {
                        rowIndex = i;
                        kullaniciBulundu = true;
                        break;
                    }
                }

                if (kullaniciBulundu)
                {
                    dataGridView1.Rows[rowIndex].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = rowIndex;
                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir TC Kimlik No girin.");
            }
        }



    }
}
