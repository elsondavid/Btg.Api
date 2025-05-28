
using Btg.Core.Entities;
using Btg.Core.Repository;


namespace Btg.Core.Services;

public interface IClientService
{
    IList<Client> GetAll(string? searchTerm, bool? isEnabled);
}

public class ClientService : IClientService
{
    private readonly IGenericRepository<Client> _clientRepository;
  

    public ClientService(IGenericRepository<Client> clienteRepository)
    {
        _clientRepository = clienteRepository;
       
    }


    public IList<Client> GetAll(string? searchTerm, bool? isEnabled)
    {
        var result = _clientRepository.GetAll();


        return result.ToList();
    }

    
}