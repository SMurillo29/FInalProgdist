using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace venta_vehiculos_API.ViewModel
{
    public class ContratoViewModel
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int FK_servicio { get; set; }
        public int FK_cliente { get; set; }
        public int FK_vendedor { get; set; }
        public int FK_vehiculo { get; set; }
    }
}