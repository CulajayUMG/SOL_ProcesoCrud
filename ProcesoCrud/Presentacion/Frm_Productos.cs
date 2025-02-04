using ProcesoCrud.Datos;
using ProcesoCrud.Entidades;
using ProcesoCrud.Presentacion.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesoCrud.Presentacion
{
    public partial class Frm_Productos : Form
    {
        public Frm_Productos()
        {
            InitializeComponent();
        }
        #region"Variables"
        int nEstadoguarda = 0;
        int vCodigoProd = 0;

        #endregion


        #region "Metodos de trabajo"

        private void txt_Limpiar() {
            txtBusqueda.Text = "";
            txtMarca.Text = "";
            txtProducto.Text = "";
            txtStock.Text = "0.00";
            comBoxCat.Text = "";
            comBoxMedida.Text = "";

        }

        private void EstadoTexto(bool lEstado){
        txtProducto.Enabled = lEstado;
            txtMarca.Enabled = lEstado;
            txtBusqueda.Enabled = lEstado;
            txtStock.Enabled = lEstado;
            comBoxCat.Enabled = lEstado;
            comBoxMedida.Enabled = lEstado;
            //label2.Enabled = lEstado;
            //label3.Enabled = lEstado;
            //label4.Enabled = lEstado;
            //label5.Enabled = lEstado;
            //label6.Enabled = lEstado;
            //label7.Enabled = lEstado;
        }

        private void estadoBotones(bool lEstado)
        {
            btnGuardar.Visible = !lEstado;
            btnCancelar.Visible = !lEstado;


            btnNuevo.Enabled = lEstado;
            btnActualizar.Enabled = lEstado;
            btnEliminar.Enabled = lEstado;
            btnReporte.Enabled = lEstado;
            btnSalir.Enabled = lEstado;
            btnBuscar.Enabled = lEstado;
            txtBusqueda.Enabled= lEstado;
            dgvListado.Enabled = lEstado;
        }

        private void cargarMed()
        {
            D_Productos Datos = new D_Productos();
            comBoxMedida.DataSource = Datos.Listado_med();
            comBoxMedida.ValueMember = "codigo_med";
            comBoxMedida.DisplayMember = "descripcion_med";
           // comBoxMedida.ValueMember = "codigo_med";

        }

        private void cargarCat()
        {
            D_Productos Datos = new D_Productos();
            comBoxCat.DataSource = Datos.Listado_cat();
            comBoxCat.ValueMember = "codigo_cat";
            comBoxCat.DisplayMember = "descripcion_cat";
            // comBoxMedida.ValueMember = "codigo_med";

        }

        private void Form_Producto()
        {
            dgvListado.Columns[0].Width = 50;
            dgvListado.Columns[0].HeaderText = "ID";

            dgvListado.Columns[1].Width = 175;
            dgvListado.Columns[1].HeaderText = "PRODUCTO";

            dgvListado.Columns[2].Width = 75;
            dgvListado.Columns[2].HeaderText = "MARCA";

            dgvListado.Columns[3].Width = 100;
            dgvListado.Columns[3].HeaderText = "MEDIDA";

            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[4].HeaderText = "CATEGORIA";

            dgvListado.Columns[5].Width = 75;
            dgvListado.Columns[5].HeaderText = "STOCK";

            dgvListado.Columns[6].Visible = false;
            dgvListado.Columns[7].Visible = false;

        }

        private void ListadoProd(string cTexto)
        {
            D_Productos Datos = new D_Productos();
            dgvListado.DataSource = Datos.Listado_prod(cTexto);
            this.Form_Producto();
        }

        private void Selecciona_Item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvListado.CurrentRow.Cells["codigo_prod"].Value))) 
            {
                MessageBox.Show("No se ha seleccionado un item", "Aviso del sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }else
            {
                this.vCodigoProd = Convert.ToInt32(dgvListado.CurrentRow.Cells["codigo_prod"].Value);
                txtProducto.Text = Convert.ToString(dgvListado.CurrentRow.Cells["descripcion_prod"].Value);
                txtMarca.Text = Convert.ToString(dgvListado.CurrentRow.Cells["marca_prod"].Value);
                comBoxMedida.Text = Convert.ToString(dgvListado.CurrentRow.Cells["descripcion_med"].Value);
                comBoxCat.Text = Convert.ToString(dgvListado.CurrentRow.Cells["descripcion_cat"].Value);
                txtStock.Text = Convert.ToString(dgvListado.CurrentRow.Cells["stock_actual"].Value);

            }
        }

        #endregion





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            this.cargarMed();
            this.cargarCat();
            this.ListadoProd("%");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nEstadoguarda = 1;
            this.vCodigoProd = 0;
            this.txt_Limpiar();
            this.EstadoTexto(true);
            this.estadoBotones(false);
            txtProducto.Select();
        }

        private void comBoxCat_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txt_Limpiar();
            this.EstadoTexto(false);
            this.estadoBotones(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text == string.Empty || 
                txtMarca.Text == string.Empty ||
                comBoxMedida.Text == string.Empty ||
                comBoxCat.Text == string.Empty ||
                txtStock.Text == string.Empty)
            {
                // validar datos correctos
                MessageBox.Show("Ingrese datos requeridos (*)", "Aviso del programa",
                    MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else {
                // guardar info
                string Rpta = "";
                E_Productos oPro = new E_Productos();
                oPro.Codigo_Prod = this.vCodigoProd;
                oPro.Descripcion_prod = txtProducto.Text;
                oPro.Marca_prod = txtMarca.Text;
                oPro.Codigo_med = Convert.ToInt32(comBoxMedida.SelectedValue);
                oPro.Codigo_cat = Convert.ToInt32(comBoxCat.SelectedValue);
                oPro.Stock_actual = Convert.ToDecimal(txtStock.Text);

                D_Productos Datos = new D_Productos();
                Rpta = Datos.Guardar_Prod(this.nEstadoguarda,oPro);
                if (Rpta == "Guardado Correctamente")
                {
                    this.ListadoProd("%");
                    MessageBox.Show("Producto agregado correctamente", "aviso del sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.vCodigoProd = 0;
                    this.txt_Limpiar();
                    this.EstadoTexto(false);
                    this.estadoBotones(true);
                }
                else {
                    MessageBox.Show("Algo salio Mal", "aviso del sistema",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_Item();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.nEstadoguarda = 2; //actualizar registro
            this.EstadoTexto(true);
            this.estadoBotones(false);
            txtProducto.Select();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListadoProd(txtBusqueda.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count<=0|| 
                string.IsNullOrEmpty(Convert.ToString(dgvListado.CurrentRow.Cells["codigo_prod"].Value))) {
                MessageBox.Show("No se tiene informacion para eliminar",
                    "aviso del sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }else {

                string Rpta = "";
                D_Productos Datos = new D_Productos();
                Rpta = Datos.Activo_prod(vCodigoProd,false);
                if (Rpta == "CORRECTO")
                {
                    this.ListadoProd("%");
                    this.txt_Limpiar();
                    vCodigoProd = 0;
                    MessageBox.Show("Se Elimino el producto seleccionado", "Aviso del sistema"
                                    , MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("Ocurrio un error inesperado", "Aviso del sistema"
                                        , MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            FRM_RPT_LISTADO_PROD oFrm_rpt = new FRM_RPT_LISTADO_PROD();
            oFrm_rpt.txt_01.Text = txtBusqueda.Text;
            oFrm_rpt.ShowDialog();
        }
    }
}
