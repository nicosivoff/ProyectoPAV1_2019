using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Entities
{
    class Pedido
    {
        public int CodPedido { get; set; }
        public int CUIL { get; set; }
        public DateTime Fecha { get; set; }
        public int Total { get; set; }
    }
}
