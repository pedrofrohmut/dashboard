using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webapi.JsonModels;
using Webapi.Models;
using Webapi.Services;

namespace Webapi.Controllers
{
  public class ServersController : ControllerBase
  {
    private readonly IServersService serversService;

    public ServersController(IServersService serversService)
    {
      this.serversService = serversService;
    }

    /*
      GET api/servers
    */
    [HttpGet(Name = "GetAll")]
    public async Task<ActionResult<IEnumerable<Server>>> GetAll()
    {
      return Ok(await this.serversService.GetAllAsync());
    }

    /*
      GET api/servers/{id}
    */
    [HttpGet("{id:int}", Name = "GetById")]
    public async Task<ActionResult<Server>> GetById(int id)
    {
      if (id <= 0)
      {
        return BadRequest(new { message = "Invalid value for Id" });
      }

      var data = await this.serversService.GetByIdAsync(id);

      if (data == null)
      {
        return NotFound(new { message = "No Server found with the passed Id" });
      }

      return Ok(new { data });
    }

    /*
      PUT api/servers/message/{id}
    */
    [HttpPut("message/{id:int}")]
    public async Task<ActionResult> SendServerMessage(
      int id,
      [FromBody] ServerMessage serverMessage
    )
    {
      if (id < 0)
      {
        return BadRequest(new { message = "The passed Id is not valid." });
      }

      var server = await this.serversService.GetByIdAsync(id);

      if (server == null)
      {
        return NotFound(new { message = "Server Not Found." });
      }

      if (serverMessage.Payload == "activate")
      {
        await this.serversService.SetOnlineAsync(id);
      }

      if (serverMessage.Payload == "deactivate")
      {
        await this.serversService.SetOfflineAsync(id);
      }

      return NoContent();
    }
  }
}