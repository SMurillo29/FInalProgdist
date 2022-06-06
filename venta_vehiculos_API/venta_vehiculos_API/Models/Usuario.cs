using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace venta_vehiculos_API.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public Rol FKrol { get; set; }

    }	
	
}