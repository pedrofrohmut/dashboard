using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webapi.Models;

namespace Webapi.Services
{
  public interface ICustomersService
  {
    // Create a customer.
    Task<bool> CreateAsync(Customer newCustomer);

    // Get all customers.
    Task<IEnumerable<Customer>> GetAllAsync();

    // Get customer by its id.
    Task<Customer> GetByIdAsync(int id);

    // Update a customer.
    Task<bool> UpdateAsync(Customer updatedCustomer);

    // Delete a customer.
    Task<bool> DeleteAsync(Customer customerToDelete);
  }
}