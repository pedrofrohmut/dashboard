using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webapi.Models;

namespace Webapi.Services.Implementations
{
  public class ServersService : IServersService
  {
    private readonly ApiContext context;

    public ServersService(ApiContext context)
    {
      this.context = context;
    }

    public async Task<IEnumerable<Server>> GetAllAsync() =>
      await this.context.Servers
        .AsNoTracking()
        .ToListAsync();

    public async Task<Server> GetByIdAsync(int id) =>
      await this.context.Servers
        .AsNoTracking()
        .FirstOrDefaultAsync(server => server.Id == id);

    public async Task SetOfflineAsync(int id)
    {
      var server = await this.context.Servers
        .FirstOrDefaultAsync(_server => _server.Id == id);

      if (server == null) return;

      this.context.Update(server);
      server.IsOnline = false;
      await this.context.SaveChangesAsync();
    }

    public async Task SetOnlineAsync(int id)
    {
      var server = await this.context.Servers
        .FirstOrDefaultAsync(_server => _server.Id == id);

      if (server == null) return;

      this.context.Update(server);
      server.IsOnline = true;
      await this.context.SaveChangesAsync();
    }
  }
}