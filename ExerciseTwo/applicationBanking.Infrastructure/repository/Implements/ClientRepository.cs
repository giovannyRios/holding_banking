using Microsoft.EntityFrameworkCore;
using System;

public class ClientRepository : IclientRepository
{
    private readonly bankingContext _context;

    public ClientRepository(bankingContext context)
    {
        _context = context;
    }

    public async Task<bool> AddClient(Client client)
    {
        _context.Clients.Add(client);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteClient(Client client)
    {
        _context.Clients.Remove(client);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Client> GetClientById(string id)
    {
        Client client = await _context.Clients.Where(c => c.id == id).FirstOrDefaultAsync();
        return client;
    }

    public async Task<Client> GetClientByIdentify(string identify)
    {
        if (_context.Clients.Any(c => c.identify == identify))
        {
			Client client = await _context.Clients.Where(c => c.identify == identify).FirstOrDefaultAsync();
			return client;
        }
        else
        {
            return null;
        }
        
	}

    public async Task<List<Client>> GetClients()
    {
        return await _context.Clients.OrderByDescending(p => p.name).ToListAsync();
    }

    public async Task<bool> UpdateClient(Client client)
    {
        bool result = false;
        Client Findclient = await _context.Clients.Where(c => c.id == client.id).FirstOrDefaultAsync();
        if (Findclient != null)
        {
            Findclient.identify = client.identify;
            Findclient.name = client.name;
            result = await _context.SaveChangesAsync() > 0;
        }

        return result;
    }
}
