
using applicationBanking.Application.Commons.Utilities;

namespace ApplicationBanking.services.Interfaces
{
    public interface IAccountMovementService
    {
        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> AddAccountMovement(AccountMovementDTO AccountMovement);
		
        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccountMovementById(string id);

        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccountMovementsByAccountId(string AccountId);

        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccountMovementsByAccountIdAndDate(string AccountId, string date);
        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccountMovements();
    }
}
