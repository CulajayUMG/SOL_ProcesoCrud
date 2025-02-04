using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesoCrud.Entidades
{
    public class E_Productos
    {
        public int Codigo_Prod { get; set; }
        public string Descripcion_prod { get; set; }
        public string Marca_prod { get; set; }
        public int Codigo_med { get; set; }
        public int Codigo_cat { get; set; }
        public decimal Stock_actual { get; set; }


    }
}
