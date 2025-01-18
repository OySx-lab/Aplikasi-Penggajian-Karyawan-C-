namespace Aplikasi_Karyawan
{
    partial class EditAbsensi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.txtJamMasuk = new System.Windows.Forms.TextBox();
            this.txtJamKeluar = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Location = new System.Drawing.Point(199, 58);
            this.dtpTanggal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(265, 22);
            this.dtpTanggal.TabIndex = 0;
            // 
            // txtJamMasuk
            // 
            this.txtJamMasuk.Location = new System.Drawing.Point(199, 103);
            this.txtJamMasuk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtJamMasuk.Name = "txtJamMasuk";
            this.txtJamMasuk.Size = new System.Drawing.Size(221, 22);
            this.txtJamMasuk.TabIndex = 1;
            // 
            // txtJamKeluar
            // 
            this.txtJamKeluar.Location = new System.Drawing.Point(199, 151);
            this.txtJamKeluar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtJamKeluar.Name = "txtJamKeluar";
            this.txtJamKeluar.Size = new System.Drawing.Size(221, 22);
            this.txtJamKeluar.TabIndex = 2;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(235, 235);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(144, 52);
            this.btnSimpan.TabIndex = 3;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Jam Masuk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Jam Keluar";
            // 
            // EditAbsensi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 330);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtJamKeluar);
            this.Controls.Add(this.txtJamMasuk);
            this.Controls.Add(this.dtpTanggal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EditAbsensi";
            this.Text = "EditAbsensi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.TextBox txtJamMasuk;
        private System.Windows.Forms.TextBox txtJamKeluar;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}