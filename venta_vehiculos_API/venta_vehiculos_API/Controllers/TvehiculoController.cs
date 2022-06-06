using System.Collections.Generic;
using System.Web.Http;
using venta_vehiculos_API.Models;
using venta_vehiculos_API.Servicios;
//using System.Web.Http.Cors;

namespace venta_vehiculos_API.Controllers
{
    //[EnableCors(origins: "http://localhost:54913", headers: "*", methods: "*")]
    public class TvehiculoController : ApiController
    {
        // GET: api/Estusiante
        public List<Tvehiculo> Get()
        {

            TvehiculoService service = new TvehiculoService();


            return service.ConsultarTodos();
        }

        // GET: api/Estusiante/5
        public Tvehiculo Get(int id)
        {
            TvehiculoService service = new TvehiculoService();

            return service.ConsultarXID(id);
        }

        // POST: api/Tvehiculo
        public string Post([FromBody] Tvehiculo body)
        {
            TvehiculoService service = new TvehiculoService();

            service.tvehiculo = body;


            return service.Insertar();
        }

        // PUT: api/Tvehiculo/5
        public string Put([FromBody] Tvehiculo body)
        {
            TvehiculoService service = new TvehiculoService();

            service.tvehiculo = body;

            return service.Actualizar();
        }

        // DELETE: api/Tvehiculo/5
        public string Delete(int id)
        {
            TvehiculoService service = new TvehiculoService();
            return service.Eliminar(id);
        }
    }
}