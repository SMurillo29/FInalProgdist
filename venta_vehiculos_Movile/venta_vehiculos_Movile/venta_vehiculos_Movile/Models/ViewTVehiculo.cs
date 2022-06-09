using SQLite;

namespace venta_vehiculos_Movile.Models
{
    [Table("tipo_vehiculo")]
    class ViewTVehiculo
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(30)]
        public string nombre_tipo_vehiculo { get; set; }
    }
}

