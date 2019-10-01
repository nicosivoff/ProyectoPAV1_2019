using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.DataAccessLayer;
using TrabajoPractico.Entities;
using System.Data;

namespace TrabajoPractico.DataAccessLayer
{
    class ClienteDao
    {
        DBHelper oBD = new DBHelper();

        public IList<Cliente> GetClientes(string condiciones)
        {
            List<Cliente> listadoClientes = new List<Cliente>();

            String strSql = "SELECT nroDoc,telefono,nombre,apellido,domicilio,email "+
                            "FROM Cliente WHERE borrado=0";

            strSql += condiciones;
            var resultadoConsulta = (DataRowCollection)oBD.consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoClientes.Add(MappingCliente(row));
            }

            return listadoClientes;
        }

        public IList<Cliente> GetAll()
        {
            List<Cliente> listadoClientes = new List<Cliente>();

            String strSql = "SELECT *" +
                            "FROM Cliente WHERE borrado=0";

            var resultadoConsulta = (DataRowCollection)oBD.consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listadoClientes.Add(MappingCliente(row));
            }

            return listadoClientes;
        }


        private Cliente MappingCliente(DataRow row)
        {
            Cliente oCliente = new Cliente();
            oCliente.NroDoc = Convert.ToInt32(row["nroDoc"].ToString());
            oCliente.Telefono = Convert.ToInt32(row["telefono"].ToString());
            oCliente.Nombre = row["nombre"].ToString();
            oCliente.Apellido = row["apellido"].ToString();
            oCliente.Domicilio = row["domicilio"].ToString();
            oCliente.Mail = row["email"].ToString();
      
            return oCliente;
        }

        internal bool Create(Cliente oCliente)
    {

        string str_sql = "INSERT INTO Cliente (nroDoc,telefono,nombre,apellido,domicilio,email,borrado) "+
                         "VALUES("+oCliente.NroDoc+","+oCliente.Telefono+",'"+oCliente.Nombre+"','"+oCliente.Apellido+"','"+oCliente.Domicilio+"','"+oCliente.Mail+"',0)";
        oBD.actualizar(str_sql);
        
        return true;
    }
        internal bool Update(Cliente oCliente)
    {
        string str_sql = "UPDATE Cliente " +
                         "SET nombre= '" + oCliente.Nombre + "', apellido = '" + oCliente.Apellido + "', domicilio= '" + oCliente.Mail + "', telefono= " + oCliente.Telefono
                         + " WHERE nroDoc=" + oCliente.NroDoc;
        oBD.actualizar(str_sql);
        return true;
    }

        internal bool Delete(Cliente oCliente)
    {
        string str_sql = "UPDATE Cliente " +
                         "SET borrado=1" +
                         " WHERE nroDoc= " + oCliente.NroDoc.ToString();
        oBD.actualizar(str_sql);
        return true;
    }
        public bool GetClienteDoc(int doc)
    {
        //Construimos la consulta sql para buscar el usuario en la base de datos.
        String strSql = string.Concat(" SELECT nombre,apellido,nroDoc FROM Cliente WHERE borrado =0 ",
                                      "AND nroDoc= ", doc);


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

    

