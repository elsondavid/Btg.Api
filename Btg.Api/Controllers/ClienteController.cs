using Btg.Core.Services;
using Btg.Model.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Btg.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController(IClientService clientService) : ControllerBase
{
   
    [HttpGet, Route("GetAll")]
    public ActionResult<IEnumerable<ClientResponse>> GetAll(string? searchTerm, bool? isEnabled)
    {
        var clients = clientService.GetAll(searchTerm, isEnabled);

        var result = clients.Select(x => new ClientResponse
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();

        return result;
    }
}