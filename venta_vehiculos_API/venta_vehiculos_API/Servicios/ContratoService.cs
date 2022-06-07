using libComunes.CapaDatos;
using System.Collections.Generic;
using venta_vehiculos_API.ViewModel;

namespace venta_vehiculos_API.Servicios
{
    public class ContratoService
    {
        public ContratoViewModel contratoVM { get; set; }

        public string Error { get; set; }


        public List<ContratoViewModel> ConsultarTodos()
        {
            clsConexion oConexion = new clsConexion();

            oConexion.SQL = "contrato_select";
            oConexion.StoredProcedure = true;
            List<ContratoViewModel> contratos = new List<ContratoViewModel>();

            if (oConexion.Consultar())
            {
                while (oConexion.Reader.Read())
                {

                    contratoVM = new ContratoViewModel();

                    contratoVM.id = oConexion.Reader.GetInt32(0);
                    contratoVM.fecha = oConexion.Reader.GetDateTime(1);
                    contratoVM.FK_servicio = oConexion.Reader.GetInt32(2);
                    contratoVM.nombre_servicio = oConexion.Reader.GetString(3);
                    contratoVM.FK_cliente = oConexion.Reader.GetInt32(4);
                    contratoVM.nombre_cliente = oConexion.Reader.GetString(5);
                    contratoVM.FK_vendedor = oConexion.Reader.GetInt32(6);
                    contratoVM.nombre_vendedor = oConexion.Reader.GetString(7);
                    contratoVM.FK_vehiculo = oConexion.Reader.GetInt32(8);
                    contratoVM.precio = oConexion.Reader.GetDouble(9);
                    contratoVM.nombre_marca = oConexion.Reader.GetString(10);


                    contratos.Add(contratoVM);
                }
                oConexion.CerrarConexion();
                return contratos;
            }
            else
            {
                Error = oConexion.Error;
                oConexion.CerrarConexion();
                return null;
            }
        }

        public ContratoViewModel ConsultarXId(int id)
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "contrato_id_select";
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, id);


            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();

                    contratoVM = new ContratoViewModel();

                    contratoVM.id = oConexion.Reader.GetInt32(0);
                    contratoVM.fecha = oConexion.Reader.GetDateTime(1);
                    contratoVM.FK_servicio = oConexion.Reader.GetInt32(2);
                    contratoVM.nombre_servicio = oConexion.Reader.GetString(3);
                    contratoVM.FK_cliente = oConexion.Reader.GetInt32(4);
                    contratoVM.nombre_cliente = oConexion.Reader.GetString(5);
                    contratoVM.FK_vendedor = oConexion.Reader.GetInt32(6);
                    contratoVM.nombre_vendedor = oConexion.Reader.GetString(7);
                    contratoVM.FK_vehiculo = oConexion.Reader.GetInt32(8);
                    contratoVM.precio = oConexion.Reader.GetDouble(9);
                    contratoVM.nombre_marca = oConexion.Reader.GetString(10);

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
            return contratoVM;
        }
        public string Insertar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "contrato_insert";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@FK_servicio", System.Data.SqlDbType.Int, 20, contratoVM.FK_servicio);
            oConexion.AgregarParametro("@FK_cliente", System.Data.SqlDbType.Int, 20, contratoVM.FK_cliente);
            oConexion.AgregarParametro("@FK_vendedor", System.Data.SqlDbType.Int, 20, contratoVM.FK_vendedor);
            oConexion.AgregarParametro("@FK_vehiculo", System.Data.SqlDbType.Int, 20, contratoVM.FK_vehiculo);


            if (oConexion.EjecutarSentencia())
            {
                return "El contrato se ingresó exitosamente";


            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Actualizar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "contrato_update";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, contratoVM.id);
            oConexion.AgregarParametro("@FK_servicio", System.Data.SqlDbType.Int, 20, contratoVM.FK_servicio);
            oConexion.AgregarParametro("@FK_cliente", System.Data.SqlDbType.Int, 20, contratoVM.FK_cliente);
            oConexion.AgregarParametro("@FK_vendedor", System.Data.SqlDbType.Int, 20, contratoVM.FK_vendedor);
            oConexion.AgregarParametro("@FK_vehiculo", System.Data.SqlDbType.Int, 20, contratoVM.FK_vehiculo);


            if (oConexion.EjecutarSentencia())
            {
                return "El contrato se actualizó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Eliminar(int id)
        {
            clsConexion oConexion = new clsConexion();


            contratoVM = this.ConsultarXId(id);

            if (contratoVM == null)
            {
                return "No existe contrato con id: " + id;
            }


            oConexion.SQL = "contrato_delete";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@id", System.Data.SqlDbType.VarChar, 10, contratoVM.id);


            if (oConexion.EjecutarSentencia())
            {
                return "el contrato con id : " + contratoVM.id + " se eliminó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }
    }
}