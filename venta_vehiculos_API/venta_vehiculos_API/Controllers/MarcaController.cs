using System.Collections.Generic;
using System.Web.Http;
using venta_vehiculos_API.Models;
using venta_vehiculos_API.Servicios;
//using System.Web.Http.Cors;

namespace venta_vehiculos_API.Controllers
{
    //[EnableCors(origins: "http://localhost:54913", headers: "*", methods: "*")]
    public class MarcaController : ApiController
    {
        // GET: api/Estusiante
        public List<Marca> Get()
        {

            MarcaService marca = new MarcaService();


            return marca.ConsultarTodos();
        }

        // GET: api/Estusiante/5
        public Marca Get(int id)
        {
            MarcaService marca = new MarcaService();

            return marca.ConsultarXID(id);
        }

        // POST: api/marca
        public string Post([FromBody] Marca body)
        {
            MarcaService marca = new MarcaService();

            marca.marca = body;


            return marca.Insertar();
        }

        // PUT: api/marca/5
        public string Put([FromBody] Marca body)
        {
            MarcaService marca = new MarcaService();

            marca.marca = body;

            return marca.Actualizar();
        }

        // DELETE: api/marca/5
        public string Delete(int id)
        {
            MarcaService marca = new MarcaService();
            return marca.Eliminar(id);
        }
    }
}