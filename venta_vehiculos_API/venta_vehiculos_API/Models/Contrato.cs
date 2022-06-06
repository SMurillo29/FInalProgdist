using System;

namespace venta_vehiculos_API.Models
{
    public class Contrato
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public Servicio FK_servicio { get; set; }
        public Usuario FK_cliente { get; set; }
        public Usuario FK_vendedor { get; set; }
        public Vehiculo FK_vehiculo { get; set; }

    }

}