using Btg.Core.Entities;
using Btg.Core.Services;
using Btg.Model.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace Btg.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController(IClientService clientService) : ControllerBase
{

    [HttpGet, Route("Get")]
    public async Task<ActionResult<ClientResponse>> Get(Guid id)
    {
        var client = await clientService.GetClient(id);

        if (client == null)
        {
            return NotFound();
        }
        var model = new ClientResponse
        {
            Id = client.Id,
            Name = client.Name,
            LastName = client.LastName,
            Age = client.Age,
            Andress = client.Andress
        };
        return model;
    }


    [HttpGet, Route("GetAll")]
    public ActionResult<IEnumerable<ClientResponse>> GetAll(string? searchTerm, bool? isEnabled)
    {
        var clients = clientService.GetAll(searchTerm, isEnabled);

        var result = clients.Select(x => new ClientResponse
        {
            Id = x.Id,
            Name = x.Name,
            LastName = x.LastName,
            Age = x.Age,
            Andress = x.Andress
        }).ToList();

        return result;
    }

    [HttpPost, Route("Save")]
    public async Task<ActionResult> Save(SaveClientRequest request)
    {
        var client = new Client
        {
            Id = request.Id,
            Name = request.Name,
            LastName = request.LastName,
            Age = request.Age,
            Andress = request.Andress
        };
        var result = await clientService.Save(client);

        if (result.HasErrors)
        {
            return BadRequest(new { message = client.ErrorsAsString });
        }

        return Ok(result.Id);
    }

    [HttpDelete, Route("Delete")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await clientService.Delete(id);

        if (result == false)
        {
            return NotFound();
        }
        return Ok();
    }
}