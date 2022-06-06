using libComunes.CapaDatos;
using System.Collections.Generic;
using venta_vehiculos_API.Models;

namespace venta_vehiculos_API.Servicios
{
    public class MarcaService
    {
        public Marca marca { get; set; }        
        public string Error { get; set; }


        public List<Marca> ConsultarTodos()
        {
            clsConexion oConexion = new clsConexion();

            oConexion.SQL = "marca_select";
            oConexion.StoredProcedure = true;
            List<Marca> marcas = new List<Marca>();

            if (oConexion.Consultar())
            {
                while (oConexion.Reader.Read())
                {
                    marca = new Marca();                    
                    marca.id = oConexion.Reader.GetInt32(0);
                    marca.nombre_marca = oConexion.Reader.GetString(1);


                    marcas.Add(marca);
                }
                oConexion.CerrarConexion();
                return marcas;
            }
            else
            {
                Error = oConexion.Error;
                oConexion.CerrarConexion();
                return null;
            }
        }

        public Marca ConsultarXID(int id)
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "marca_id_select";
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, id);

            marca = new Marca();
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    marca.id = oConexion.Reader.GetInt32(0);
                    marca.nombre_marca = oConexion.Reader.GetString(1);

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
            return marca;
        }
        public string Insertar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "marca_insert";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@nombre_marca", System.Data.SqlDbType.VarChar, 30, marca.nombre_marca);
            ;



            if (oConexion.EjecutarSentencia())
            {
                return "La marca: " + marca.nombre_marca + " se ingresó exitosamente";


            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Actualizar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "marca_update";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, marca.id);
            oConexion.AgregarParametro("@nombre_marca", System.Data.SqlDbType.VarChar, 30, marca.nombre_marca);


            if (oConexion.EjecutarSentencia())
            {
                return "La marca con ID: " + marca.id + " se actualizó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Eliminar(int id)
        {
            clsConexion oConexion = new clsConexion();


            marca = this.ConsultarXID(id);

            if (marca == null)
            {
                return "No existe la marca con ID: " + id;
            }


            oConexion.SQL = "marca_delete";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, id);            


            if (oConexion.EjecutarSentencia())
            {
                return "La marca con ID: " + id + " se eliminó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }
    }
}