using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using System.Data;
using TrabajoPractico.DataAccessLayer;


namespace TrabajoPractico.DataAccessLayer
{   
    
    class PrendaDao
    {
        DBHelper oBD = new DBHelper();
        /*public void grabarPrenda()
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

        public void actualizarPrenda()
        {
            string sqlUpdate = "";
            // (codPrenda,tipoPrenda,talle,descripcion,precio,cantidad)
            sqlUpdate = @"UPDATE Prenda SET tipoPrenda=" + this.tipo + ", " +
                        "talle='" + this.talle + "', " +
                        "descripcion='" + this.descripcion + "', " +
                        "precio='" + this.precio + "', " +
                        "cantidad='" + this.cantidad + "'" +
                        " WHERE codPrenda=" + this.codigo;

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
         * */

        public Prenda getPrendaID(int iD)
        {
            string strSql = "SELECT p.codPrenda, p.tipoPrenda, t.descrip, p.talle, p.descripcion, p.precio, p.cantidad, p.marca, m.nombre"
                            + " FROM Prenda p, TipoPrenda t, Marca m"
                            + " WHERE p.tipoPrenda=t.codTipoPrenda"
                            + " AND p.marca=m.idMarca"
                            + " AND p.codPrenda=" + iD.ToString();

            return MappingPrenda(oBD.consultar(strSql).Rows[0]);
        }

        public IList<Prenda> getPrendasCondicionada(String condiciones)
        {   

            List<Prenda> listadoPrendas = new List<Prenda>();
            
            String strSql = "SELECT p.codPrenda, p.tipoPrenda, t.descrip, p.talle, p.descripcion, p.precio, p.cantidad, p.marca, m.nombre"
                            + " FROM Prenda p, TipoPrenda t, Marca m"
                            + " WHERE p.tipoPrenda=t.codTipoPrenda"
                            + " AND p.marca=m.idMarca";
            strSql += condiciones;

            var resultadoConsulta = (DataRowCollection)oBD.consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoPrendas.Add(MappingPrenda(row));
            }

            return listadoPrendas;

        }

        private Prenda MappingPrenda(DataRow row)
        {
            Prenda oPrenda = new Prenda();
            oPrenda.codPrenda = Convert.ToInt32(row["codPrenda"].ToString());
            oPrenda.tipoPrenda = new TipoPrenda();
            oPrenda.tipoPrenda.codTipoPrenda = Convert.ToInt32(row["tipoPrenda"].ToString());
            oPrenda.tipoPrenda.descrip = row["descrip"].ToString();
            oPrenda.talle = row["talle"].ToString();
            oPrenda.descripcion = row["descripcion"].ToString();
            oPrenda.precio = Convert.ToInt32(row["precio"].ToString());
            oPrenda.cantidad = Convert.ToInt32(row["cantidad"].ToString());
            oPrenda.marca = new Marca();
            oPrenda.marca.idMarca = Convert.ToInt32(row["marca"].ToString());
            oPrenda.marca.nombre = row["nombre"].ToString();

            return oPrenda;
        }
    }
}
