using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using venta_vehiculos_API.Models;
using venta_vehiculos_API.Servicios;
using venta_vehiculos_API.ViewModel;

namespace venta_vehiculos_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContratoController : ApiController
    {
        // GET: api/Estusiante
        public List<ContratoViewModel> Get()
        {

            ContratoService service = new ContratoService();


            return service.ConsultarTodos();
        }

        // GET: api/Estusiante/5
        public ContratoViewModel Get(int id)
        {
            ContratoService service = new ContratoService();

            return service.ConsultarXId(id);
        }

        // POST: api/Rol
        public string Post([FromBody] ContratoViewModel body)
        {
            ContratoService service = new ContratoService();

            service.contratoVM = body;


            return service.Insertar();
        }

        // PUT: api/Rol/5
        public string Put([FromBody] ContratoViewModel body)
        {
            ContratoService service = new ContratoService();

            service.contratoVM = body;

            return service.Actualizar();
        }

        // DELETE: api/Rol/5
        public string Delete(int id)
        {
            ContratoService service = new ContratoService();
            return service.Eliminar(id);
        }
    }
}