namespace multidb
{
    partial class frmPrincipal
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
            this.bbiconMssql = new System.Windows.Forms.Button();
            this.bbiconMysql = new System.Windows.Forms.Button();
            this.dgvmysql = new System.Windows.Forms.DataGridView();
            this.dgvmssql = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmysql)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmssql)).BeginInit();
            this.SuspendLayout();
            // 
            // bbiconMssql
            // 
            this.bbiconMssql.Location = new System.Drawing.Point(287, 12);
            this.bbiconMssql.Name = "bbiconMssql";
            this.bbiconMssql.Size = new System.Drawing.Size(275, 23);
            this.bbiconMssql.TabIndex = 0;
            this.bbiconMssql.Text = "Conecta Mssql";
            this.bbiconMssql.UseVisualStyleBackColor = true;
            this.bbiconMssql.Click += new System.EventHandler(this.button1_Click);
            // 
            // bbiconMysql
            // 
            this.bbiconMysql.Location = new System.Drawing.Point(12, 12);
            this.bbiconMysql.Name = "bbiconMysql";
            this.bbiconMysql.Size = new System.Drawing.Size(269, 23);
            this.bbiconMysql.TabIndex = 1;
            this.bbiconMysql.Text = "Conecta Mysql";
            this.bbiconMysql.UseVisualStyleBackColor = true;
            this.bbiconMysql.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvmysql
            // 
            this.dgvmysql.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmysql.Location = new System.Drawing.Point(12, 41);
            this.dgvmysql.Name = "dgvmysql";
            this.dgvmysql.Size = new System.Drawing.Size(269, 358);
            this.dgvmysql.TabIndex = 2;
            this.dgvmysql.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvmysql_CellContentClick);
            // 
            // dgvmssql
            // 
            this.dgvmssql.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmssql.Location = new System.Drawing.Point(287, 41);
            this.dgvmssql.Name = "dgvmssql";
            this.dgvmssql.Size = new System.Drawing.Size(275, 358);
            this.dgvmssql.TabIndex = 3;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 411);
            this.Controls.Add(this.dgvmssql);
            this.Controls.Add(this.dgvmysql);
            this.Controls.Add(this.bbiconMysql);
            this.Controls.Add(this.bbiconMssql);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvmysql)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmssql)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bbiconMssql;
        private System.Windows.Forms.Button bbiconMysql;
        private System.Windows.Forms.DataGridView dgvmysql;
        private System.Windows.Forms.DataGridView dgvmssql;
    }
}

