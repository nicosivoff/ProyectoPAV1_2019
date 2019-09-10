using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace TrabajoPractico.Clases
{
    class Prenda
    {
        Datos oBD = new Datos();
        int codigo;
        int tipo;
        int marca;
        string talle;
        string descripcion;
        string precio;
        string cantidad;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public int Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public string Talle
        {
            get { return talle; }
            set { talle = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public string Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public void grabarPrenda()
        {
            string sqlInsert = "";

            sqlInsert = @"INSERT INTO Prenda (codPrenda,tipoPrenda,talle,descripcion,precio,cantidad,marca) VALUES ('" +
                         this.codigo + "', '" +
                         this.tipo + "', '" +                         
                         this.talle + "', '" +
                         this.descripcion + "', '" +
                         this.precio + "', '" +
                         this.cantidad + "', '" +
                         this.marca + "')";

            oBD.actualizar(sqlInsert);
      
        }
        public bool validarDatosPrenda()
        {
            if (this.codigo == null)
            {
                MessageBox.Show("El codigo esta vacio");
                return false;
            }
            if (this.tipo == -1)
            {
                MessageBox.Show("El tipo esta vacio");
                return false;
            }
            if (this.descripcion == "")
            {
                MessageBox.Show("La descripcion esta vacia");
                return false;
            }
            if (this.talle == "")
            {
                MessageBox.Show("El talle esta vacio");
                return false;
            }
            if (this.precio == "")
            {
                MessageBox.Show("El precio esta vacio");
                return false;
            }
            if (this.cantidad == "")
            {
                MessageBox.Show("El cantidad esta vacio");
                return false;
            }
            return true;

        }
        public void actualizarPrenda()
        {
            string sqlUpdate = "";
            // (codPrenda,tipoPrenda,talle,descripcion,precio,cantidad)
            sqlUpdate = @"UPDATE Prenda SET tipoPrenda=" + this.tipo + ", " +
                        "talle='" + this.talle + "', " + 
                        "descripcion='" + this.descripcion + "', " +
                        "precio='" + this.precio + "', " +
                        "cantidad='" + this.cantidad + "'" +
                        " WHERE codPrenda=" + this.codigo ;

            oBD.actualizar(sqlUpdate);

        }
        public void eliminarPrenda()
        {
            string sqlDelete = @"DELETE FROM Prenda WHERE codPrenda='" + this.codigo + "'";
            oBD.actualizar(sqlDelete);
        }

        public DataTable recuperarPrenda()
        {
            string strSql = "SELECT p.codPrenda, t.descripcion, p.talle, p.descripcion, p.precio, p.cantidad, m.nombre"
                            + " FROM Prenda p, TipoPrenda t, Marca m"
                            + " WHERE p.tipoPrenda=t.codTipoPrenda"
                            + " AND p.marca=m.idMarca";
            return oBD.consultar(strSql);
        }
    }
}
