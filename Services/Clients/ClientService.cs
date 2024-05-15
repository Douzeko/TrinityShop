using Microsoft.EntityFrameworkCore;
using TrinityShop.Models;
using TrinityShop.Models.Client;

namespace TrinityShop.Services.Clients;

public class ClientService
{
    private readonly IDbContextTrinity _Context;

    public ClientService(IDbContextTrinity context)
    {
        _Context = context;
    }
    
    public async Task<List<ClientModel>> GetClients()
    {
        try
        {
            var data = await _Context.Clients.Where(c => c.is_active == true).ToListAsync();
            if (data.Count > 0)
            {
                return data;
            }
            return [];
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return [];
        }
    }
}