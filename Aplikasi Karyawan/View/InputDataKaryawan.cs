using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikasi_Karyawan
{
    public partial class InputDataKaryawan : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True");
        private bool isEditMode = false;
        public InputDataKaryawan()
        {
            InitializeComponent();
            TampilkanData();
            IsiComboBox();
        }

        private void IsiComboBox()
        {

            cbKelamin.Items.Clear();
            cbKelamin.Items.Add("Laki-Laki");
            cbKelamin.Items.Add("Perempuan");
            cbJabatan.Items.Clear();
            cbJabatan.Items.Add("Leader");
            cbJabatan.Items.Add("Karyawan");
        }

        private void TampilkanData()
        {
            try
            {
                using (SqlConnection koneksi = new SqlConnection(@"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True"))
                {
                    koneksi.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM DataKaryawan", koneksi);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvKaryawan.DataSource = dt;

                    dgvKaryawan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvKaryawan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ResetForm()
        {
            txtNIK.Clear();
            txtNamaKaryawan.Clear();
            cbKelamin.SelectedIndex = -1;
            dtpTL.Value = DateTime.Now;
            txtEmail.Clear();
            txtNoTelp.Clear();
            dtpTanggalMasuk.Value = DateTime.Now;
            cbJabatan.SelectedIndex = -1;
            rbAktif.Checked = false;
            rbTidakAktif.Checked = false;
           rtbAlamat.Clear(); 
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection koneksi = new SqlConnection(@"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True"))
                {
                    koneksi.Open();

                    string status = rbAktif.Checked ? "Aktif" : "Tidak Aktif";

                    if (isEditMode)
                    {
                        // Update data yang sudah ada
                        SqlCommand cmd = new SqlCommand(
                            "UPDATE DataKaryawan SET NamaKaryawan = @NamaKaryawan, Kelamin = @Kelamin, TanggalLahir = @TanggalLahir, NoRekening = @NoRekening, No_Telp = @No_Telp, TanggalMasuk = @TanggalMasuk, Jabatan = @Jabatan, Status = @Status, Alamat = @Alamat WHERE NIK = @NIK",
                            koneksi);

                        cmd.Parameters.AddWithValue("@NIK", txtNIK.Text.Trim());
                        cmd.Parameters.AddWithValue("@NamaKaryawan", txtNamaKaryawan.Text.Trim());
                        cmd.Parameters.AddWithValue("@Kelamin", cbKelamin.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@TanggalLahir", dtpTL.Value);
                        cmd.Parameters.AddWithValue("@NoRekening", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@No_Telp", txtNoTelp.Text.Trim());
                        cmd.Parameters.AddWithValue("@TanggalMasuk", dtpTanggalMasuk.Value);
                        cmd.Parameters.AddWithValue("@Jabatan", cbJabatan.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@Alamat", rtbAlamat.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil diperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Tambah data baru
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO DataKaryawan (NIK, NamaKaryawan, Kelamin, TanggalLahir, NoRekening, No_Telp, TanggalMasuk, Jabatan, Status, Alamat) " +
                            "VALUES (@NIK, @NamaKaryawan, @Kelamin, @TanggalLahir, @NoRekening, @No_Telp, @TanggalMasuk, @Jabatan, @Status, @Alamat)",
                            koneksi);

                        cmd.Parameters.AddWithValue("@NIK", txtNIK.Text.Trim());
                        cmd.Parameters.AddWithValue("@NamaKaryawan", txtNamaKaryawan.Text.Trim());
                        cmd.Parameters.AddWithValue("@Kelamin", cbKelamin.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@TanggalLahir", dtpTL.Value);
                        cmd.Parameters.AddWithValue("@NoRekening", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@No_Telp", txtNoTelp.Text.Trim());
                        cmd.Parameters.AddWithValue("@TanggalMasuk", dtpTanggalMasuk.Value);
                        cmd.Parameters.AddWithValue("@Jabatan", cbJabatan.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@Alamat", rtbAlamat.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Refresh data dan reset form
                    TampilkanData();
                    ResetForm();
                    isEditMode = false; // Kembali ke mode tambah
                    txtNIK.Enabled = true; // Aktifkan kembali NIK untuk tambah data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void dgvKaryawan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKaryawan.Rows[e.RowIndex];
                txtNIK.Text = row.Cells["NIK"].Value.ToString();
                txtNamaKaryawan.Text = row.Cells["NamaKaryawan"].Value.ToString();
                cbKelamin.SelectedItem = row.Cells["Kelamin"].Value.ToString();
                dtpTL.Value = Convert.ToDateTime(row.Cells["TanggalLahir"].Value);
                txtEmail.Text = row.Cells["NoRekening"].Value.ToString();
                txtNoTelp.Text = row.Cells["No_Telp"].Value.ToString();
                dtpTanggalMasuk.Value = Convert.ToDateTime(row.Cells["TanggalMasuk"].Value);
                cbJabatan.SelectedItem = row.Cells["Jabatan"].Value.ToString();
                string status = row.Cells["Status"].Value.ToString();
                rbAktif.Checked = status == "Aktif";
                rbTidakAktif.Checked = status == "Tidak Aktif";
                rtbAlamat.Text = row.Cells["Alamat"].Value.ToString();
            }
        }

        private void btnHapusData_Click(object sender, EventArgs e)
        {
            if (dgvKaryawan.SelectedRows.Count > 0)
            {
                try
                {
                    string nik = dgvKaryawan.SelectedRows[0].Cells["NIK"].Value.ToString();

                    DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        using (SqlConnection koneksi = new SqlConnection(@"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True"))
                        {
                            koneksi.Open();
                            SqlCommand cmd = new SqlCommand("DELETE FROM DataKaryawan WHERE NIK = @NIK", koneksi);
                            cmd.Parameters.AddWithValue("@NIK", nik);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Data berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TampilkanData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Silakan pilih baris data yang akan dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InputDataKaryawan_Load(object sender, EventArgs e)
        {
            label8.Parent = this;
            label8.BackColor = Color.Transparent;
            label1.Parent = this;
            label1.BackColor = Color.Transparent;
            label2.Parent = this;
            label2.BackColor = Color.Transparent;
            label11.Parent = this;
            label11.BackColor = Color.Transparent;
            label3.Parent = this;
            label3.BackColor = Color.Transparent;
            label4.Parent = this;
            label4.BackColor = Color.Transparent;
            label5.Parent = this;
            label5.BackColor = Color.Transparent;
            label6.Parent = this;
            label6.BackColor = Color.Transparent;
            label7.Parent = this;
            label7.BackColor = Color.Transparent;
            label8.Parent = this;
            label8.BackColor = Color.Transparent;
            label9.Parent = this;
            label9.BackColor = Color.Transparent;
            label10.Parent = this;
            label10.BackColor = Color.Transparent;
            rbAktif.Parent = this;
            rbAktif.BackColor = Color.Transparent;
            rbTidakAktif.Parent = this;
            rbTidakAktif.BackColor = Color.Transparent;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvKaryawan.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvKaryawan.SelectedRows[0];

                    // Mengambil data dari row yang dipilih
                    txtNIK.Text = row.Cells["NIK"].Value.ToString();
                    txtNamaKaryawan.Text = row.Cells["NamaKaryawan"].Value.ToString();
                    cbKelamin.Text = row.Cells["Kelamin"].Value.ToString();
                    dtpTL.Value = Convert.ToDateTime(row.Cells["TanggalLahir"].Value);
                    txtEmail.Text = row.Cells["NoRekening"].Value.ToString();
                    txtNoTelp.Text = row.Cells["No_Telp"].Value.ToString();
                    dtpTanggalMasuk.Value = Convert.ToDateTime(row.Cells["TanggalMasuk"].Value);
                    cbJabatan.Text = row.Cells["Jabatan"].Value.ToString();
                    string status = row.Cells["Status"].Value.ToString();
                    rbAktif.Checked = status == "Aktif";
                    rbTidakAktif.Checked = status != "Aktif";
                    rtbAlamat.Text = row.Cells["Alamat"].Value.ToString();

                    
                    isEditMode = true;
                    txtNIK.Enabled = true; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang akan diedit terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}