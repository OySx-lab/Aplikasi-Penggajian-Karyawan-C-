using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aplikasi_Karyawan
{
    public partial class Form1 : Form
    {
        public static string username;
        SqlConnection koneksi = new SqlConnection(@"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            username = this.Text;
            txtPassword.UseSystemPasswordChar = false;
        }

        private void shwPassword_CheckedChanged(object  sender, EventArgs e)
        {
            if (shwPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnMasuk_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Karyawan WHERE NamaUser = @NamaUser AND PasswordUser = @PasswordUser AND NikUser = @NikUser", koneksi);
                sda.SelectCommand.Parameters.AddWithValue("@NamaUser", txtNama.Text.Trim());
                sda.SelectCommand.Parameters.AddWithValue("@PasswordUser", txtPassword.Text.Trim());
                sda.SelectCommand.Parameters.AddWithValue("@NikUser", txtNIP.Text.Trim());

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "1")
                {
                    username = txtNama.Text;
                    this.Hide();
                    Menu menu = new Menu();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Username, NIK, atau Password salah. Silakan coba lagi.", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                {
                    koneksi.Close();
                }
            }
        }

        private void shwPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (shwPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();  // Menutup aplikasi
            }
        }

        private void btnMaximized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
