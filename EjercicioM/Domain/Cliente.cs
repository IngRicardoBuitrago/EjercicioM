using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioM.Domain
{
    [Table("Clientes")]
    public class Cliente
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ClienteID")]
        public int ClienteID { get; set; }


        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = null!;

        [Required]
        [StringLength(150)]
        public string Email { get; set; } = null!;

        [StringLength(20)]
        public string? Telefono { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool? Activo { get; set; }


    }
}
