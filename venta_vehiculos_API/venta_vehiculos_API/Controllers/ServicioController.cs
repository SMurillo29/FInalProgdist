using System.Collections.Generic;
using System.Web.Http;
using venta_vehiculos_API.Models;
using venta_vehiculos_API.Servicios;
//using System.Web.Http.Cors;

namespace venta_vehiculos_API.Controllers
{
    //[EnableCors(origins: "http://localhost:54913", headers: "*", methods: "*")]
    public class ServicioController : ApiController
    {
        // GET: api/Estusiante
        public List<Servicio> Get()
        {

            ServicioService service = new ServicioService();


            return service.ConsultarTodos();
        }

        // GET: api/Estusiante/5
        public Servicio Get(int id)
        {
            ServicioService service = new ServicioService();

            return service.ConsultarXID(id);
        }

        // POST: api/Servicio
        public string Post([FromBody] Servicio body)
        {
            ServicioService service = new ServicioService();

            service.servicio = body;


            return service.Insertar();
        }

        // PUT: api/Servicio/5
        public string Put([FromBody] Servicio body)
        {
            ServicioService service = new ServicioService();

            service.servicio = body;

            return service.Actualizar();
        }

        // DELETE: api/Servicio/5
        public string Delete(int id)
        {
            ServicioService service = new ServicioService();
            return service.Eliminar(id);
        }
    }
}