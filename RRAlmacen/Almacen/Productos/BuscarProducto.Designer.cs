namespace RRAlmacen.Almacen.Productos
{
    partial class BuscarProducto
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lvProductos = new System.Windows.Forms.ListView();
            this.txtDESC_PRODUCTO = new System.Windows.Forms.TextBox();
            this.lblDESC_PRODUCTO = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Teal;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBuscar.Location = new System.Drawing.Point(289, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lvProductos
            // 
            this.lvProductos.FullRowSelect = true;
            this.lvProductos.GridLines = true;
            this.lvProductos.HideSelection = false;
            this.lvProductos.Location = new System.Drawing.Point(12, 49);
            this.lvProductos.Name = "lvProductos";
            this.lvProductos.Size = new System.Drawing.Size(612, 267);
            this.lvProductos.TabIndex = 6;
            this.lvProductos.UseCompatibleStateImageBehavior = false;
            // 
            // txtDESC_PRODUCTO
            // 
            this.txtDESC_PRODUCTO.Location = new System.Drawing.Point(9, 23);
            this.txtDESC_PRODUCTO.Name = "txtDESC_PRODUCTO";
            this.txtDESC_PRODUCTO.Size = new System.Drawing.Size(274, 20);
            this.txtDESC_PRODUCTO.TabIndex = 5;
            // 
            // lblDESC_PRODUCTO
            // 
            this.lblDESC_PRODUCTO.AutoSize = true;
            this.lblDESC_PRODUCTO.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDESC_PRODUCTO.Location = new System.Drawing.Point(9, 4);
            this.lblDESC_PRODUCTO.Name = "lblDESC_PRODUCTO";
            this.lblDESC_PRODUCTO.Size = new System.Drawing.Size(159, 16);
            this.lblDESC_PRODUCTO.TabIndex = 4;
            this.lblDESC_PRODUCTO.Text = "Descripcion del Producto:";
            // 
            // BuscarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(628, 321);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lvProductos);
            this.Controls.Add(this.txtDESC_PRODUCTO);
            this.Controls.Add(this.lblDESC_PRODUCTO);
            this.MaximizeBox = false;
            this.Name = "BuscarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BuscarProducto";
            this.Load += new System.EventHandler(this.BuscarProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ListView lvProductos;
        private System.Windows.Forms.TextBox txtDESC_PRODUCTO;
        private System.Windows.Forms.Label lblDESC_PRODUCTO;
    }
}