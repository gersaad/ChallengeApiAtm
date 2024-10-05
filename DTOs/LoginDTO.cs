namespace ChallengeApiAtm.DTOs
{
    public class LoginDTO
    {
        /// <summary>
        ///  Numero de Tarjeta
        /// </summary>
        public string NumeroTarjeta { get; set; }

        /// <summary>
        ///  Pin / Password  
        /// </summary>
        public string Pin { get; set; }
    }
}
