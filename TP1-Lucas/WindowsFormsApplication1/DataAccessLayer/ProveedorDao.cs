using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.Entities;
using System.Data;


namespace TrabajoPractico.DataAccessLayer
{
    class ProveedorDao
    {
        DBHelper oBD = new DBHelper();

        public IList<Proveedor> GetProveedores(string condiciones)
        {
            List<Proveedor> listadoProveedores = new List<Proveedor>();

            String strSql = "SELECT CUIL, telefono, direccion, razonSocial "+
                            "FROM Proveedor WHERE borrado=0";

            strSql += condiciones;
            var resultadoConsulta = (DataRowCollection)oBD.consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoProveedores.Add(MappingProveedor(row));
            }

            return listadoProveedores;
        }

        public IList<Proveedor> GetAll()
        {
            List<Proveedor> listadoProveedores = new List<Proveedor>();

            String strSql = "SELECT *" +
                            "FROM Proveedor WHERE borrado=0";

            var resultadoConsulta = (DataRowCollection)oBD.consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoProveedores.Add(MappingProveedor(row));
            }

            return listadoProveedores;
        }


        private Proveedor MappingProveedor(DataRow row)
        {
            Proveedor oProveedor = new Proveedor();
            oProveedor.CUIL = Convert.ToInt32(row["CUIL"].ToString());
            oProveedor.Telefono = Convert.ToInt32(row["telefono"].ToString());
            oProveedor.RazonSocial = row["razonSocial"].ToString();
            oProveedor.Direccion = row["direccion"].ToString();
      
            return oProveedor;
        }

        internal bool Create(Proveedor oProveedor)
    {

        string str_sql = "INSERT INTO Proveedor (CUIL,telefono,direccion,razonSocial,borrado) "+
                         "VALUES("+oProveedor.CUIL+","+oProveedor.Telefono+",'"+oProveedor.Direccion+"','"+oProveedor.RazonSocial+"',0)";
        oBD.actualizar(str_sql);
        
        return true;
    }
        internal bool Update(Proveedor oProveedor)
    {
        string str_sql = "UPDATE Proveedor " +
                         "SET razonSocial= '" + oProveedor.RazonSocial + "', direccion = '" + oProveedor.Direccion + "', telefono= " + oProveedor.Telefono
                         + " WHERE CUIL=" + oProveedor.CUIL;
        oBD.actualizar(str_sql);
        return true;
    }

        internal bool Delete(Proveedor oProveedor)
    {
        string str_sql = "UPDATE Proveedor " +
                         "SET borrado=1" +
                         " WHERE CUIL= " + oProveedor.CUIL.ToString();
        oBD.actualizar(str_sql);
        return true;
    }
        public bool GetProveedorCuil(int cuil)
    {
        //Construimos la consulta sql para buscar el usuario en la base de datos.
        String strSql = string.Concat(" SELECT razonSocial,telefono,CUIL FROM Proveedor WHERE borrado =0 ",
                                      "AND CUIL= ", cuil);


        //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
        var resultado = oBD.consultar(strSql);

        // Validamos que el resultado tenga al menos una fila.
        if (resultado.Rows.Count > 0)
        {
            return true;
        }

        return false;
    }

    }
    }

