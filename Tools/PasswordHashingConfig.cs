namespace ChallengeApiAtm.Tools
{
    public class PasswordHashingConfig
    {
        public int SaltSize { get; set; }
        public int KeySize { get; set; }
        public int Iterations { get; set; }
    }
}
