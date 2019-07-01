using System.Threading.Tasks;
using System.Collections.Generic;
using Webapi.Models;

namespace Webapi.Services
{
  public interface IOrdersService
  {
    /*
      Return a limited number of orders based on a page index a size
    */
    Task<IEnumerable<Order>> GetPageAsync(int pageIndex, int pageSize);

    /*
      Return the total number of pages counting the orders in the database and
      calculating the page number based in the pageSize passed.
    */
    Task<int> GetPagesCountAsync(int pageSize);

    /*
      Return a list of objects with state name and the sum of the total from the
      orders of that state.
    */
    Task<IEnumerable<object>> GetSumOfTotalsByStateAsync();

    /*
      Return a list of object with the customer name and the sum of the total from
      the orders of that customer
    */
    Task<IEnumerable<object>> GetSumOfTotalsByCustomerAsync();

    /*
      Returns Order by its id
    */
    Task<Order> GetById(int id);
  }
}