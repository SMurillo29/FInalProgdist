using libComunes.CapaDatos;
using System.Collections.Generic;
using venta_vehiculos_API.Models;

namespace venta_vehiculos_API.Servicios
{
    public class TvehiculoService
    {
        public Tvehiculo tvehiculo { get; set; }
        public string Error { get; set; }


        public List<Tvehiculo> ConsultarTodos()
        {
            clsConexion oConexion = new clsConexion();

            oConexion.SQL = "Tipo_vehiculo_select";
            oConexion.StoredProcedure = true;
            List<Tvehiculo> Tipo_vehiculos = new List<Tvehiculo>();

            if (oConexion.Consultar())
            {
                while (oConexion.Reader.Read())
                {
                    tvehiculo = new Tvehiculo();
                    tvehiculo.id = oConexion.Reader.GetInt32(0);
                    tvehiculo.nombre_tipo_vehiculo = oConexion.Reader.GetString(1);


                    Tipo_vehiculos.Add(tvehiculo);
                }
                oConexion.CerrarConexion();
                return Tipo_vehiculos;
            }
            else
            {
                Error = oConexion.Error;
                oConexion.CerrarConexion();
                return null;
            }
        }

        public Tvehiculo ConsultarXID(int id)
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "Tipo_vehiculo_id_select";
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, id);

            tvehiculo = new Tvehiculo();
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    tvehiculo.id = oConexion.Reader.GetInt32(0);
                    tvehiculo.nombre_tipo_vehiculo = oConexion.Reader.GetString(1);

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
            return tvehiculo;
        }
        public string Insertar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "Tipo_vehiculo_insert";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@nombre_Tipo_vehiculo", System.Data.SqlDbType.VarChar, 30, tvehiculo.nombre_tipo_vehiculo);
            ;



            if (oConexion.EjecutarSentencia())
            {
                return "Tipo_vehiculo: " + tvehiculo.nombre_tipo_vehiculo + " se ingresó exitosamente";


            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Actualizar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "Tipo_vehiculo_update";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, tvehiculo.id);
            oConexion.AgregarParametro("@nombre_Tipo_vehiculo", System.Data.SqlDbType.VarChar, 30, tvehiculo.nombre_tipo_vehiculo);


            if (oConexion.EjecutarSentencia())
            {
                return "Tipo_vehiculo con ID: " + tvehiculo.id + " se actualizó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Eliminar(int id)
        {
            clsConexion oConexion = new clsConexion();


            tvehiculo = this.ConsultarXID(id);

            if (tvehiculo == null)
            {
                return "No existe tipo de vehiculo con ID: " + id;
            }


            oConexion.SQL = "tipo_vehiculo_delete";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, id);


            if (oConexion.EjecutarSentencia())
            {
                return "el tipo de vehiculo con ID: " + id + " se eliminó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }
    }
}