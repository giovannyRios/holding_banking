

using applicationBanking.Application.Commons.Utilities;

namespace ApplicationBanking.services.Interfaces
{
    public interface IAccountService
    {
        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> AddAccount(AccountDTO Account);

        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> UpdateAccount(AccountDTO Account);

        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> DeleteAccount(AccountDTO Account);

        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccountById(string id);

        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccountsByClientId(string ClientId);

        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccounts();
    }
}
