using System.Threading.Tasks;
using Webapi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Webapi.Services.Implementations
{
  public class OrdersService : IOrdersService
  {
    private readonly ApiContext context;

    public OrdersService(ApiContext context)
    {
      this.context = context;
    }

    public async Task<IEnumerable<Order>> GetPageAsync(int pageIndex, int pageSize) =>
      await this.context.Orders
        .Include(order => order.Customer)
        .OrderByDescending(order => order.Placed)
        .Skip((pageIndex - 1) * pageSize)
        .Take(pageSize)
        .AsNoTracking()
        .ToListAsync();

    public async Task<int> GetPagesCountAsync(int pageSize) =>
      await this.context.Orders
        .CountAsync();
  }
}