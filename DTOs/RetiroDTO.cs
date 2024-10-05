namespace ChallengeApiAtm.DTOs
{
    public class RetiroDTO
    {
        /// <summary>
        /// Número de la tarjeta asociada
        /// </summary>
        public string NumeroTarjeta { get; set; }

        /// <summary>
        /// Monto a retirar
        /// </summary>
        public decimal Monto { get; set; } 
    }
}
