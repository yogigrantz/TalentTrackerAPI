using Data;
using System.Collections.Generic;
using System.Linq;

namespace Services;

public class ClientService : IClientService
{
    private static List<Client> _clients = new List<Client>()
    {
        new Client { ClientId = 1, CompanyId=1, CompanyName="TechNova", Branch_Dept = "Dallas", ContactName = "Butter Grantz", ContactPhone = "(323) 555-2222" },
        new Client { ClientId = 2, CompanyId=2, CompanyName="CloudPeak", Branch_Dept = "Chicago", ContactName = "Yogi Grantz", ContactPhone = "(323) 555-1212" },
        new Client { ClientId = 3, CompanyId=3, CompanyName="Skyline Systems", Branch_Dept = "NY", ContactName = "Cocoa Grantz", ContactPhone = "(323) 222-1212" },
        new Client { ClientId = 4, CompanyId=2, CompanyName="CloudPeak", Branch_Dept = "LA", ContactName = "Kilo Dog", ContactPhone = "(323) 525-1211" }
    };

    public List<Client> GetAll()
    {
        return _clients;
    }

    public Client? GetById(int id)
    {
        return _clients.FirstOrDefault(c => c.ClientId == id);
    }

    public string Create(Client client)
    {
        _clients.Add(client);
        return $"Candidate {client.CompanyName} added. We now have {_clients.Count} clients";
    }
}
