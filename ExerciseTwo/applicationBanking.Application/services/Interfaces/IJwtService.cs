
using ApplicationBanking.Application.Models;

namespace ApplicationBanking.services.Interfaces
{
    public interface IJwtService
    {
        public string generateToken(JWT_Values jWT_Values, Dictionary<string, string> customValues);

        public bool validateToken(string token, JWT_Values jWT_Values);

    }
}
