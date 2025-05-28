
using Btg.Core.Entities;
using Btg.Core.Repository;


namespace Btg.Core.Services;

public interface IClienteService
{
    IList<Cliente> GetAll(string? searchTerm, bool? isEnabled);
}

public class ClienteService : IClienteService
{
    private readonly IGenericRepository<Cliente> _clienteRepository;
  

    public ClienteService(IGenericRepository<Cliente> clienteRepository)
    {
        _clienteRepository = clienteRepository;
       
    }


    public IList<Cliente> GetAll(string? searchTerm, bool? isEnabled)
    {
        var result = _clienteRepository.GetAll();


        return result.ToList();
    }

    
}