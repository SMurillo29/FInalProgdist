using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using venta_vehiculos_Movile.Models;

namespace venta_vehiculos_Movile.Datos
{
    class BrockerTvehiculo
    {
        private readonly SQLiteAsyncConnection oBaseDatos;

        public BrockerTvehiculo(string RutaBD)
        {
            oBaseDatos = new SQLiteAsyncConnection(RutaBD);
        }

        public Task<List<ViewTVehiculo>> GetTVehiculos()
        {
            return oBaseDatos.Table<ViewTVehiculo>().ToListAsync();
        }

        public Task<ViewTVehiculo> GetTVehiculoXID(int Id)
        {
            return oBaseDatos.Table<ViewTVehiculo>()
                .Where(vTVehiculo => vTVehiculo.id == Id)
                .FirstOrDefaultAsync();
        }
        /*
        public Task<TVehiculo> GetTVehiculoXDocumentoCliente(string Documento)
        {
            return oBaseDatos.Table<TVehiculo>()
                .Where(vTVehiculo => vTVehiculo.DocCliente == Documento)
                .FirstOrDefaultAsync();
        }*/
        public Task<int> GrabarTVehiculo(ViewTVehiculo vTVehiculo)
        {
            if (vTVehiculo.id == 0)
            {
                return oBaseDatos.InsertAsync(vTVehiculo);
            }
            else
            {
                return oBaseDatos.UpdateAsync(vTVehiculo);
            }
        }
        public Task<int> EliminarTVehiculo(ViewTVehiculo vTVehiculo)
        {
            return oBaseDatos.DeleteAsync(vTVehiculo);
        }

    }
}

