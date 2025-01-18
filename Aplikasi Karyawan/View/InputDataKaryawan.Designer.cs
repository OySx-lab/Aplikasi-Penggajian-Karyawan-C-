namespace Aplikasi_Karyawan
{
    partial class InputDataKaryawan
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
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnHapusData = new System.Windows.Forms.Button();
            this.txtNamaKaryawan = new System.Windows.Forms.TextBox();
            this.cbKelamin = new System.Windows.Forms.ComboBox();
            this.dtpTL = new System.Windows.Forms.DateTimePicker();
            this.txtNIK = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cbJabatan = new System.Windows.Forms.ComboBox();
            this.txtNoTelp = new System.Windows.Forms.TextBox();
            this.dtpTanggalMasuk = new System.Windows.Forms.DateTimePicker();
            this.rtbAlamat = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rbAktif = new System.Windows.Forms.RadioButton();
            this.rbTidakAktif = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvKaryawan = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKaryawan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSimpan
            // 
            this.btnSimpan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSimpan.BackColor = System.Drawing.Color.Lime;
            this.btnSimpan.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(515, 581);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(155, 60);
            this.btnSimpan.TabIndex = 17;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset.BackColor = System.Drawing.Color.Gray;
            this.btnReset.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(699, 581);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(155, 60);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnHapusData
            // 
            this.btnHapusData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHapusData.BackColor = System.Drawing.Color.Red;
            this.btnHapusData.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusData.ForeColor = System.Drawing.Color.White;
            this.btnHapusData.Location = new System.Drawing.Point(1072, 581);
            this.btnHapusData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHapusData.Name = "btnHapusData";
            this.btnHapusData.Size = new System.Drawing.Size(155, 60);
            this.btnHapusData.TabIndex = 21;
            this.btnHapusData.Text = "Hapus Data";
            this.btnHapusData.UseVisualStyleBackColor = false;
            this.btnHapusData.Click += new System.EventHandler(this.btnHapusData_Click);
            // 
            // txtNamaKaryawan
            // 
            this.txtNamaKaryawan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNamaKaryawan.Location = new System.Drawing.Point(95, 112);
            this.txtNamaKaryawan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNamaKaryawan.Name = "txtNamaKaryawan";
            this.txtNamaKaryawan.Size = new System.Drawing.Size(219, 22);
            this.txtNamaKaryawan.TabIndex = 1;
            // 
            // cbKelamin
            // 
            this.cbKelamin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbKelamin.FormattingEnabled = true;
            this.cbKelamin.Location = new System.Drawing.Point(531, 111);
            this.cbKelamin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbKelamin.Name = "cbKelamin";
            this.cbKelamin.Size = new System.Drawing.Size(219, 24);
            this.cbKelamin.TabIndex = 2;
            // 
            // dtpTL
            // 
            this.dtpTL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTL.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTL.Location = new System.Drawing.Point(611, 191);
            this.dtpTL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpTL.Name = "dtpTL";
            this.dtpTL.Size = new System.Drawing.Size(268, 26);
            this.dtpTL.TabIndex = 4;
            // 
            // txtNIK
            // 
            this.txtNIK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNIK.Location = new System.Drawing.Point(351, 112);
            this.txtNIK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.Size = new System.Drawing.Size(141, 22);
            this.txtNIK.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Location = new System.Drawing.Point(95, 191);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(219, 22);
            this.txtEmail.TabIndex = 10;
            // 
            // cbJabatan
            // 
            this.cbJabatan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbJabatan.FormattingEnabled = true;
            this.cbJabatan.Location = new System.Drawing.Point(351, 191);
            this.cbJabatan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbJabatan.Name = "cbJabatan";
            this.cbJabatan.Size = new System.Drawing.Size(219, 24);
            this.cbJabatan.TabIndex = 12;
            // 
            // txtNoTelp
            // 
            this.txtNoTelp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNoTelp.Location = new System.Drawing.Point(916, 196);
            this.txtNoTelp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNoTelp.Name = "txtNoTelp";
            this.txtNoTelp.Size = new System.Drawing.Size(309, 22);
            this.txtNoTelp.TabIndex = 23;
            // 
            // dtpTanggalMasuk
            // 
            this.dtpTanggalMasuk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTanggalMasuk.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTanggalMasuk.Location = new System.Drawing.Point(351, 277);
            this.dtpTanggalMasuk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpTanggalMasuk.Name = "dtpTanggalMasuk";
            this.dtpTanggalMasuk.Size = new System.Drawing.Size(264, 26);
            this.dtpTanggalMasuk.TabIndex = 24;
            // 
            // rtbAlamat
            // 
            this.rtbAlamat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtbAlamat.Location = new System.Drawing.Point(795, 112);
            this.rtbAlamat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbAlamat.Name = "rtbAlamat";
            this.rtbAlamat.Size = new System.Drawing.Size(431, 25);
            this.rtbAlamat.TabIndex = 27;
            this.rtbAlamat.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(95, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama Karyawan";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(347, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 21);
            this.label11.TabIndex = 5;
            this.label11.Text = "NIK";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(527, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Jenis Kelamin";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(607, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tanggal Lahir";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(95, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "No Rekening";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(347, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Jabatan";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(95, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "Status Karyawan";
            // 
            // rbAktif
            // 
            this.rbAktif.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbAktif.AutoSize = true;
            this.rbAktif.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAktif.ForeColor = System.Drawing.Color.Black;
            this.rbAktif.Location = new System.Drawing.Point(99, 277);
            this.rbAktif.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbAktif.Name = "rbAktif";
            this.rbAktif.Size = new System.Drawing.Size(59, 25);
            this.rbAktif.TabIndex = 14;
            this.rbAktif.TabStop = true;
            this.rbAktif.Text = "Aktif";
            this.rbAktif.UseVisualStyleBackColor = true;
            // 
            // rbTidakAktif
            // 
            this.rbTidakAktif.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbTidakAktif.AutoSize = true;
            this.rbTidakAktif.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTidakAktif.ForeColor = System.Drawing.Color.Black;
            this.rbTidakAktif.Location = new System.Drawing.Point(181, 277);
            this.rbTidakAktif.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbTidakAktif.Name = "rbTidakAktif";
            this.rbTidakAktif.Size = new System.Drawing.Size(95, 25);
            this.rbTidakAktif.TabIndex = 15;
            this.rbTidakAktif.TabStop = true;
            this.rbTidakAktif.Text = "Tidak Aktif";
            this.rbTidakAktif.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(912, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 22;
            this.label2.Text = "No Telpon";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(347, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 21);
            this.label9.TabIndex = 25;
            this.label9.Text = "Tanggal Masuk";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(791, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 21);
            this.label10.TabIndex = 26;
            this.label10.Text = "Alamat";
            // 
            // dgvKaryawan
            // 
            this.dgvKaryawan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvKaryawan.BackgroundColor = System.Drawing.Color.White;
            this.dgvKaryawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKaryawan.Location = new System.Drawing.Point(99, 355);
            this.dgvKaryawan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvKaryawan.Name = "dgvKaryawan";
            this.dgvKaryawan.RowHeadersWidth = 62;
            this.dgvKaryawan.RowTemplate.Height = 28;
            this.dgvKaryawan.Size = new System.Drawing.Size(1128, 193);
            this.dgvKaryawan.TabIndex = 16;
            this.dgvKaryawan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKaryawan_CellContentClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(893, 581);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(149, 60);
            this.btnEdit.TabIndex = 28;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 20F);
            this.label8.Location = new System.Drawing.Point(87, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 39);
            this.label8.TabIndex = 20;
            this.label8.Text = "DATA KARYAWAN";
            // 
            // InputDataKaryawan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1341, 687);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dgvKaryawan);
            this.Controls.Add(this.btnHapusData);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbAlamat);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dtpTanggalMasuk);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtNoTelp);
            this.Controls.Add(this.rbTidakAktif);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbJabatan);
            this.Controls.Add(this.txtNamaKaryawan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbKelamin);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.rbAktif);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpTL);
            this.Controls.Add(this.txtNIK);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InputDataKaryawan";
            this.Text = "p";
            this.Load += new System.EventHandler(this.InputDataKaryawan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKaryawan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnHapusData;
        private System.Windows.Forms.TextBox txtNamaKaryawan;
        private System.Windows.Forms.ComboBox cbKelamin;
        private System.Windows.Forms.DateTimePicker dtpTL;
        private System.Windows.Forms.TextBox txtNIK;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cbJabatan;
        private System.Windows.Forms.TextBox txtNoTelp;
        private System.Windows.Forms.DateTimePicker dtpTanggalMasuk;
        private System.Windows.Forms.RichTextBox rtbAlamat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbAktif;
        private System.Windows.Forms.RadioButton rbTidakAktif;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvKaryawan;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label8;
    }
}