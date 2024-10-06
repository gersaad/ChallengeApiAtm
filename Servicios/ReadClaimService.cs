using System.Security.Claims;

namespace ChallengeApiAtm.Servicios
{
    public class ReadClaimService : IReadClaimService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReadClaimService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string ObtejerNumeroTarjetaLogueado()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext is not null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue("NumeroTarjeta");
            }
            return result;
        }
    }
}
