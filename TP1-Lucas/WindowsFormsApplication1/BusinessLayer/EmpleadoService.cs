using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico.DataAccessLayer;
using TrabajoPractico.Entities;

namespace TrabajoPractico.BusinessLayer
{
    class EmpleadoService
    {
        private EmpleadoDao oEmpleadoDao = new EmpleadoDao();

        public IList<Empleado> ConsultarEmpleados(string condiciones)
        {
            return oEmpleadoDao.GetEmpleados(condiciones);
        }

        public bool crearEmpleado(Empleado empleado)
        {
            return oEmpleadoDao.crear(empleado);
        }

        public bool actualizarEmpleado(Empleado empleado)
        {
            return oEmpleadoDao.actualizar(empleado);
        }

        public IList<Empleado> ObtenerTodos()
        {
            return oEmpleadoDao.GetAll();
        }

        public IList<Empleado> ObtenerConFiltros(string condiciones)
        {
            return oEmpleadoDao.GetConFiltros(condiciones);
        }

        internal bool CrearEmpleado(Empleado oEmpleado)
        {
            return oEmpleadoDao.Create(oEmpleado);
        }
        internal bool ActualizarEmpleado(Empleado oEmpleadoSelected)
        {
            return oEmpleadoDao.Update(oEmpleadoSelected);
        }

        internal bool ModificarEstadoEmpleado(Empleado oEmpleadoSelected)
        {
            return oEmpleadoDao.Delete(oEmpleadoSelected);
        }

        internal bool ObtenerEmpleado(int legajo)
        {
            //SIN PARAMETROS
            return oEmpleadoDao.GetEmpleadoSinParametros(legajo);

        }
    }
}
