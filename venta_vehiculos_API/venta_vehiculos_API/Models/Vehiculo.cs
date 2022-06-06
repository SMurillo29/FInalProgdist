namespace venta_vehiculos_API.Models
{
    public class Vehiculo
    {
        public int id { get; set; }
        public double kilometraje { get; set; }
        public double precio { get; set; }
        public string color { get; set; }
        public Tvehiculo fktipo { get; set; }
        public Marca fkmarca { get; set; }

    }
}