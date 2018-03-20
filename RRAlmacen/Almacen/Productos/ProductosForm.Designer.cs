namespace RRAlmacen.Almacen.Productos
{
    partial class ProductosForm
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
            this.components = new System.ComponentModel.Container();
            this.lvProductos = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.btnstockMinima = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxUnidad = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Salir = new System.Windows.Forms.Button();
            this.CampoRequerrido = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDevolucion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.IVA = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CampoRequerrido)).BeginInit();
            this.SuspendLayout();
            // 
            // lvProductos
            // 
            this.lvProductos.Location = new System.Drawing.Point(5, 2);
            this.lvProductos.Name = "lvProductos";
            this.lvProductos.Size = new System.Drawing.Size(904, 289);
            this.lvProductos.TabIndex = 20;
            this.lvProductos.UseCompatibleStateImageBehavior = false;
            this.lvProductos.SelectedIndexChanged += new System.EventHandler(this.lvProductos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(5, 340);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(110, 20);
            this.txtNombre.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(118, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(121, 340);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(73, 20);
            this.txtPrecio.TabIndex = 23;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.Location = new System.Drawing.Point(197, 313);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(62, 16);
            this.lblCantidad.TabIndex = 26;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(200, 340);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(120, 20);
            this.txtCantidad.TabIndex = 25;
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblUnidad.Location = new System.Drawing.Point(323, 313);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(86, 16);
            this.lblUnidad.TabIndex = 28;
            this.lblUnidad.Text = "Stock Minima";
            // 
            // btnstockMinima
            // 
            this.btnstockMinima.Location = new System.Drawing.Point(326, 340);
            this.btnstockMinima.Name = "btnstockMinima";
            this.btnstockMinima.Size = new System.Drawing.Size(87, 20);
            this.btnstockMinima.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(522, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Area";
            // 
            // cboxUnidad
            // 
            this.cboxUnidad.FormattingEnabled = true;
            this.cboxUnidad.Location = new System.Drawing.Point(525, 339);
            this.cboxUnidad.Name = "cboxUnidad";
            this.cboxUnidad.Size = new System.Drawing.Size(121, 21);
            this.cboxUnidad.TabIndex = 29;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Teal;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAceptar.Location = new System.Drawing.Point(5, 364);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 30);
            this.btnAceptar.TabIndex = 31;
            this.btnAceptar.Text = "Nuevo";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Teal;
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModificar.Location = new System.Drawing.Point(102, 364);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(80, 30);
            this.btnModificar.TabIndex = 32;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Teal;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminar.Location = new System.Drawing.Point(188, 365);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(82, 29);
            this.btnEliminar.TabIndex = 33;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Teal;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.Location = new System.Drawing.Point(276, 365);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 30);
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Salir
            // 
            this.Salir.BackColor = System.Drawing.Color.Teal;
            this.Salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Salir.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.Salir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Salir.Location = new System.Drawing.Point(823, 365);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(81, 30);
            this.Salir.TabIndex = 35;
            this.Salir.Text = "Salir";
            this.Salir.UseVisualStyleBackColor = false;
            // 
            // CampoRequerrido
            // 
            this.CampoRequerrido.ContainerControl = this;
            // 
            // txtDevolucion
            // 
            this.txtDevolucion.Enabled = false;
            this.txtDevolucion.Location = new System.Drawing.Point(419, 340);
            this.txtDevolucion.Name = "txtDevolucion";
            this.txtDevolucion.Size = new System.Drawing.Size(100, 20);
            this.txtDevolucion.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(416, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 40;
            this.label5.Text = "Devolucion";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(809, 294);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(93, 20);
            this.txtTotal.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(764, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 42;
            this.label6.Text = "Total:";
            // 
            // IVA
            // 
            this.IVA.Enabled = false;
            this.IVA.Location = new System.Drawing.Point(809, 320);
            this.IVA.Name = "IVA";
            this.IVA.Size = new System.Drawing.Size(93, 20);
            this.IVA.TabIndex = 43;
            // 
            // ProductosForm
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.Salir;
            this.ClientSize = new System.Drawing.Size(914, 405);
            this.Controls.Add(this.IVA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDevolucion);
            this.Controls.Add(this.Salir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboxUnidad);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.btnstockMinima);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lvProductos);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ProductosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.ProductosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CampoRequerrido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.TextBox btnstockMinima;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxUnidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button Salir;
        private System.Windows.Forms.ErrorProvider CampoRequerrido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDevolucion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox IVA;
    }
}