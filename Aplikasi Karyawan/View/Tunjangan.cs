using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace Aplikasi_Karyawan
{
    public partial class Tunjangan : Form
    {
        private string connectionString = @"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True";
        private System.Windows.Forms.TextBox txtGajiAkhir;

        public Tunjangan()
        {
            InitializeComponent();
          
        }

        private void InputDataGaji_Load(object sender, EventArgs e)
        {
            // Background Text menjadi Transparant
            label1.Parent = this;
            label1.BackColor = Color.Transparent;

            LoadNamaKaryawan();
        }

        private Dictionary<string, string> karyawanJabatanDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> karyawanDictionary = new Dictionary<string, string>();

        private void LoadNamaKaryawan()
        {
            string connectionString = @"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT Nama, GajiAkhir FROM DataAbsensi";  // Query updated to fetch only NamaKaryawan

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear any existing items before loading
                    cbNama.Items.Clear();

                    while (reader.Read())
                    {
                        string namaKaryawan = reader["Nama"].ToString();

                        // Check if GajiAkhir is DBNull before converting
                        decimal gajiAkhir = reader["GajiAkhir"] != DBNull.Value ? Convert.ToDecimal(reader["GajiAkhir"]) : 0;

                        // Add employee name to ComboBox
                        cbNama.Items.Add(namaKaryawan);

                        // Store GajiAkhir in the dictionary
                        if (!karyawanDictionary.ContainsKey(namaKaryawan))
                        {
                            karyawanDictionary[namaKaryawan] = gajiAkhir.ToString();  // You can store as string or use decimal type
                        }
                    }

                    // Set default selected item
                    if (cbNama.Items.Count > 0)
                    {
                        cbNama.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengambil data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbNama_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKaryawan = cbNama.SelectedItem.ToString();

            string query = "SELECT GajiAkhir FROM DataAbsensi WHERE Nama = @Nama";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nama", selectedKaryawan);
                    connection.Open();

                    object result = command.ExecuteScalar();

                    decimal gajiAkhir = 0;
                    if (result != DBNull.Value && result != null)
                    {
                        gajiAkhir = Convert.ToDecimal(result);
                    }

                    // Continue with other operations...
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memperbarui data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void btnTotalGaji_Click(object sender, EventArgs e)
        {
            string selectedKaryawan = cbNama.SelectedItem.ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();  // Pastikan koneksi dibuka

                    // Query untuk mendapatkan GajiAkhir dari karyawan yang dipilih
                    string query = "SELECT GajiAkhir FROM DataAbsensi WHERE Nama = @Nama";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nama", selectedKaryawan);

                    // Mendapatkan GajiAkhir
                    object result = command.ExecuteScalar();
                    decimal gajiAkhir = 0;
                    if (result != DBNull.Value && result != null)
                    {
                        gajiAkhir = Convert.ToDecimal(result); // Mengkonversi menjadi decimal
                    }

                    decimal totalAllowance = 0;

                    // Mengupdate GajiAkhir
                    decimal newGajiAkhir = gajiAkhir + totalAllowance;

                    // Mengupdate kolom GajiAkhir di database
                    string updateQuery = "UPDATE DataAbsensi SET GajiAkhir = @NewGajiAkhir WHERE Nama = @Nama";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@NewGajiAkhir", newGajiAkhir);
                    updateCommand.Parameters.AddWithValue("@Nama", selectedKaryawan);

                    // Pastikan perintah SQL dieksekusi setelah koneksi dibuka
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Gagal memperbarui data. Pastikan data karyawan tersedia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Menambahkan data ke DataGridView
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Nama Karyawan");
                    dt.Columns.Add("Gaji Akhir");

                    // Menambahkan nama karyawan dan gaji yang sudah diperbarui ke DataTable
                    dt.Rows.Add(selectedKaryawan, newGajiAkhir);

                    // Menghubungkan DataTable ke DataGridView
    
                    // Menampilkan GajiAkhir yang telah diperbarui
                    MessageBox.Show($"Total Gaji setelah tunjangan: {newGajiAkhir:C}", "Gaji Terbaru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memperbarui gaji: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Pastikan ada nama yang dipilih
            if (cbNama.SelectedIndex != -1)
            {
                string selectedKaryawan = cbNama.SelectedItem.ToString();

                // Query untuk mendapatkan data karyawan
                string query = "SELECT GajiAkhir, Transport, THR, Makan, Lembur FROM DataAbsensi WHERE Nama = @Nama";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Nama", selectedKaryawan);
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // Mengambil nilai yang ada di database
                            decimal gajiAkhir = Convert.ToDecimal(reader["GajiAkhir"]);
                            bool transportChecked = Convert.ToBoolean(reader["Transport"]);
                            bool thrChecked = Convert.ToBoolean(reader["THR"]);
                            bool makanChecked = Convert.ToBoolean(reader["Makan"]);
                            bool lemburChecked = Convert.ToBoolean(reader["Lembur"]);

                            // Set nilai pada kontrol form
                            txtGajiAkhir.Text = gajiAkhir.ToString("C");
                            cbTransport.Checked = transportChecked;
                            cbTHR.Checked = thrChecked;
                            cbMakan.Checked = makanChecked;
                            cbLembur.Checked = lemburChecked;
                        }
                        else
                        {
                            MessageBox.Show("Data karyawan tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pilih nama karyawan terlebih dahulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Pastikan txtGajiAkhir tidak null
                if (txtGajiAkhir != null && !string.IsNullOrEmpty(txtGajiAkhir.Text))
                {
                    decimal gajiAkhir;
                    if (decimal.TryParse(txtGajiAkhir.Text, out gajiAkhir))
                    {
                        // Lanjutkan jika parsing berhasil
                        string selectedKaryawan = cbNama.SelectedItem.ToString();
                        string query = "UPDATE DataAbsensi SET GajiAkhir = @NewGajiAkhir WHERE Nama = @Nama";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@NewGajiAkhir", gajiAkhir);
                            command.Parameters.AddWithValue("@Nama", selectedKaryawan);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                MessageBox.Show("Gagal memperbarui data. Pastikan data karyawan tersedia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Data berhasil diperbarui.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Masukkan Gaji Akhir yang valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Gaji Akhir belum diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
