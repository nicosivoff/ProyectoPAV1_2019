using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TrabajoPractico.DataAccessLayer
{
    class MarcaDao
    {
        private DBHelper oBD = new DBHelper();

        public IList<Marca> getMarcaCondicionada(string condiciones)
        {
            List<Marca> listadoMarcas = new List<Marca>();

            String strSql = "SELECT idMarca, nombre" +
                            " FROM Marca" +
                            " WHERE borrado = 0";
            strSql += condiciones;
            var resultado = oBD.consultar(strSql);

            foreach(DataRow row in resultado.Rows)
            {
                listadoMarcas.Add(mappingMarca(row));
            }
            return listadoMarcas;
        }

        public IList<Marca> getAll()
        {
            List<Marca> listadoMarcas = new List<Marca>();
            String strSql = "SELECT idMarca, nombre" +
                            " FROM Marca WHERE borrado = 0";
            var resultado = oBD.consultar(strSql);

            foreach (DataRow row in resultado.Rows)
            {
                listadoMarcas.Add(mappingMarca(row));
            }
            return listadoMarcas;
        }
        public Marca mappingMarca(DataRow row)
        {
            Marca oMarca = new Marca();
            oMarca.IdMarca = Convert.ToInt32(row["idMarca"].ToString());
            oMarca.Nombre = row["nombre"].ToString();
            return oMarca;
        }
        public object getMarcaSinParametros(string idMarca)
        {
            string strSql = "SELECT idMarca, " +
                                    "nombre " + 
                            "FROM Marca " +
                            "WHERE borrado=0 AND idMarca=" + idMarca.ToString();
            var resultado = DBHelper.GetDBHelper().consultar(strSql);
            if (resultado.Rows.Count > 0)
            {
                return mappingMarca(resultado.Rows[0]);

            }
            return null;
        }
        public bool crearMarca(Marca marca)
        {
            string strSql = "INSERT INTO Marca(idMarca, nombre, borrado) " +
                            "VALUES (" +
                            "'" + marca.IdMarca + "' ," +
                            "'" + marca.Nombre + "' ," +
                            "0)";
            return (DBHelper.GetDBHelper().EjecutarSQL(strSql) == 1);
        }
        public bool actualizarMarca(Marca marca)
        {
            string strSql = "UPDATE Marca" +
                            " SET nombre= '" + marca.Nombre + "' ," + 
                            " borrado=0 " +
                            "WHERE idMarca = " + marca.IdMarca;
            return (DBHelper.GetDBHelper().EjecutarSQL(strSql) == 1);
        }

        public bool deleteMarca(Marca marca)
        {
            string strSql = "UPDATE Marca " +
                            "SET borrado=1" +
                            " WHERE idMarca= " + marca.IdMarca;
            oBD.actualizar(strSql);
            return true;
        }
    }
}
