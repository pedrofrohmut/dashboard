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

    public async Task<Order> GetById(int id) =>
      await this.context.Orders
        .Include(order => order.Customer)
        .AsNoTracking()
        .FirstOrDefaultAsync(order => order.Id == id);

    public async Task<IEnumerable<object>> GetSumOfTotalsByCustomerAsync()
    {
      // Async Wrapper For Lack of Async Implementation
      var result = Task.Run(() =>
      {
        var groupedByCustomer = this.context.Orders
          .Include(order => order.Customer)
          .GroupBy(order => order.Customer.Name)
          .AsNoTracking()
          .ToList();

        return groupedByCustomer
          .Select(group => new
          {
            Customer = group.Key,
            CustomerTotal = group.Sum(order => order.Total)
          })
          .OrderByDescending(obj => obj.CustomerTotal)
          .ToList();
      });

      return await result;
    }

    public async Task<IEnumerable<object>> GetSumOfTotalsByStateAsync()
    {
      // Async Wrapper For Lack of Async Implementation
      var result = Task.Run(() =>
      {
        var groupByState = this.context.Orders
          .Include(order => order.Customer)
          .GroupBy(order => order.Customer.State)
          .AsNoTracking()
          .ToList();

        return groupByState
          .Select(group => new
          {
            State = group.Key,
            StateTotal = group.Sum(order => order.Total)
          })
          .OrderByDescending(obj => obj.StateTotal)
          .ToList();
      });

      return await result;
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