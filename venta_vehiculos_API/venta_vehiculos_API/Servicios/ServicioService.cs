using libComunes.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using venta_vehiculos_API.Models;

namespace venta_vehiculos_API.Servicios
{
    public class ServicioService
    {
        public Servicio servicio { get; set; }
        public string Error { get; set; }


        public List<Servicio> ConsultarTodos()
        {
            clsConexion oConexion = new clsConexion();

            oConexion.SQL = "servicio_select";
            oConexion.StoredProcedure = true;
            List<Servicio> servicios = new List<Servicio>();

            if (oConexion.Consultar())
            {
                while (oConexion.Reader.Read())
                {
                    servicio = new Servicio();
                    servicio.id = oConexion.Reader.GetInt32(0);
                    servicio.nombre_servicio = oConexion.Reader.GetString(1);
                    servicio.detalle_servicio = oConexion.Reader.GetString(2);


                    servicios.Add(servicio);
                }
                oConexion.CerrarConexion();
                return servicios;
            }
            else
            {
                Error = oConexion.Error;
                oConexion.CerrarConexion();
                return null;
            }
        }

        public Servicio ConsultarXID(int id)
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "servicio_id_select";
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, id);

            servicio = new Servicio();
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    servicio.id = oConexion.Reader.GetInt32(0);
                    servicio.nombre_servicio = oConexion.Reader.GetString(1);
                    servicio.detalle_servicio = oConexion.Reader.GetString(2);

                    oConexion.CerrarConexion();
                }
                else
                {
                    oConexion.CerrarConexion();
                    return null;

                }
            }
            else
            {

                oConexion.CerrarConexion();
                return null;
            }
            return servicio;
        }
        public string Insertar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "servicio_insert";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@nombre_servicio", System.Data.SqlDbType.VarChar, 30, servicio.nombre_servicio);
            oConexion.AgregarParametro("@detalle_servicio", System.Data.SqlDbType.VarChar, 300, servicio.detalle_servicio);
            ;



            if (oConexion.EjecutarSentencia())
            {
                return "El servicio: " + servicio.nombre_servicio + " se ingresó exitosamente";


            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Actualizar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "servicio_update";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, servicio.id);
            oConexion.AgregarParametro("@nombre_servicio", System.Data.SqlDbType.VarChar, 30, servicio.nombre_servicio);
            oConexion.AgregarParametro("@detalle_servicio", System.Data.SqlDbType.VarChar, 300, servicio.detalle_servicio);


            if (oConexion.EjecutarSentencia())
            {
                return "Servicio con ID: " + servicio.id + " se actualizó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Eliminar(int id)
        {
            clsConexion oConexion = new clsConexion();


            servicio = this.ConsultarXID(id);

            if (servicio == null)
            {
                return "No existe servicio con ID: " + id;
            }


            oConexion.SQL = "servicio_delete";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, id);


            if (oConexion.EjecutarSentencia())
            {
                return "el servicio con ID: " + id + " se eliminó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }
    }
}