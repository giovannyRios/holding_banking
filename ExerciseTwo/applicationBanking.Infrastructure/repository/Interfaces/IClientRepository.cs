using System;
using System.Threading.Tasks;

public interface IclientRepository
{
    public Task<bool> AddClient(Client client);

    public Task<bool> UpdateClient(Client client);

    public Task<bool> DeleteClient(Client client);

    public Task<Client> GetClientById(string id);

    public Task<Client> GetClientByIdentify(string identify);

    public Task<List<Client>> GetClients();
}
