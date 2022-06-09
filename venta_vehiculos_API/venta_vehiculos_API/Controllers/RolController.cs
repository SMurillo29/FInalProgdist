using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using venta_vehiculos_API.Models;
using venta_vehiculos_API.Servicios;

namespace venta_vehiculos_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RolController : ApiController
    {
        // GET: api/Estusiante
        public List<Rol> Get()
        {

            RolService service = new RolService();


            return service.ConsultarTodos();
        }

        // GET: api/Estusiante/5
        public Rol Get(int id)
        {
            RolService service = new RolService();

            return service.ConsultarXID(id);
        }

        // POST: api/Rol
        public string Post([FromBody] Rol body)
        {
            RolService service = new RolService();

            service.rol = body;


            return service.Insertar();
        }

        // PUT: api/Rol/5
        public string Put([FromBody] Rol body)
        {
            RolService service = new RolService();

            service.rol = body;

            return service.Actualizar();
        }

        // DELETE: api/Rol/5
        public string Delete(int id)
        {
            RolService service = new RolService();
            return service.Eliminar(id);
        }
    }
}