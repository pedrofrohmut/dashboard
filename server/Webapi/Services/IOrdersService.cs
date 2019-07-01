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
  }
}