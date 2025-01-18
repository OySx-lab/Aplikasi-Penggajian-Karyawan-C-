namespace Aplikasi_Karyawan
{
    partial class Tunjangan
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbNama = new System.Windows.Forms.ComboBox();
            this.cbTHR = new System.Windows.Forms.CheckBox();
            this.cbTransport = new System.Windows.Forms.CheckBox();
            this.cbMakan = new System.Windows.Forms.CheckBox();
            this.cbLembur = new System.Windows.Forms.CheckBox();
            this.btnTotalGaji = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(49, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama Karyawan";
            // 
            // cbNama
            // 
            this.cbNama.FormattingEnabled = true;
            this.cbNama.Location = new System.Drawing.Point(187, 62);
            this.cbNama.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbNama.Name = "cbNama";
            this.cbNama.Size = new System.Drawing.Size(162, 24);
            this.cbNama.TabIndex = 2;
            this.cbNama.SelectedIndexChanged += new System.EventHandler(this.cbNama_SelectedIndexChanged);
            // 
            // cbTHR
            // 
            this.cbTHR.AutoSize = true;
            this.cbTHR.Location = new System.Drawing.Point(189, 105);
            this.cbTHR.Name = "cbTHR";
            this.cbTHR.Size = new System.Drawing.Size(58, 20);
            this.cbTHR.TabIndex = 28;
            this.cbTHR.Text = "THR";
            this.cbTHR.UseVisualStyleBackColor = true;
            // 
            // cbTransport
            // 
            this.cbTransport.AutoSize = true;
            this.cbTransport.Location = new System.Drawing.Point(189, 152);
            this.cbTransport.Name = "cbTransport";
            this.cbTransport.Size = new System.Drawing.Size(87, 20);
            this.cbTransport.TabIndex = 29;
            this.cbTransport.Text = "Transport";
            this.cbTransport.UseVisualStyleBackColor = true;
            // 
            // cbMakan
            // 
            this.cbMakan.AutoSize = true;
            this.cbMakan.Location = new System.Drawing.Point(300, 105);
            this.cbMakan.Name = "cbMakan";
            this.cbMakan.Size = new System.Drawing.Size(70, 20);
            this.cbMakan.TabIndex = 30;
            this.cbMakan.Text = "Makan";
            this.cbMakan.UseVisualStyleBackColor = true;
            // 
            // cbLembur
            // 
            this.cbLembur.AutoSize = true;
            this.cbLembur.Location = new System.Drawing.Point(300, 152);
            this.cbLembur.Name = "cbLembur";
            this.cbLembur.Size = new System.Drawing.Size(74, 20);
            this.cbLembur.TabIndex = 31;
            this.cbLembur.Text = "Lembur";
            this.cbLembur.UseVisualStyleBackColor = true;
            // 
            // btnTotalGaji
            // 
            this.btnTotalGaji.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalGaji.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnTotalGaji.Location = new System.Drawing.Point(187, 192);
            this.btnTotalGaji.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTotalGaji.Name = "btnTotalGaji";
            this.btnTotalGaji.Size = new System.Drawing.Size(195, 45);
            this.btnTotalGaji.TabIndex = 32;
            this.btnTotalGaji.Text = "Total Gaji";
            this.btnTotalGaji.UseVisualStyleBackColor = true;
            this.btnTotalGaji.Click += new System.EventHandler(this.btnTotalGaji_Click);
            // 
            // Tunjangan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1379, 731);
            this.Controls.Add(this.btnTotalGaji);
            this.Controls.Add(this.cbLembur);
            this.Controls.Add(this.cbMakan);
            this.Controls.Add(this.cbTransport);
            this.Controls.Add(this.cbTHR);
            this.Controls.Add(this.cbNama);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Tunjangan";
            this.Text = " ";
            this.Load += new System.EventHandler(this.InputDataGaji_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNama;
        private System.Windows.Forms.CheckBox cbTHR;
        private System.Windows.Forms.CheckBox cbTransport;
        private System.Windows.Forms.CheckBox cbMakan;
        private System.Windows.Forms.CheckBox cbLembur;
        private System.Windows.Forms.Button btnTotalGaji;
    }
}