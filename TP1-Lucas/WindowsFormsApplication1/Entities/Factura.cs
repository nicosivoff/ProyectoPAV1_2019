using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Entities
{
    class Factura
    {
        public int codFactura { get; set; }
        public string idUsuario { get; set; }
        public DateTime fecha { get; set; }
        public int total { get; set; }
        public TipoPago tipoPago { get; set; }
        public TipoFactura tipoFactura { get; set; }
        public IList<DetalleFactura> FacturaDetalle { get; set; }
    }
}
