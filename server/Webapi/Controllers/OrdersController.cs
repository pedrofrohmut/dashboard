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
      GET api/orders/total_by_customer
    */
    [HttpGet("total_by_customer", Name = "GetTotalByCustomer")]
    public async Task<ActionResult> GetTotalByCustomer()
    {
      return Ok(new
      {
        Data = await this.ordersService.GetSumOfTotalsByCustomerAsync()
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
        return BadRequest(new { Message = "Invalid Id for Order" });
      }

      var data = await this.ordersService.GetById(id);

      if (data == null)
      {
        return NotFound(new { Message = "No user found with the passed Id" });
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
        data = await this.ordersService.GetSumOfTotalsByStateAsync()
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
        return BadRequest("Invalid number for pageIndex and/or page Size");
      }

      return Ok(new
      {
        data = await this.ordersService.GetPageAsync(pageIndex, pageSize),
        pages_count = pagesCount
      });
    }
  }
}