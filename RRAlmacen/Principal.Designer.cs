namespace RRAlmacen
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministrar = new System.Windows.Forms.ToolStripMenuItem();
            this.crearProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.respaldoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearRespaldoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnConsultasVentas = new System.Windows.Forms.Button();
            this.btnVneta = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivosToolStripMenuItem,
            this.mnuConsultas,
            this.mnuAdministrar,
            this.respaldoToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1136, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVentas,
            this.cerrarSesionToolStripMenuItem});
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // mnuVentas
            // 
            this.mnuVentas.Name = "mnuVentas";
            this.mnuVentas.Size = new System.Drawing.Size(154, 22);
            this.mnuVentas.Text = "Punto de venta";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // mnuConsultas
            // 
            this.mnuConsultas.Name = "mnuConsultas";
            this.mnuConsultas.Size = new System.Drawing.Size(71, 20);
            this.mnuConsultas.Text = "Consultas";
            // 
            // mnuAdministrar
            // 
            this.mnuAdministrar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearProductoToolStripMenuItem});
            this.mnuAdministrar.Name = "mnuAdministrar";
            this.mnuAdministrar.Size = new System.Drawing.Size(81, 20);
            this.mnuAdministrar.Text = "Administrar";
            // 
            // crearProductoToolStripMenuItem
            // 
            this.crearProductoToolStripMenuItem.Name = "crearProductoToolStripMenuItem";
            this.crearProductoToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.crearProductoToolStripMenuItem.Text = "Agregar Producto";
            this.crearProductoToolStripMenuItem.Click += new System.EventHandler(this.crearProductoToolStripMenuItem_Click);
            // 
            // respaldoToolStripMenuItem
            // 
            this.respaldoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearRespaldoToolStripMenuItem,
            this.restaurarToolStripMenuItem});
            this.respaldoToolStripMenuItem.Name = "respaldoToolStripMenuItem";
            this.respaldoToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.respaldoToolStripMenuItem.Text = "Respaldo";
            // 
            // crearRespaldoToolStripMenuItem
            // 
            this.crearRespaldoToolStripMenuItem.Name = "crearRespaldoToolStripMenuItem";
            this.crearRespaldoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.crearRespaldoToolStripMenuItem.Text = "Crear Respaldo";
            this.crearRespaldoToolStripMenuItem.Click += new System.EventHandler(this.crearRespaldoToolStripMenuItem_Click);
            // 
            // restaurarToolStripMenuItem
            // 
            this.restaurarToolStripMenuItem.Name = "restaurarToolStripMenuItem";
            this.restaurarToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.restaurarToolStripMenuItem.Text = "Restaurar";
            this.restaurarToolStripMenuItem.Click += new System.EventHandler(this.restaurarToolStripMenuItem_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.Location = new System.Drawing.Point(643, 355);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(143, 163);
            this.btnUsuarios.TabIndex = 11;
            this.btnUsuarios.Text = "Usuario";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(481, 134);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(145, 163);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProductos.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductos.Image")));
            this.btnProductos.Location = new System.Drawing.Point(330, 355);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(145, 163);
            this.btnProductos.TabIndex = 10;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporte.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnReporte.Image")));
            this.btnReporte.Location = new System.Drawing.Point(792, 134);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(143, 163);
            this.btnReporte.TabIndex = 7;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnConsultasVentas
            // 
            this.btnConsultasVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultasVentas.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnConsultasVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultasVentas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConsultasVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultasVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultasVentas.Image")));
            this.btnConsultasVentas.Location = new System.Drawing.Point(37, 355);
            this.btnConsultasVentas.Name = "btnConsultasVentas";
            this.btnConsultasVentas.Size = new System.Drawing.Size(143, 163);
            this.btnConsultasVentas.TabIndex = 8;
            this.btnConsultasVentas.Text = "Consultas";
            this.btnConsultasVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultasVentas.UseVisualStyleBackColor = false;
            this.btnConsultasVentas.Click += new System.EventHandler(this.btnConsultasVentas_Click);
            // 
            // btnVneta
            // 
            this.btnVneta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVneta.BackColor = System.Drawing.SystemColors.Window;
            this.btnVneta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVneta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVneta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVneta.Image = ((System.Drawing.Image)(resources.GetObject("btnVneta.Image")));
            this.btnVneta.Location = new System.Drawing.Point(183, 134);
            this.btnVneta.Name = "btnVneta";
            this.btnVneta.Size = new System.Drawing.Size(143, 163);
            this.btnVneta.TabIndex = 6;
            this.btnVneta.Text = "Venta";
            this.btnVneta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVneta.UseVisualStyleBackColor = false;
            this.btnVneta.Click += new System.EventHandler(this.btnVneta_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::RRAlmacen.Properties.Resources.fondo_blanco_mullido_1053_302;
            this.ClientSize = new System.Drawing.Size(1136, 590);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnConsultasVentas);
            this.Controls.Add(this.btnVneta);
            this.Controls.Add(this.menuStrip2);
            this.IsMdiContainer = true;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RR-Almacen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuVentas;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultas;
        private System.Windows.Forms.ToolStripMenuItem mnuAdministrar;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnConsultasVentas;
        private System.Windows.Forms.Button btnVneta;
        private System.Windows.Forms.ToolStripMenuItem crearProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem respaldoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearRespaldoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restaurarToolStripMenuItem;
    }
}

