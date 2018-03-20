namespace RRAlmacen.Almacen.Ventas
{
    partial class Cobrar
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
            this.btnOK = new System.Windows.Forms.Button();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblCambio = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Teal;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOK.Location = new System.Drawing.Point(109, 207);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 44);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "Aceptar";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtCambio
            // 
            this.txtCambio.Location = new System.Drawing.Point(88, 154);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(119, 20);
            this.txtCambio.TabIndex = 12;
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Location = new System.Drawing.Point(88, 91);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(119, 20);
            this.txtEfectivo.TabIndex = 11;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(88, 32);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(119, 20);
            this.txtTotal.TabIndex = 10;
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblCambio.Location = new System.Drawing.Point(105, 132);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(77, 19);
            this.lblCambio.TabIndex = 9;
            this.lblCambio.Text = "Cambio:";
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblEfectivo.Location = new System.Drawing.Point(105, 69);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(72, 19);
            this.lblEfectivo.TabIndex = 8;
            this.lblEfectivo.Text = "Efectivo:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(65, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(155, 19);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Cantidad a pagar:";
            // 
            // Cobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCambio);
            this.Controls.Add(this.txtEfectivo);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.lblTotal);
            this.Name = "Cobrar";
            this.Text = "Cobrar";
            this.Load += new System.EventHandler(this.Cobrar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Label lblTotal;
    }
}