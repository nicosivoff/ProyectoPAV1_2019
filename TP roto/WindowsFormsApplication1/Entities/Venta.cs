using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Entities
{
    class Venta
    {
        public int IdVenta { get; set; }
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public string TipoFactura { get; set; }
        public IList<VentaDetalle> VentaDetalle {get; set;}
        public double SubTotal { get; set; }

        public double ImporteTotal
        {
            get
            {
                return SubTotal;
            }
        }

        public override string ToString()
        {
            return TipoFactura + NroFactura.ToString("0001-00000000");
        }
    }
}
