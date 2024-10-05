namespace ChallengeApiAtm.Repositorios.Interfaces
{
    public interface IPasswordHasherRepository
    {
        string Hash(string password);
        bool CheckHash(string hash, string password);
    }
}
