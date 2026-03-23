using Data;
using System.Collections.Generic;

namespace Services
{
    public interface IClientService
    {
        string Create(Client client);
        List<Client> GetAll();
        Client? GetById(int id);
    }
}