using System.Threading.Tasks;
using Webapi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Webapi.JsonModels;
using System;

namespace Webapi.Services.Implementations
{
  public class OrdersService : IOrdersService
  {
    private readonly ApiContext context;

    public OrdersService(ApiContext context)
    {
      this.context = context;
    }

    public async Task<IEnumerable<TotalFromCustomers>> GetAllSumOfTotalsByCustomerAsync()
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
          .Select(group => new TotalFromCustomers
          {
            CustomerName = group.Key,
            CustomerTotal = group.Sum(order => order.Total)
          })
          .OrderByDescending(obj => obj.CustomerTotal)
          .ToList();
      });

      return await result;
    }

    public async Task<Order> GetByIdAsync(int id) =>
      await this.context.Orders
        .Include(order => order.Customer)
        .AsNoTracking()
        .FirstOrDefaultAsync(order => order.Id == id);

    public async Task<IEnumerable<TotalFromCustomers>> GetSumOfTotalsByCustomerAsync(
      int numberOfCustomers
    )
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
          .Take(numberOfCustomers)
          .Select(group => new TotalFromCustomers
          {
            CustomerName = group.Key,
            CustomerTotal = group.Sum(order => order.Total)
          })
          .OrderByDescending(obj => obj.CustomerTotal)
          .ToList();
      });

      return await result;
    }

    public async Task<IEnumerable<TotalFromStates>> GetAllSumOfTotalsByStateAsync()
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
          .Select(group => new TotalFromStates
          {
            StateName = group.Key,
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

    public async Task<int> GetPagesCountAsync(int pageSize)
    {
      int ordersCount = await this.context.Orders.CountAsync();
      // extra step to make compiler work
      double val = ordersCount / pageSize;
      return (int) Math.Ceiling(val);
    }
  }
}
