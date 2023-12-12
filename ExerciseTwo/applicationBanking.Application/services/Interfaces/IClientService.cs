using applicationBanking.Application.Commons.Utilities;

namespace ApplicationBanking.services.Interfaces
{
    public interface IClientService
    {
        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> AddClient(ClientDTO client);

        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> UpdateClient(ClientDTO client);

        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> DeleteClient(ClientDTO client);

        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetClientById(string id);

        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetClientByIdentify(string identify);

        public Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetClients();
    }
}
