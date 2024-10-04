using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeApiAtm.Modelos
{
    public class TarjetaCredencial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        public string PinHash { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueada { get; set; }

        [ForeignKey("TarjetaId")]
        public int TarjetaId { get; set; }
        public virtual Tarjeta Tarjeta { get; set; }
    }
}
