    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SqlClient;
using System.Globalization;
using Aplikasi_Karyawan;
using System.Web;


namespace Aplikasi_Karyawan
    {
    public partial class Gaji : Form
    {
        private readonly string connectionString = @"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True";
        private readonly BindingList<Karyawan> bindingKaryawanList = new BindingList<Karyawan>();
        private readonly Dictionary<string, string> karyawanDictionary = new Dictionary<string, string>();
        private readonly Dictionary<string, string> karyawanJabatanDictionary = new Dictionary<string, string>();
        private Karyawan tempKaryawan;

        public Gaji()
        {
            InitializeComponent();
            InitializeMonthComboBox();
            btnSimpan.Text = "Simpan";
        }

        private void InitializeMonthComboBox()
        {
            cbBulan.Items.AddRange(new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            cbBulan.SelectedIndex = 0;
        }

        private void UpdateAbsensiToDatabase(Karyawan karyawan)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE DataGaji SET 
            NamaKaryawan = @NamaKaryawan,
            Bulan = @Bulan,
            JumlahHariKerja = @JumlahHariKerja,
            Alpa = @Alpa,
            Telat = @Telat,
            Izin = @Izin,
            JumlahJamLembur = @JumlahJamLembur,
            GajiLembur = @GajiLembur,
            GajiPokok = @GajiPokok,
            TunjanganJabatan = @TunjanganJabatan,
            TunjanganMakan = @TunjanganMakan,
            TunjanganTransportasi = @TunjanganTransportasi,
            PotonganAlfa = @PotonganAlfa,
            GajiBersih = @GajiBersih
            WHERE NIK = @NIK";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NIK", karyawan.NIK);
                    command.Parameters.AddWithValue("@NamaKaryawan", karyawan.NamaKaryawan);
                    command.Parameters.AddWithValue("@Bulan", karyawan.Bulan);
                    command.Parameters.AddWithValue("@JumlahHariKerja", karyawan.JumlahHariKerja);
                    command.Parameters.AddWithValue("@Alpa", karyawan.Alpa);
                    command.Parameters.AddWithValue("@Telat", karyawan.Telat);
                    command.Parameters.AddWithValue("@Izin", karyawan.Izin);
                    command.Parameters.AddWithValue("@JumlahJamLembur", karyawan.JumlahJamLembur);
                    command.Parameters.AddWithValue("@GajiLembur", karyawan.GajiLembur);
                    command.Parameters.AddWithValue("@GajiPokok", karyawan.GajiPokok);
                    command.Parameters.AddWithValue("@TunjanganJabatan", karyawan.TunjanganJabatan);
                    command.Parameters.AddWithValue("@TunjanganMakan", karyawan.TunjanganMakan);
                    command.Parameters.AddWithValue("@TunjanganTransportasi", karyawan.TunjanganTransportasi);
                    command.Parameters.AddWithValue("@PotonganAlfa", karyawan.PotonganAlfa);
                    command.Parameters.AddWithValue("@GajiBersih", karyawan.GajiBersih);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateNIK()
        {
            string selectedNama = cbNama.Text;

            if (karyawanDictionary.ContainsKey(selectedNama))
            {
                txtNIK.Text = karyawanDictionary[selectedNama];
            }
            else
            {
                MessageBox.Show("Nama karyawan tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string jabat;
        private void UpdateJabatan()
        {
            if (cbNama.SelectedItem != null)
            {
                string namaKaryawan = cbNama.SelectedItem.ToString();
                
                if (karyawanJabatanDictionary.TryGetValue(namaKaryawan, out string jabatan))
                {
                    jabat = jabatan; 
                }
                else
                {
                    txtJabatan.Text = "Tidak Dikenal"; 
                }
            }
        }

        private void DeleteAbsensiFromDatabase(string nik)
        {
            try
            {
                using (SqlConnection koneksi = new SqlConnection(
                    @"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True"))
                {
                    koneksi.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM DataGaji WHERE NIK = @NIK", koneksi);
                    cmd.Parameters.AddWithValue("@NIK", nik);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus data absensi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int ParseCurrencyValue(string currencyText)
        {
            // Hapus format currency (Rp dan tanda titik ribuan)
            string numericString = currencyText.Replace("Rp", "")
                                             .Replace(".", "")
                                             .Replace(",00", "")
                                             .Trim();

            if (int.TryParse(numericString, out int result))
            {
                return result;
            }
            return 0;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (tempKaryawan == null)
                {
                    tempKaryawan = new Karyawan();
                }

                // Update nilai tempKaryawan dengan data terbaru dari form
                tempKaryawan.NIK = txtNIK.Text;
                tempKaryawan.NamaKaryawan = cbNama.Text;
                tempKaryawan.Bulan = cbBulan.Text;
                tempKaryawan.JumlahHariKerja = int.Parse(cbHariKerja.Text);
                tempKaryawan.Alpa = (int)numAlpa.Value;
                tempKaryawan.Izin = (int)numIzin.Value;
                tempKaryawan.Telat = (int)numTelat.Value;
                tempKaryawan.JumlahJamLembur = (int)numJamLembur.Value;

                // Ambil nilai dari textbox dan konversi dari format currency
                tempKaryawan.GajiPokok = ParseCurrencyValue(txtGajiPokok.Text);
                tempKaryawan.GajiLembur = ParseCurrencyValue(txtGajiLembur.Text);
                tempKaryawan.TunjanganJabatan = ParseCurrencyValue(txtJabatan.Text);
                tempKaryawan.TunjanganMakan = ParseCurrencyValue(txtMakan.Text);
                tempKaryawan.TunjanganTransportasi = ParseCurrencyValue(txtTransportasi.Text);
                tempKaryawan.PotonganAlfa = ParseCurrencyValue(txtPotonganAlfa.Text);
                tempKaryawan.GajiBersih = ParseCurrencyValue(txtGajiBersih.Text);

                if (isEditing)
                {
                    // Update existing data
                    UpdateAbsensiToDatabase(tempKaryawan);

                    // Update the DataGridView
                    var index = bindingKaryawanList.IndexOf(
                        bindingKaryawanList.FirstOrDefault(k => k.NIK == tempKaryawan.NIK));
                    if (index != -1)
                    {
                        bindingKaryawanList[index] = tempKaryawan;
                    }

                    MessageBox.Show("Data berhasil diupdate!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isEditing = false; // Reset editing flag
                }
                else
                {
                    // Save new data
                    SaveToDatabase(tempKaryawan);
                    bindingKaryawanList.Add(tempKaryawan);
                    MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ResetForm();
                LoadAbsensiData(); // Refresh data
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveToDatabase(Karyawan karyawan)
        {
            const string query = @"INSERT INTO DataGaji 
        (NIK, NamaKaryawan, Bulan, JumlahHariKerja, Alpa, Telat, Izin, JumlahJamLembur, GajiLembur, GajiPokok, TunjanganJabatan, TunjanganMakan, TunjanganTransportasi, PotonganAlfa, GajiBersih) 
        VALUES 
        (@NIK, @NamaKaryawan, @Bulan, @JumlahHariKerja, @Alpa, @Telat, @Izin, @JumlahJamLembur, @GajiLembur, @GajiPokok, @TunjanganJabatan, @TunjanganMakan, @TunjanganTransportasi, @PotonganAlfa, @GajiBersih)";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NIK", karyawan.NIK);
                    command.Parameters.AddWithValue("@NamaKaryawan", karyawan.NamaKaryawan);
                    command.Parameters.AddWithValue("@Bulan", karyawan.Bulan);
                    command.Parameters.AddWithValue("@JumlahHariKerja", karyawan.JumlahHariKerja);
                    command.Parameters.AddWithValue("@Alpa", karyawan.Alpa); 
                    command.Parameters.AddWithValue("@Telat", karyawan.Telat);
                    command.Parameters.AddWithValue("@Izin", karyawan.Izin);
                    command.Parameters.AddWithValue("@JumlahJamLembur", karyawan.JumlahJamLembur);
                    command.Parameters.AddWithValue("@GajiLembur", karyawan.GajiLembur);
                    command.Parameters.AddWithValue("@GajiPokok", karyawan.GajiPokok);
                    command.Parameters.AddWithValue("@TunjanganJabatan", karyawan.TunjanganJabatan);
                    command.Parameters.AddWithValue("@TunjanganMakan", karyawan.TunjanganMakan);
                    command.Parameters.AddWithValue("@TunjanganTransportasi", karyawan.TunjanganTransportasi);
                    command.Parameters.AddWithValue("@PotonganAlfa", karyawan.PotonganAlfa);
                    command.Parameters.AddWithValue("@GajiBersih", karyawan.GajiBersih);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat menyimpan ke database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            cbBulan.SelectedIndex = -1; 
            numAlpa.Value = 0;
            numTelat.Value = 0;
            numIzin.Value = 0;
            numJamLembur.Value = 0;
            txtGajiPokok.Clear();        
            txtJabatan.Clear(); 
            txtMakan.Clear();   
            txtTransportasi.Clear();
            txtPotonganAlfa.Clear();     
            txtGajiBersih.Clear();      
            cbNama.Focus(); 
        }

        private void InputDataAbsensi_Load(object sender, EventArgs e)
        {
            if (!dgvAbsensi.Columns.Contains("NIK"))
            {
                DataGridViewTextBoxColumn nikColumn = new DataGridViewTextBoxColumn();
                nikColumn.Name = "NIK";
                nikColumn.HeaderText = "NIK";
                dgvAbsensi.Columns.Add(nikColumn);
            }

            for (int i = 1; i <= 31; i++)
            {
                cbHariKerja.Items.Add(i); 
            }

            cbHariKerja.SelectedIndex = 0;

            LoadNamaKaryawan();
            LoadAbsensiData(); 
            dgvAbsensi.DataSource = bindingKaryawanList;
            ConfigureDataGridView();
        }

        private void LoadAbsensiData()
        {
            string connectionString = @"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT NIK, NamaKaryawan, Bulan, JumlahHariKerja, Alpa, Telat, Izin, JumlahJamLembur, GajiLembur, GajiPokok, TunjanganJabatan, TunjanganMakan, TunjanganTransportasi, PotonganAlfa, GajiBersih FROM DataGaji";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    bindingKaryawanList.Clear();

                    while (reader.Read())
                    {
                        Karyawan karyawan = new Karyawan()
                        {
                            NIK = reader["NIK"].ToString(),
                            NamaKaryawan = reader["NamaKaryawan"].ToString(),
                            Bulan = reader["Bulan"].ToString(),
                            JumlahHariKerja = reader["JumlahHariKerja"] != DBNull.Value ? Convert.ToInt32(reader["JumlahHariKerja"]) : 0,
                            Alpa = reader["Alpa"] != DBNull.Value ? Convert.ToInt32(reader["Alpa"]) : 0,
                            Telat = reader["Telat"] != DBNull.Value ? Convert.ToInt32(reader["Telat"]) : 0,
                            Izin = reader["Izin"] != DBNull.Value ? Convert.ToInt32(reader["Izin"]) : 0,
                            JumlahJamLembur = reader["JumlahJamLembur"] != DBNull.Value ? Convert.ToInt32(reader["JumlahJamLembur"]) : 0,
                            GajiLembur = reader["GajiLembur"] != DBNull.Value ? Convert.ToInt32(reader["GajiLembur"]) : 0,
                            GajiPokok = reader["GajiPokok"] != DBNull.Value ? Convert.ToInt32(reader["GajiPokok"]) : 0,
                            TunjanganJabatan = reader["TunjanganJabatan"] != DBNull.Value ? Convert.ToInt32(reader["TunjanganJabatan"]) : 0,
                            TunjanganMakan = reader["TunjanganMakan"] != DBNull.Value ? Convert.ToInt32(reader["TunjanganMakan"]) : 0,
                            TunjanganTransportasi = reader["TunjanganTransportasi"] != DBNull.Value ? Convert.ToInt32(reader["TunjanganTransportasi"]) : 0,
                            PotonganAlfa = reader["PotonganAlfa"] != DBNull.Value ? Convert.ToInt32(reader["PotonganAlfa"]) : 0,
                            GajiBersih = reader["GajiBersih"] != DBNull.Value ? Convert.ToInt32(reader["GajiBersih"]) : 0
                        };

                        bindingKaryawanList.Add(karyawan);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengambil data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dgvAbsensi.Columns.Clear();
            dgvAbsensi.AutoGenerateColumns = false;

            // Kolom non-currency tetap sama
            dgvAbsensi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NIK", DataPropertyName = "NIK" });
            dgvAbsensi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nama Karyawan", DataPropertyName = "NamaKaryawan" });
            dgvAbsensi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Bulan", DataPropertyName = "Bulan" });
            dgvAbsensi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Jumlah Hari Kerja", DataPropertyName = "JumlahHariKerja" });
            dgvAbsensi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Alpa", DataPropertyName = "Alpa" });
            dgvAbsensi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Telat", DataPropertyName = "Telat" });
            dgvAbsensi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Izin", DataPropertyName = "Izin" });
            dgvAbsensi.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Jumlah Jam Lembur", DataPropertyName = "JumlahJamLembur" });

            // Kolom currency dengan format Rupiah
            var currencyColumns = new[]
            {
                new { HeaderText = "Gaji Lembur", PropertyName = "GajiLembur" },
                new { HeaderText = "Gaji Pokok", PropertyName = "GajiPokok" },
                new { HeaderText = "Tunjangan Jabatan", PropertyName = "TunjanganJabatan" },
                new { HeaderText = "Tunjangan Makan", PropertyName = "TunjanganMakan" },
                new { HeaderText = "Tunjangan Transportasi", PropertyName = "TunjanganTransportasi" },
                new { HeaderText = "Potongan Alfa", PropertyName = "PotonganAlfa" },
                new { HeaderText = "Gaji Bersih", PropertyName = "GajiBersih" }
            };

            foreach (var column in currencyColumns)
            {
                var currencyColumn = new DataGridViewTextBoxColumn
                {
                    HeaderText = column.HeaderText,
                    DataPropertyName = column.PropertyName,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C0",
                        FormatProvider = new System.Globalization.CultureInfo("id-ID")
                    }
                };
                dgvAbsensi.Columns.Add(currencyColumn);
            }

            dgvAbsensi.DataSource = bindingKaryawanList;
        }

        private void LoadNamaKaryawan()
        {
            const string query = "SELECT NamaKaryawan, NIK, Jabatan FROM DataKaryawan";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string namaKaryawan = reader["NamaKaryawan"].ToString();
                            string nik = reader["NIK"].ToString();
                            string jabatan = reader["Jabatan"].ToString();
                            cbNama.Items.Add(namaKaryawan);
                            if (!karyawanJabatanDictionary.ContainsKey(namaKaryawan))
                            {
                                karyawanJabatanDictionary[namaKaryawan] = jabatan;
                            }

                            if (!karyawanDictionary.ContainsKey(namaKaryawan))
                            {
                                karyawanDictionary[namaKaryawan] = nik;
                            }
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
                MessageBox.Show($"Error loading employee data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         private void btnHapus_Click(object sender, EventArgs e)
         {
            try
            {
                // Validasi apakah baris di DataGridView dipilih
                if (dgvAbsensi.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih data karyawan yang akan dihapus terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validasi apakah NIK telah diisi
                if (string.IsNullOrWhiteSpace(txtNIK.Text))
                {
                    MessageBox.Show("Pilih data karyawan yang akan dihapus terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dialogResult = MessageBox.Show(
                    "Apakah Anda yakin ingin menghapus data karyawan ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    string nik = txtNIK.Text;
                    DeleteAbsensiFromDatabase(nik);
                    var itemToRemove = bindingKaryawanList.FirstOrDefault(k => k.NIK == nik);
                    if (itemToRemove != null)
                    {
                        bindingKaryawanList.Remove(itemToRemove);
                    }
                    dgvAbsensi.DataSource = null;
                    dgvAbsensi.DataSource = bindingKaryawanList;
                    ResetForm();

                    MessageBox.Show("Data karyawan berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat menghapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi input tetap sama
                if (string.IsNullOrWhiteSpace(txtNIK.Text))
                {
                    MessageBox.Show("NIK harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbNama.SelectedItem == null || string.IsNullOrWhiteSpace(cbNama.Text) ||
                    cbBulan.SelectedItem == null || string.IsNullOrWhiteSpace(cbBulan.Text) ||
                    cbHariKerja.SelectedItem == null)
                {
                    MessageBox.Show("Semua field harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (numAlpa.Value < 0 || numTelat.Value < 0 || numIzin.Value < 0 || numJamLembur.Value < 0)
                {
                    MessageBox.Show("Input tidak boleh negatif!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tempKaryawan = new Karyawan
                {
                    NIK = txtNIK.Text,
                    NamaKaryawan = cbNama.Text,
                    Jabatan = jabat,
                    Bulan = cbBulan.Text,
                    JumlahHariKerja = int.Parse(cbHariKerja.SelectedItem.ToString()),
                    Alpa = (int)numAlpa.Value,
                    Telat = (int)numTelat.Value,
                    Izin = (int)numIzin.Value,
                    JumlahJamLembur = (int)numJamLembur.Value,
                };

                tempKaryawan.HitungGaji();

                // Hitung potongan alfa (misalnya 100000 per hari)
                tempKaryawan.PotonganAlfa = tempKaryawan.Alpa * 100000;

                // Hitung gaji bersih
                tempKaryawan.GajiBersih = tempKaryawan.GajiPokok +
                                         tempKaryawan.TunjanganJabatan +
                                         tempKaryawan.TunjanganMakan +
                                         tempKaryawan.TunjanganTransportasi +
                                         tempKaryawan.GajiLembur -
                                         tempKaryawan.PotonganAlfa;

                // Update textbox dengan format currency Indonesia (Rp)
                var culture = new System.Globalization.CultureInfo("id-ID");
                txtGajiPokok.Text = tempKaryawan.GajiPokok.ToString("C", culture);
                txtGajiLembur.Text = tempKaryawan.GajiLembur.ToString("C", culture);
                txtPotonganAlfa.Text = tempKaryawan.PotonganAlfa.ToString("C", culture);
                txtGajiBersih.Text = tempKaryawan.GajiBersih.ToString("C", culture);
                txtJabatan.Text = tempKaryawan.TunjanganJabatan.ToString("C", culture);
                txtMakan.Text = tempKaryawan.TunjanganMakan.ToString("C", culture);
                txtTransportasi.Text = tempKaryawan.TunjanganTransportasi.ToString("C", culture);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbBulan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBulan.SelectedItem != null)
            {
                string selectedMonth = cbBulan.SelectedItem.ToString();
            }
        }

        private void cbNama_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNIK();
            UpdateJabatan();
        }

        private bool isEditing = false;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAbsensi.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih data yang akan diedit terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tandai bahwa sedang dalam mode edit
                isEditing = true;

                // Get the selected row
                DataGridViewRow selectedRow = dgvAbsensi.SelectedRows[0];

                // Populate the form controls using column indices
                txtNIK.Text = selectedRow.Cells[0].Value?.ToString(); // NIK
                cbNama.Text = selectedRow.Cells[1].Value?.ToString(); // Nama Karyawan
                cbBulan.Text = selectedRow.Cells[2].Value?.ToString(); // Bulan
                cbHariKerja.Text = selectedRow.Cells[3].Value?.ToString(); // Jumlah Hari Kerja
                numAlpa.Value = Convert.ToDecimal(selectedRow.Cells[4].Value ?? 0); // Alpa
                numTelat.Value = Convert.ToDecimal(selectedRow.Cells[5].Value ?? 0); // Telat
                numIzin.Value = Convert.ToDecimal(selectedRow.Cells[6].Value ?? 0); // Izin
                numJamLembur.Value = Convert.ToDecimal(selectedRow.Cells[7].Value ?? 0); // Jumlah Jam Lembur

                // Convert and display monetary values
                var gajiLembur = Convert.ToDecimal(selectedRow.Cells[8].Value ?? 0);
                var gajiPokok = Convert.ToDecimal(selectedRow.Cells[9].Value ?? 0);
                var tunjanganJabatan = Convert.ToDecimal(selectedRow.Cells[10].Value ?? 0);
                var tunjanganMakan = Convert.ToDecimal(selectedRow.Cells[11].Value ?? 0);
                var tunjanganTransportasi = Convert.ToDecimal(selectedRow.Cells[12].Value ?? 0);
                var potonganAlfa = Convert.ToDecimal(selectedRow.Cells[13].Value ?? 0);
                var gajiBersih = Convert.ToDecimal(selectedRow.Cells[14].Value ?? 0);

                var culture = new CultureInfo("id-ID");
                txtGajiLembur.Text = gajiLembur.ToString("C", culture);
                txtGajiPokok.Text = gajiPokok.ToString("C", culture);
                txtJabatan.Text = tunjanganJabatan.ToString("C", culture);
                txtMakan.Text = tunjanganMakan.ToString("C", culture);
                txtTransportasi.Text = tunjanganTransportasi.ToString("C", culture);
                txtPotonganAlfa.Text = potonganAlfa.ToString("C", culture);
                txtGajiBersih.Text = gajiBersih.ToString("C", culture);

                // Store the selected employee data
                tempKaryawan = new Karyawan
                {
                    NIK = txtNIK.Text,
                    NamaKaryawan = cbNama.Text,
                    Bulan = cbBulan.Text,
                    JumlahHariKerja = int.Parse(cbHariKerja.Text),
                    Alpa = (int)numAlpa.Value,
                    Telat = (int)numTelat.Value,
                    Izin = (int)numIzin.Value,
                    JumlahJamLembur = (int)numJamLembur.Value,
                    GajiLembur = (int)gajiLembur,
                    GajiPokok = (int)gajiPokok,
                    TunjanganJabatan = (int)tunjanganJabatan,
                    TunjanganMakan = (int)tunjanganMakan,
                    TunjanganTransportasi = (int)tunjanganTransportasi,
                    PotonganAlfa = (int)potonganAlfa,
                    GajiBersih = (int)gajiBersih
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat mengedit data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}