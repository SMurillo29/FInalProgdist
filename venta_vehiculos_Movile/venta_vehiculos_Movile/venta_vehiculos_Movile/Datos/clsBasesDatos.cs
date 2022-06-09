using SQLite;
using venta_vehiculos_Movile.Models;

namespace venta_vehiculos_Movile.Datos
{
    public class clsBasesDatos
    {
        //Se crea la propiedad de conexion
        private SQLiteAsyncConnection oBaseDatos;
        public clsBasesDatos(string RutaBD)
        {
            oBaseDatos = new SQLiteAsyncConnection(RutaBD);
        }

        public void CrearTablas()
        {
            oBaseDatos.CreateTableAsync<ViewTVehiculo>().Wait();

        }
    }
}

