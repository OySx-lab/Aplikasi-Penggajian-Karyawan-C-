using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikasi_Karyawan
{
    public partial class EditAbsensi : Form
    {
        public EditAbsensi()
        {
            InitializeComponent();
        }

        public DateTime Tanggal { get; private set; }
        public string JamMasuk { get; private set; }
        public string JamKeluar { get; private set; }

        public EditAbsensi(DateTime tanggal, string jamMasuk, string jamKeluar)
        {
            InitializeComponent();
            dtpTanggal.Value = tanggal;
            txtJamMasuk.Text = jamMasuk;
            txtJamKeluar.Text = jamKeluar;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJamMasuk.Text) || string.IsNullOrWhiteSpace(txtJamKeluar.Text))
            {
                MessageBox.Show("Jam masuk dan jam keluar harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menyimpan perubahan?","Konfirmasi",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            Tanggal = dtpTanggal.Value;
            JamMasuk = txtJamMasuk.Text;
            JamKeluar = txtJamKeluar.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
