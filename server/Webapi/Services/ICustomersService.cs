using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webapi.Models;

namespace Webapi.Services
{
  public interface ICustomersService
  {
    // Create
    Task<bool> CreateAsync(Customer newCustomer);

    // Read
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> GetByIdAsync(int id);

    // Update
    Task<bool> UpdateAsync(Customer updatedCustomer);

    // Delete
    Task<bool> DeleteAsync(Customer customerToDelete);
  }
}