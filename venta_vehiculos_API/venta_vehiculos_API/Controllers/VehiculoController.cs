using System.Collections.Generic;
using System.Web.Http;
using venta_vehiculos_API.Models;
using venta_vehiculos_API.Servicios;
using venta_vehiculos_API.ViewModel;

namespace venta_vehiculos_API.Controllers
{
    public class VehiculoController : ApiController
    {
        // GET: api/Estusiante
        public List<Vehiculo> Get()
        {

            VehiculoService service = new VehiculoService();


            return service.ConsultarTodos();
        }

        // GET: api/Estusiante/5
        public Vehiculo Get(int id)
        {
            VehiculoService service = new VehiculoService();

            return service.ConsultarXId(id);
        }

        // POST: api/Rol
        public string Post([FromBody] VehiculoViewModel body)
        {
            VehiculoService service = new VehiculoService();

            service.vehiculoVM = body;


            return service.Insertar();
        }

        // PUT: api/Rol/5
        public string Put([FromBody] VehiculoViewModel body)
        {
            VehiculoService service = new VehiculoService();

            service.vehiculoVM = body;

            return service.Actualizar();
        }

        // DELETE: api/Rol/5
        public string Delete(int id)
        {
            VehiculoService service = new VehiculoService();
            return service.Eliminar(id);
        }
    }
}