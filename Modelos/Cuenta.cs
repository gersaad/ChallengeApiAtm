using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeApiAtm.Modelos
{
    public class Cuenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string NombreUsuario { get; set; }

        [Required]
        [MaxLength(255)]
        public string NumeroCuenta { get; set; }

        [Required]
        public decimal Saldo { get; set; }
        public virtual Tarjeta Tarjeta { get; set; }
        public virtual ICollection<Operacion>  Operaciones { get; set; }
    }
}
