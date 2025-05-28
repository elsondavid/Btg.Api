using Btg.Core.Services;
using Btg.Model.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Btg.Api.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize]
public class ClienteController(IClienteService clienteService) : ControllerBase
{
   
    [HttpGet, Route("GetAll")]
    public ActionResult<IEnumerable<ClienteResponse>> GetAll(string? searchTerm, bool? isEnabled)
    {
        var clientes = clienteService.GetAll(searchTerm, isEnabled);

        var result = clientes.Select(x => new ClienteResponse
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();

        return result;
    }

   
}