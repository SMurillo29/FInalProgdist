using libComunes.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using venta_vehiculos_API.Models;

namespace venta_vehiculos_API.Servicios
{
    public class RolService
    {
        public Rol rol { get; set; }
        public string Error { get; set; }


        public List<Rol> ConsultarTodos()
        {
            clsConexion oConexion = new clsConexion();

            oConexion.SQL = "rol_select";
            oConexion.StoredProcedure = true;
            List<Rol> roles = new List<Rol>();

            if (oConexion.Consultar())
            {
                while (oConexion.Reader.Read())
                {
                    rol = new Rol();
                    rol.id = oConexion.Reader.GetInt32(0);
                    rol.nombre_rol = oConexion.Reader.GetString(1);


                    roles.Add(rol);
                }
                oConexion.CerrarConexion();
                return roles;
            }
            else
            {
                Error = oConexion.Error;
                oConexion.CerrarConexion();
                return null;
            }
        }

        public Rol ConsultarXID(int id)
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "rol_id_select";
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, id);

            rol = new Rol();
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    rol.id = oConexion.Reader.GetInt32(0);
                    rol.nombre_rol = oConexion.Reader.GetString(1);

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
            return rol;
        }
        public string Insertar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "rol_insert";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@nombre_rol", System.Data.SqlDbType.VarChar, 30, rol.nombre_rol);
            ;



            if (oConexion.EjecutarSentencia())
            {
                return "El rol: " + rol.nombre_rol + " se ingresó exitosamente";


            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Actualizar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "rol_update";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, rol.id);
            oConexion.AgregarParametro("@nombre_rol", System.Data.SqlDbType.VarChar, 30, rol.nombre_rol);


            if (oConexion.EjecutarSentencia())
            {
                return "Rol con ID: " + rol.id + " se actualizó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Eliminar(int id)
        {
            clsConexion oConexion = new clsConexion();


            rol = this.ConsultarXID(id);

            if (rol == null)
            {
                return "No existe rol con ID: " + id;
            }


            oConexion.SQL = "rol_delete";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, id);


            if (oConexion.EjecutarSentencia())
            {
                return "el rol con ID: " + id + " se eliminó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }
    }
}