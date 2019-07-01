using System.Collections.Generic;
using System.Threading.Tasks;
using Webapi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Webapi.Services.Implementations
{
  public class CustomersService : ICustomersService
  {
    private readonly ApiContext context;

    public CustomersService(ApiContext context)
    {
      this.context = context;
    }

    public async Task<bool> CreateAsync(Customer newCustomer)
    {
      var customerId = (await this.context.Customers.CountAsync()) + 1;
      newCustomer.Id = customerId;
      this.context.Customers.Add(newCustomer);
      int rowsAffected = await this.context.SaveChangesAsync();
      return rowsAffected == 1;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync() =>
      await this.context.Customers
        .OrderBy(customer => customer.Id)
        .ToListAsync();

    public Customer GetById(int id) =>
      this.context.Customers
        .FirstOrDefault(customer => customer.Id == id);

    public async Task<Customer> GetByIdAsync(int id) =>
      await this.context.Customers
        .FirstOrDefaultAsync(customer => customer.Id == id);

    public async Task<bool> UpdateAsync(Customer updatedCustomer)
    {
      int rowsAffected = 0;
      Customer oldCustomer = await this.context.Customers
        .FirstOrDefaultAsync(customer => customer.Id == updatedCustomer.Id);
      if (oldCustomer != null)
      {
        oldCustomer.Name = updatedCustomer.Name;
        oldCustomer.Email = updatedCustomer.Email;
        oldCustomer.State = updatedCustomer.State;
        rowsAffected = await this.context.SaveChangesAsync();
      }
      return rowsAffected == 1;
    }

    public async Task<bool> DeleteAsync(Customer customerToDelete)
    {
      this.context.Customers.Remove(customerToDelete);
      int rowsAffected = await this.context.SaveChangesAsync();
      return rowsAffected == 1;
    }
  }
}