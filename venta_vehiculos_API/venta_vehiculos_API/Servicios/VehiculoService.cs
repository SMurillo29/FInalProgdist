using libComunes.CapaDatos;
using System.Collections.Generic;
using venta_vehiculos_API.Models;
using venta_vehiculos_API.ViewModel;

namespace venta_vehiculos_API.Servicios
{
    public class VehiculoService
    {
        public VehiculoViewModel vehiculoVM { get; set; }

        public Vehiculo vehiculo { get; set; }
        public string Error { get; set; }


        public List<Vehiculo> ConsultarTodos()
        {
            clsConexion oConexion = new clsConexion();

            oConexion.SQL = "vehiculo_select";
            oConexion.StoredProcedure = true;
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            if (oConexion.Consultar())
            {
                while (oConexion.Reader.Read())
                {
                    Marca marca = new Marca();
                    Tvehiculo tvehiculo = new Tvehiculo();
                    vehiculo = new Vehiculo();
                    vehiculo.id = oConexion.Reader.GetInt32(0);
                    vehiculo.kilometraje = oConexion.Reader.GetDouble(1);
                    vehiculo.precio = oConexion.Reader.GetDouble(2);
                    vehiculo.color = oConexion.Reader.GetString(3);
                    tvehiculo.id = oConexion.Reader.GetInt32(4);
                    tvehiculo.nombre_tipo_vehiculo = oConexion.Reader.GetString(5);
                    vehiculo.fktipo = tvehiculo;
                    marca.id = oConexion.Reader.GetInt32(6);
                    marca.nombre_marca = oConexion.Reader.GetString(7);
                    vehiculo.fkmarca = marca;




                    vehiculos.Add(vehiculo);
                }
                oConexion.CerrarConexion();
                return vehiculos;
            }
            else
            {
                Error = oConexion.Error;
                oConexion.CerrarConexion();
                return null;
            }
        }

        public Vehiculo ConsultarXId(int id)
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "vehiculo_id_select";
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, id);


            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();


                    Marca marca = new Marca();
                    Tvehiculo tvehiculo = new Tvehiculo();
                    vehiculo = new Vehiculo();
                    vehiculo.id = oConexion.Reader.GetInt32(0);
                    vehiculo.kilometraje = oConexion.Reader.GetDouble(1);
                    vehiculo.precio = oConexion.Reader.GetDouble(2);
                    vehiculo.color = oConexion.Reader.GetString(3);
                    tvehiculo.id = oConexion.Reader.GetInt32(4);
                    tvehiculo.nombre_tipo_vehiculo = oConexion.Reader.GetString(5);
                    vehiculo.fktipo = tvehiculo;
                    marca.id = oConexion.Reader.GetInt32(6);
                    marca.nombre_marca = oConexion.Reader.GetString(7);
                    vehiculo.fkmarca = marca;

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
            return vehiculo;
        }
        public string Insertar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "vehiculo_insert";
            oConexion.StoredProcedure = true;

            //oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, vehiculoVM.id);
            oConexion.AgregarParametro("@kilometraje", System.Data.SqlDbType.Float, 10, vehiculoVM.kilometraje);
            oConexion.AgregarParametro("@precio", System.Data.SqlDbType.Float, 10, vehiculoVM.precio);
            oConexion.AgregarParametro("@color", System.Data.SqlDbType.VarChar, 30, vehiculoVM.color);
            oConexion.AgregarParametro("@fktipo", System.Data.SqlDbType.Int, 10, vehiculoVM.fktipo);
            oConexion.AgregarParametro("@fkmarca", System.Data.SqlDbType.Int, 10, vehiculoVM.fkmarca);


            if (oConexion.EjecutarSentencia())
            {
                return "El vehiculo se ingresó exitosamente";


            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Actualizar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "vehiculo_update";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, vehiculoVM.id);
            oConexion.AgregarParametro("@kilometraje", System.Data.SqlDbType.Float, 10, vehiculoVM.kilometraje);
            oConexion.AgregarParametro("@precio", System.Data.SqlDbType.Float, 10, vehiculoVM.precio);
            oConexion.AgregarParametro("@color", System.Data.SqlDbType.VarChar, 30, vehiculoVM.color);
            oConexion.AgregarParametro("@fktipo", System.Data.SqlDbType.Int, 10, vehiculoVM.fktipo);
            oConexion.AgregarParametro("@fkmarca", System.Data.SqlDbType.Int, 10, vehiculoVM.fkmarca);


            if (oConexion.EjecutarSentencia())
            {
                return "El vehiculo se actualizó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Eliminar(int id)
        {
            clsConexion oConexion = new clsConexion();


            vehiculo = this.ConsultarXId(id);

            if (vehiculo == null)
            {
                return "No existe vehiculo con id: " + id;
            }


            oConexion.SQL = "vehiculo_delete";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@id", System.Data.SqlDbType.VarChar, 10, vehiculo.id);


            if (oConexion.EjecutarSentencia())
            {
                return "el vehiculo con id : " + vehiculo.id + " se eliminó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }
    }
}