using Microsoft.AspNetCore.Mvc;
using Webapi.Services;
using System.Threading.Tasks;
using Webapi.Models;

namespace Webapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class OrdersController : ControllerBase
  {
    private readonly IOrdersService ordersService;

    public OrdersController(IOrdersService ordersService)
    {
      this.ordersService = ordersService;
    }

    /*
      GET api/orders/total_by_customer/{numberOfCustomers}
    */
    [HttpGet("total_by_customer/{numberOfCustomers:int?}", Name = "GetTotalByCustomer")]
    public async Task<ActionResult> GetTotalByCustomer(int numberOfCustomers)
    {
      if (numberOfCustomers > 0)
      {
        return Ok(new
        {
          data = await this.ordersService
            .GetSumOfTotalsByCustomerAsync(numberOfCustomers)
        });
      }

      return Ok(new
      {
        data = await this.ordersService.GetAllSumOfTotalsByCustomerAsync()
      });
    }

    /*
      GET api/orders/{id}
    */
    [HttpGet("{id:int}", Name = "GetById")]
    public async Task<ActionResult<Order>> GetById(int id)
    {
      if (id < 0)
      {
        return BadRequest(new { message = "Invalid Id for Order" });
      }

      var data = await this.ordersService.GetByIdAsync(id);

      if (data == null)
      {
        return NotFound(new { message = "No user found with the passed Id" });
      }

      return Ok(new { data });
    }

    /*
      GET api/orders/total_by_state
    */
    [HttpGet("total_by_state", Name = "GetTotalByState")]
    public async Task<ActionResult> GetTotalByState()
    {
      return Ok(new
      {
        data = await this.ordersService.GetAllSumOfTotalsByStateAsync()
      });
    }

    /*
      GET api/orders/{pageNumber}/{pageSize}
     */
    [HttpGet("page/{pageIndex:int}/{pageSize:int}", Name = "GetPage")]
    public async Task<ActionResult> GetPage(int pageIndex, int pageSize)
    {
      int pagesCount = await this.ordersService.GetPagesCountAsync(pageSize);

      if (pageIndex < 1 || pageSize < 1 || pageIndex > pagesCount)
      {
        return BadRequest(new
        {
          message = "Invalid number for pageIndex and/or page Size"
        });
      }

      var data = await this.ordersService.GetPageAsync(pageIndex, pageSize);
      return Ok(new { data, pagesCount });
    }
  }
}