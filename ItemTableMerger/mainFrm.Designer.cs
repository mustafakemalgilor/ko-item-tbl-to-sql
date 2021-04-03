namespace ItemTableMerger
{
    partial class mainFrm
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExportAsSQL = new System.Windows.Forms.Button();
            this.btnLoadAndMerge = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(8, 17);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(357, 27);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load && Merge tables";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExportAsSQL
            // 
            this.btnExportAsSQL.Location = new System.Drawing.Point(8, 23);
            this.btnExportAsSQL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportAsSQL.Name = "btnExportAsSQL";
            this.btnExportAsSQL.Size = new System.Drawing.Size(167, 50);
            this.btnExportAsSQL.TabIndex = 2;
            this.btnExportAsSQL.Text = "Export as SQL Query";
            this.btnExportAsSQL.UseVisualStyleBackColor = true;
            this.btnExportAsSQL.Click += new System.EventHandler(this.btnExportAsSQL_Click);
            // 
            // btnLoadAndMerge
            // 
            this.btnLoadAndMerge.Location = new System.Drawing.Point(200, 23);
            this.btnLoadAndMerge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadAndMerge.Name = "btnLoadAndMerge";
            this.btnLoadAndMerge.Size = new System.Drawing.Size(167, 25);
            this.btnLoadAndMerge.TabIndex = 3;
            this.btnLoadAndMerge.Text = "Merge to File";
            this.btnLoadAndMerge.UseVisualStyleBackColor = true;
            this.btnLoadAndMerge.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(375, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnExportAsSQL);
            this.groupBox2.Controls.Add(this.btnLoadAndMerge);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(16, 74);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(375, 87);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 2";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 9.25F);
            this.lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatus.Location = new System.Drawing.Point(12, 165);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(381, 38);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Waiting ";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 54);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Export item icon binary file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 197);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "mainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Table Importer, PENTAGRAM (C) 2014";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExportAsSQL;
        private System.Windows.Forms.Button btnLoadAndMerge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button button1;
    }
}

