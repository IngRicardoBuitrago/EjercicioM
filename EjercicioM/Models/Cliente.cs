namespace EjercicioM.Models
{
    public class Cliente
    {

        public int ClienteID { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string? Telefono { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool? Activo { get; set; }

    }
}
