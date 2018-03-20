namespace RRAlmacen.Almacen.Database
{
    partial class AppConfig
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
            this.txtNombreNegocio = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccionFiscal = new System.Windows.Forms.TextBox();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblNombreNegocio = new System.Windows.Forms.Label();
            this.lblDireccionFiscal = new System.Windows.Forms.Label();
            this.lblRFC = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNombreNegocio
            // 
            this.txtNombreNegocio.Location = new System.Drawing.Point(29, 103);
            this.txtNombreNegocio.Name = "txtNombreNegocio";
            this.txtNombreNegocio.Size = new System.Drawing.Size(323, 20);
            this.txtNombreNegocio.TabIndex = 25;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(202, 153);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(150, 20);
            this.txtTelefono.TabIndex = 24;
            // 
            // txtDireccionFiscal
            // 
            this.txtDireccionFiscal.Location = new System.Drawing.Point(29, 202);
            this.txtDireccionFiscal.Multiline = true;
            this.txtDireccionFiscal.Name = "txtDireccionFiscal";
            this.txtDireccionFiscal.Size = new System.Drawing.Size(323, 64);
            this.txtDireccionFiscal.TabIndex = 23;
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(29, 153);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(131, 20);
            this.txtRFC.TabIndex = 22;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(29, 52);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(323, 20);
            this.txtFileName.TabIndex = 21;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblFileName.Location = new System.Drawing.Point(26, 36);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(154, 16);
            this.lblFileName.TabIndex = 20;
            this.lblFileName.Text = "Ruta de la Base de Datos:";
            this.lblFileName.Visible = false;
            // 
            // lblNombreNegocio
            // 
            this.lblNombreNegocio.AutoSize = true;
            this.lblNombreNegocio.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombreNegocio.Location = new System.Drawing.Point(26, 87);
            this.lblNombreNegocio.Name = "lblNombreNegocio";
            this.lblNombreNegocio.Size = new System.Drawing.Size(136, 16);
            this.lblNombreNegocio.TabIndex = 19;
            this.lblNombreNegocio.Text = "Nombre del Negocio:";
            // 
            // lblDireccionFiscal
            // 
            this.lblDireccionFiscal.AutoSize = true;
            this.lblDireccionFiscal.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDireccionFiscal.Location = new System.Drawing.Point(26, 186);
            this.lblDireccionFiscal.Name = "lblDireccionFiscal";
            this.lblDireccionFiscal.Size = new System.Drawing.Size(104, 16);
            this.lblDireccionFiscal.TabIndex = 18;
            this.lblDireccionFiscal.Text = "Direccion Fiscal:";
            // 
            // lblRFC
            // 
            this.lblRFC.AutoSize = true;
            this.lblRFC.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblRFC.Location = new System.Drawing.Point(26, 137);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(33, 16);
            this.lblRFC.TabIndex = 17;
            this.lblRFC.Text = "RFC:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.Location = new System.Drawing.Point(199, 137);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 16);
            this.lblTelefono.TabIndex = 16;
            this.lblTelefono.Text = "Telefono:";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Teal;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnOK.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOK.Location = new System.Drawing.Point(29, 275);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "Aceptar ";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Teal;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Location = new System.Drawing.Point(363, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(133, 23);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "....";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Teal;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(126, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // AppConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 334);
            this.Controls.Add(this.txtNombreNegocio);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDireccionFiscal);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblNombreNegocio);
            this.Controls.Add(this.lblDireccionFiscal);
            this.Controls.Add(this.lblRFC);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Name = "AppConfig";
            this.Text = "AppConfig";
            this.Load += new System.EventHandler(this.AppConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreNegocio;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccionFiscal;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblNombreNegocio;
        private System.Windows.Forms.Label lblDireccionFiscal;
        private System.Windows.Forms.Label lblRFC;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
    }
}