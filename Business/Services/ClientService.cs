using Data.Repositories;
using Domain.Models;

namespace Business.Services;

public class ClientService(ClientRepository clientRepository)
{
    private readonly ClientRepository _clientRepository = clientRepository;

    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        var entities = await _clientRepository.GetAllAsync();
        var clients = entities.Select(e => new Client
        {
            Id = e.Id,
            ClientName = e.ClientName
        });
        return clients;
    }
}
