using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using venta_vehiculos_API.Models;
using venta_vehiculos_API.Servicios;
using venta_vehiculos_API.ViewModel;

namespace venta_vehiculos_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        // GET: api/Estusiante
        public List<Usuario> Get()
        {

            UsuarioService service = new UsuarioService();


            return service.ConsultarTodos();
        }

        // GET: api/Estusiante/5
        public Usuario Get(string id)
        {
            UsuarioService service = new UsuarioService();

            return service.ConsultarXDocumento(id);
        }

        // POST: api/Rol
        public string Post([FromBody] UsuarioVIewModel body)
        {
            UsuarioService service = new UsuarioService();

            service.usuarioVM = body;


            return service.Insertar();
        }

        // PUT: api/Rol/5
        public string Put([FromBody] UsuarioVIewModel body)
        {
            UsuarioService service = new UsuarioService();

            service.usuarioVM = body;

            return service.Actualizar();
        }

        // DELETE: api/Rol/5
        public string Delete(string id)
        {
            UsuarioService service = new UsuarioService();
            return service.Eliminar(id);
        }
    }
}