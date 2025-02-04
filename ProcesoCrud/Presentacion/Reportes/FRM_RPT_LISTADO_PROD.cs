using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesoCrud.Presentacion.Reportes
{
    public partial class FRM_RPT_LISTADO_PROD : Form
    {
        public FRM_RPT_LISTADO_PROD()
        {
            InitializeComponent();
        }

        private void FRM_RPT_LISTADO_PROD_Load(object sender, EventArgs e)
        {
            this.uSP_LISTADO_PRODTableAdapter.Fill(this.dS_Reportes.USP_LISTADO_PROD,cTexto:txt_01.Text);


            this.reportViewer1.RefreshReport();
        }
    }
}
