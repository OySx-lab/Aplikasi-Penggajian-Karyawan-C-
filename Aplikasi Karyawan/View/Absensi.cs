using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Aplikasi_Karyawan
{
    public partial class Absensi : Form
    {
        public Absensi()
        {
            InitializeComponent();
            LoadNamaKaryawan();
            LoadDataAbsensi();
        }

        private Dictionary<string, string> karyawanJabatanDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> karyawanDictionary = new Dictionary<string, string>();
        private List<Absensi> manuallyAddedRows = new List<Absensi>();
        private void LoadNamaKaryawan()
        {
            string connectionString = @"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT NamaKaryawan, NIK FROM DataKaryawan";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string namaKaryawan = reader["NamaKaryawan"].ToString();
                        string nik = reader["NIK"].ToString();
                        cbNama.Items.Add(namaKaryawan);
                        if (!karyawanDictionary.ContainsKey(namaKaryawan))
                        {
                            karyawanDictionary[namaKaryawan] = nik;
                        }
                    }
                    if (cbNama.Items.Count > 0)
                    {
                        cbNama.SelectedIndex = 0;
                        UpdateNIK();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengambil data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateNIK()
        {
            string selectedNama = cbNama.Text;

            if (karyawanDictionary.ContainsKey(selectedNama))
            {
                txtNIK.Text = karyawanDictionary[selectedNama];
            }
        }

        private void LoadDataAbsensi()
        {
            string connectionString = @"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True";
            string query = @"SELECT 
                        dk.NamaKaryawan AS Nama, 
                        da.NIK,
                        da.Tanggal, 
                        da.JamMasuk, 
                        da.JamKeluar 
                      FROM DataAbsensi da
                      INNER JOIN DataKaryawan dk ON da.NIK = dk.NIK
                      ORDER BY da.Tanggal DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvTampilan.DataSource = dt;

                        dgvTampilan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvTampilan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAbsensiToDatabase(Karyawan karyawan)
        {
            string connectionString = @"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True";
            string query = @"INSERT INTO DataAbsensi (NIK, Tanggal, JamMasuk, JamKeluar) 
                        VALUES (@NIK, @Tanggal, @JamMasuk, @JamKeluar)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    string verifyQuery = "SELECT COUNT(*) FROM DataKaryawan WHERE NIK = @NIK";
                    SqlCommand verifyCommand = new SqlCommand(verifyQuery, connection);
                    verifyCommand.Parameters.AddWithValue("@NIK", karyawan.NIK);

                    try
                    {
                        connection.Open();
                        int exists = (int)verifyCommand.ExecuteScalar();
                        if (exists == 0)
                        {
                            throw new Exception("NIK tidak ditemukan dalam database karyawan.");
                        }
                        command.Parameters.AddWithValue("@NIK", karyawan.NIK);
                        command.Parameters.AddWithValue("@Tanggal", karyawan.Tanggal);
                        command.Parameters.AddWithValue("@JamMasuk", karyawan.JamMasuk);
                        command.Parameters.AddWithValue("@JamKeluar", karyawan.JamKeluar);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error menyimpan ke database: " + ex.Message);
                    }
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNIK.Text) || cbNama.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtJamMasuk.Text) || string.IsNullOrWhiteSpace(txtJamKeluar.Text))
                {
                    MessageBox.Show("Harap isi semua data sebelum menyimpan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!TimeSpan.TryParse(txtJamMasuk.Text, out TimeSpan jamMasuk) ||
                    !TimeSpan.TryParse(txtJamKeluar.Text, out TimeSpan jamKeluar))
                {
                    MessageBox.Show("Format waktu tidak valid. Harap gunakan format HH:mm:ss.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!karyawanDictionary.ContainsKey(cbNama.Text) ||
                    karyawanDictionary[cbNama.Text] != txtNIK.Text)
                {
                    MessageBox.Show("NIK tidak sesuai dengan nama karyawan yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Karyawan newKaryawan = new Karyawan
                {
                    NIK = txtNIK.Text,
                    NamaKaryawan = cbNama.Text,
                    Tanggal = DateTime.Now,
                    JamMasuk = jamMasuk,
                    JamKeluar = jamKeluar
                };

                SaveAbsensiToDatabase(newKaryawan);
                MessageBox.Show("Data absensi berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataAbsensi();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtNIK.Clear();
            cbNama.SelectedIndex = -1;
            txtJamMasuk.Clear();
            txtJamKeluar.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvTampilan.SelectedRows.Count == 0 && dgvTampilan.SelectedCells.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus terlebih dahulu.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow row;
            if (dgvTampilan.SelectedRows.Count > 0)
            {
                row = dgvTampilan.SelectedRows[0];
            }
            else
            {
                row = dgvTampilan.SelectedCells[0].OwningRow;
            }

            string nik = row.Cells["NIK"].Value.ToString();
            string nama = row.Cells["Nama"].Value.ToString();
            DialogResult result = MessageBox.Show(
                $"Anda yakin ingin menghapus data absensi untuk:\nNama: {nama}\nNIK: {nik}?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    string connectionString = @"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True";
                    string query = @"DELETE FROM DataAbsensi 
                           WHERE NIK = @NIK";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@NIK", nik);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data absensi berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadDataAbsensi();
                            }
                            else
                            {
                                MessageBox.Show("Data tidak ditemukan atau gagal dihapus.", "Peringatan",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat menghapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadDataAbsensi();
                return;
            }

            string connectionString = @"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True";
            string query = @"SELECT 
                    dk.NamaKaryawan AS Nama, 
                    da.NIK,
                    da.Tanggal, 
                    da.JamMasuk, 
                    da.JamKeluar 
                    FROM DataAbsensi da
                    INNER JOIN DataKaryawan dk ON da.NIK = dk.NIK
                    WHERE dk.NamaKaryawan LIKE @SearchTerm
                    ORDER BY da.Tanggal DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                    {
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                        DataTable searchResults = new DataTable();
                        dataAdapter.Fill(searchResults);
                        if (searchResults.Rows.Count > 0)
                        {
                            dgvTampilan.DataSource = searchResults;
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mencari data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbNama_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNIK();
        }

        private void UpdateDataAbsensi(string nik, DateTime tanggal, string jamMasuk, string jamKeluar)
        {
            string connectionString = @"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True";
            string query = @"UPDATE DataAbsensi 
                     SET Tanggal = @Tanggal, 
                         JamMasuk = @JamMasuk, 
                         JamKeluar = @JamKeluar 
                     WHERE NIK = @NIK";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NIK", nik);
                        command.Parameters.AddWithValue("@Tanggal", tanggal);
                        command.Parameters.AddWithValue("@JamMasuk", jamMasuk);
                        command.Parameters.AddWithValue("@JamKeluar", jamKeluar);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memperbarui data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTampilan.SelectedRows.Count == 0 && dgvTampilan.SelectedCells.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan diedit terlebih dahulu.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row;
            if (dgvTampilan.SelectedRows.Count > 0)
            {
                row = dgvTampilan.SelectedRows[0];
            }
            else
            {
                row = dgvTampilan.SelectedCells[0].OwningRow;
            }

            // Ambil data dari baris yang dipilih
            DateTime tanggal = Convert.ToDateTime(row.Cells["Tanggal"].Value);
            string jamMasuk = row.Cells["JamMasuk"].Value.ToString();
            string jamKeluar = row.Cells["JamKeluar"].Value.ToString();

            // Tampilkan form edit dengan data
            using (EditAbsensi editForm = new EditAbsensi(tanggal, jamMasuk, jamKeluar))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Update data di database
                    UpdateDataAbsensi(row.Cells["NIK"].Value.ToString(), editForm.Tanggal, editForm.JamMasuk, editForm.JamKeluar);

                    // Refresh tampilan
                    LoadDataAbsensi();
                }
            }
        }
    }
}