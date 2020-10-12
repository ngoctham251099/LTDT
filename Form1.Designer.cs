namespace DA2_new
{
    partial class Form1
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
            this.panelShowmatran = new System.Windows.Forms.Panel();
            this.btnShowMaTran = new System.Windows.Forms.Button();
            this.btnLuukq = new System.Windows.Forms.Button();
            this.btnLuuMT = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnDuyetMien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelShowmatran
            // 
            this.panelShowmatran.Location = new System.Drawing.Point(12, 12);
            this.panelShowmatran.Name = "panelShowmatran";
            this.panelShowmatran.Size = new System.Drawing.Size(202, 167);
            this.panelShowmatran.TabIndex = 0;
            // 
            // btnShowMaTran
            // 
            this.btnShowMaTran.Location = new System.Drawing.Point(243, 12);
            this.btnShowMaTran.Name = "btnShowMaTran";
            this.btnShowMaTran.Size = new System.Drawing.Size(150, 41);
            this.btnShowMaTran.TabIndex = 1;
            this.btnShowMaTran.Text = "Mở ma trận";
            this.btnShowMaTran.UseVisualStyleBackColor = true;
            this.btnShowMaTran.Click += new System.EventHandler(this.btnShowMaTran_Click);
            // 
            // btnLuukq
            // 
            this.btnLuukq.Location = new System.Drawing.Point(243, 70);
            this.btnLuukq.Name = "btnLuukq";
            this.btnLuukq.Size = new System.Drawing.Size(148, 38);
            this.btnLuukq.TabIndex = 2;
            this.btnLuukq.Text = "Lưu kết quả";
            this.btnLuukq.UseVisualStyleBackColor = true;
            // 
            // btnLuuMT
            // 
            this.btnLuuMT.Location = new System.Drawing.Point(243, 129);
            this.btnLuuMT.Name = "btnLuuMT";
            this.btnLuuMT.Size = new System.Drawing.Size(148, 38);
            this.btnLuuMT.TabIndex = 3;
            this.btnLuuMT.Text = "Lưu ma trận";
            this.btnLuuMT.UseVisualStyleBackColor = true;
            this.btnLuuMT.Click += new System.EventHandler(this.btnLuuMT_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 194);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(240, 108);
            this.listBox1.TabIndex = 4;
            // 
            // btnDuyetMien
            // 
            this.btnDuyetMien.Location = new System.Drawing.Point(286, 184);
            this.btnDuyetMien.Name = "btnDuyetMien";
            this.btnDuyetMien.Size = new System.Drawing.Size(148, 38);
            this.btnDuyetMien.TabIndex = 3;
            this.btnDuyetMien.Text = "Duyet mien suongsuong";
            this.btnDuyetMien.UseVisualStyleBackColor = true;
            this.btnDuyetMien.Click += new System.EventHandler(this.btnDuyetMien_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 332);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnDuyetMien);
            this.Controls.Add(this.btnLuuMT);
            this.Controls.Add(this.btnLuukq);
            this.Controls.Add(this.btnShowMaTran);
            this.Controls.Add(this.panelShowmatran);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelShowmatran;
        private System.Windows.Forms.Button btnShowMaTran;
        private System.Windows.Forms.Button btnLuukq;
        private System.Windows.Forms.Button btnLuuMT;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnDuyetMien;
    }
}

