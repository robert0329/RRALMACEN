using RRAlmacen.CapaNegocios;
using RRAlmacen.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRAlmacen.Almacen.Ingresos
{
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }
        public string Id;
        private bool IsNuevo = false;
        private bool IsEditar = false;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtRazon_Social.Text == string.Empty || this.txtNum_Documento.Text == string.Empty
                    || this.txtDireccion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtRazon_Social, "Ingrese un Valor");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NProveedor.Insertar(this.txtRazon_Social.Text.Trim().ToUpper(),
                            this.cbSector_Comercial.Text, cbTipo_Documento.Text,
                            txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text,
                            txtEmail.Text, txtUrl.Text);

                    }
                    else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtIdproveedor.Text),
                            this.txtRazon_Social.Text.Trim().ToUpper(),
                            this.cbSector_Comercial.Text, cbTipo_Documento.Text,
                            txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text,
                            txtEmail.Text, txtUrl.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazon_Social.Focus();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdproveedor.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdproveedor.Text = string.Empty;
        }    

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void Limpiar()
        {
            this.txtRazon_Social.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtUrl.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdproveedor.Text = string.Empty;

        }

        private void Habilitar(bool valor)
        {
            this.txtRazon_Social.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbSector_Comercial.Enabled = valor;
            this.cbTipo_Documento.Enabled = valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtUrl.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtIdproveedor.ReadOnly = !valor;
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            lvProductos.View = View.Details;
            lvProductos.Columns.Add("idproveedor", 80, HorizontalAlignment.Center);
            lvProductos.Columns.Add("razon_social", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("sector_comercial", 80, HorizontalAlignment.Center);
            lvProductos.Columns.Add("tipo_documento", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("num_documento", 80, HorizontalAlignment.Center);
            lvProductos.Columns.Add("direccion", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("telefono", 80, HorizontalAlignment.Center);
            lvProductos.Columns.Add("email", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("url", 80, HorizontalAlignment.Center);

            LeerDatos();
            this.Top = 0;
            this.Left = 0;
            this.Habilitar(false);
            this.Botones();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }
        
        private void LeerDatos()
        {
            int I = 0;

            string sql = "select idproveedor,razon_social as razon, sector_comercial as sector,tipo_documento,num_documento,direccion,telefono,email,url FROM proveedor";
            try
            {
                using (var cnnReadData = new SqlConnection(RRSOFT.CnnStr))
                {
                    if (cnnReadData.State == ConnectionState.Open)
                        cnnReadData.Close();
                    else cnnReadData.Open();

                    SqlDataReader drReadData = NProveedor.SqlCommand(sql, cnnReadData).ExecuteReader();
                    lvProductos.Items.Clear();

                    while (drReadData.Read())
                    {
                        lvProductos.Items.Add(drReadData["idproveedor"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["razon"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["sector"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["tipo_documento"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["num_documento"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["direccion"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["telefono"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["email"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["url"].ToString());
                        I += 1;
                    }

                    drReadData.Close();
                    cnnReadData.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Proveedore()
        {
            try
            {
                Id = lvProductos.SelectedItems[0].Text;
                string sql = "select idproveedor,razon_social, sector_comercial,tipo_documento,num_documento,direccion,telefono,email,url FROM proveedor  WHERE idproveedor like '%" + Id + "%'";
                if (lvProductos.Items.Count != 0)
                {
                    using (var cnnReadData = new SqlConnection(RRSOFT.CnnStr))
                    {
                        if (cnnReadData.State == ConnectionState.Open)
                            cnnReadData.Close();
                        else cnnReadData.Open();

                        SqlDataReader drReadData = NProveedor.SqlCommand(sql, cnnReadData).ExecuteReader();

                        while (drReadData.Read())
                        {
                            txtIdproveedor.Text = drReadData["idproveedor"].ToString();
                            txtRazon_Social.Text = drReadData["razon_social"].ToString();
                            cbSector_Comercial.Text = drReadData["sector_comercial"].ToString();
                            cbTipo_Documento.Text = drReadData["tipo_documento"].ToString();
                            txtNum_Documento.Text = drReadData["num_documento"].ToString();
                            txtDireccion.Text = drReadData["direccion"].ToString();
                            txtTelefono.Text = drReadData["telefono"].ToString();
                            txtEmail.Text = drReadData["email"].ToString();
                            txtUrl.Text = drReadData["url"].ToString();
                            
                        }
                        drReadData.Close();
                        cnnReadData.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista. \nDescripción del error: \n" + ex.Message, "Operación no válida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void lvProductos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Proveedore();
        }
    }
}
