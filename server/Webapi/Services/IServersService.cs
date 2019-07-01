using System.Collections.Generic;
using System.Threading.Tasks;
using Webapi.Models;

namespace Webapi.Services
{
  public interface IServersService
  {
    // Get all Servers.
    Task<IEnumerable<Server>> GetAllAsync();

    // Get Server by its id.
    Task<Server> GetByIdAsync(int id);

    // Set IsOnline of the server to true.
    Task SetOnlineAsync(int id);

    // Set IsOnline of the server to false.
    Task SetOfflineAsync(int id);
  }
}