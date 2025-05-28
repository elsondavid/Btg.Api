
using Btg.Core.Entities;
using Btg.Core.Repository;


namespace Btg.Core.Services;

public interface IClientService
{
    Task<Client?> GetClient(Guid id);
    IList<Client> GetAll(string? searchTerm, bool? isEnabled);    Task<Client> Save(Client client);
    Task<bool> Delete(Guid id);
}

public class ClientService : IClientService
{
    private readonly IGenericRepository<Client> _clientRepository;

    public ClientService(IGenericRepository<Client> clienteRepository)
    {
        _clientRepository = clienteRepository;
    }

    public Task<Client?> GetClient(Guid id)
    {
        return _clientRepository.SingleOrDefaultAsync(x => x.Id == id);
    }

    public IList<Client> GetAll(string? searchTerm, bool? isEnabled)
    {
        var result = _clientRepository.GetAll();

        return result.ToList();
    }

    public async Task<Client> Save(Client client) 
    {
        if (client.Id == default)
        {
            _clientRepository.Add(client);
        }
        else
        {
            _clientRepository.Update(client);
        }
        return client;
    }

    public async Task<bool> Delete(Guid id)
    {
        var count = await _clientRepository.DeleteAsync(id);
        return count > 0;
    }
}