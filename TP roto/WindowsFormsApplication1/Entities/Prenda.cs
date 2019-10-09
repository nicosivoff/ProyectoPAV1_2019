using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace TrabajoPractico.Entities
{
    public class Prenda
    {
        
        public int CodPrenda { get; set; }
        public TipoPrenda TipoPrenda { get; set; }
        public string Talle { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public Marca Marca { get; set; }

        public override string ToString()
        {
            return CodPrenda.ToString();
        }
       /* public bool validarDatosPrenda()
        {
            if (this.Codigo == null)
            {
                MessageBox.Show("El codigo esta vacio");
                return false;
            }
            if (this.Tipo.CodTipoPrenda == -1)
            {
                MessageBox.Show("El tipo esta vacio");
                return false;
            }
            if (this.Descripcion == "")
            {
                MessageBox.Show("La descripcion esta vacia");
                return false;
            }
            if (this.Talle == "")
            {
                MessageBox.Show("El talle esta vacio");
                return false;
            }
            if (this.Precio == "")
            {
                MessageBox.Show("El precio esta vacio");
                return false;
            }
            if (this.Cantidad == "")
            {
                MessageBox.Show("El cantidad esta vacio");
                return false;
            }
            return true;

        }
        */
    }
}
