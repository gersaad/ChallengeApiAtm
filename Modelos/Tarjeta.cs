using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeApiAtm.Modelos
{
    public class Tarjeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(16)]
        public string NumeroTarjeta { get; set; }

        [ForeignKey("CuentaId")]
        public virtual Cuenta Cuenta { get; set; }
        public virtual TarjetaCredencial TarjetaCredencial { get; set; }
    }
}
