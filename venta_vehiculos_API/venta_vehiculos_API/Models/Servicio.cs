using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace venta_vehiculos_API.Models
{
    public class Servicio
    {
        public int id { get; set; }

        public string nombre_servicio { get; set; }

        public string detalle_servicio { get; set; }
    }
}