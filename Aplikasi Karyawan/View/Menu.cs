using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;

namespace Aplikasi_Karyawan
{
    public partial class Menu : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn") ]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
         );
        
        public Menu()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panel3.Height = btndb.Height;
            panel3.Top = btndb.Top;
            panel3.Left = btndb.Left;
            btndb.BackColor = Color.FromArgb(64, 64, 64); 
        }
        private void paneltampilan(object layar)
        {
            if (this.panel5.Controls.Count > 0)
                this.panel5.Controls.RemoveAt(0);
            Form fh = layar as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel5.Controls.Add(fh);
            this.panel5.Tag = fh;
            fh.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            paneltampilan(new Dashboard());
            label1.Text = Form1.username;
        }

        private void btndb_Click(object sender, EventArgs e)
        {
            panel3.Height = btndb.Height;
            panel3.Top = btndb.Top;
            panel3.Left = btndb.Left;
            btndb.BackColor = Color.FromArgb(64, 64, 64);
            paneltampilan(new Dashboard());
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            panel3.Height = btnData.Height;
            panel3.Top = btnData.Top;
            panel3.Left = btnData.Left;
            btndb.BackColor = Color.FromArgb(64, 64, 64);
            paneltampilan(new InputDataKaryawan());
        }

        private void btnAbsen_Click(object sender, EventArgs e)
        {
            panel3.Height = btnAbsen.Height;
            panel3.Top = btnAbsen.Top;
            panel3.Left = btnAbsen.Left;
            btndb.BackColor = Color.FromArgb(64, 64, 64);
            paneltampilan(new Absensi());
        }

        private void btnGaji_Click(object sender, EventArgs e)
        {
            panel3.Height = btnGaji.Height;
            panel3.Top = btnGaji.Top;
            panel3.Left = btnGaji.Left;
            btndb.BackColor = Color.FromArgb(64, 64, 64);
            paneltampilan(new Gaji());
        }

        private void btndb_Leave(object sender, EventArgs e)
        {
            btndb.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void btnData_Leave(object sender, EventArgs e)
        {
            btnData.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void btnAbsen_Leave(object sender, EventArgs e)
        {
            btnAbsen.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void btnGaji_Leave(object sender, EventArgs e)
        {
            btnGaji.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin Log Out ?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Menampilkan form login kembali
                Form1 formLogin = new Form1();
                formLogin.Show();  // Menampilkan form login

                // Menutup form Menu (form saat ini)
                this.Close();
            }
        }

        private void Maximized_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Region = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();  // Menutup aplikasi
            }
        }
    }
}
