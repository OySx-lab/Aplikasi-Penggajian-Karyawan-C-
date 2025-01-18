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

namespace Aplikasi_Karyawan
{
    public partial class Dashboard : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=LAPTOP-IF4EP5N8\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;TrustServerCertificate=True");

        public Dashboard()
        {
            InitializeComponent();
            UpdateDashboardCounts(); 
        }

        public void UpdateDashboardCounts()
        {
            try
            {
                koneksi.Open();
                SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM DataKaryawan", koneksi);
                int totalKaryawan = (int)cmdTotal.ExecuteScalar();
                dashboard_TK.Text = totalKaryawan.ToString();

                SqlCommand cmdAktif = new SqlCommand("SELECT COUNT(*) FROM DataKaryawan WHERE Status='Aktif'", koneksi);
                int karyawanAktif = (int)cmdAktif.ExecuteScalar();
                dashboard_KA.Text = karyawanAktif.ToString();

                SqlCommand cmdTidakAktif = new SqlCommand("SELECT COUNT(*) FROM DataKaryawan WHERE Status='Tidak Aktif'", koneksi);
                int karyawanTidakAktif = (int)cmdTidakAktif.ExecuteScalar();
                dashboard_KTA.Text = karyawanTidakAktif.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                koneksi.Close();
            }
        }
    }
}
