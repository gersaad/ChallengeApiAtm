using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeApiAtm.Modelos
{
    public class Operacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Monto { get; set; }
        public TipoOperacion Tipo { get; set; }

        [ForeignKey("CuentaId")]
        public int CuentaId { get; set; }
        public virtual Cuenta Cuenta { get; set; }

    }

    public enum TipoOperacion
    {
        Extraccion,
        Deposito
    }
}
