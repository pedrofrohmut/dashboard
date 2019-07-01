using Microsoft.AspNetCore.Mvc;
using Webapi.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
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
      GET api/orders/pageNumber/pageSize
     */
    [HttpGet("page/{pageIndex:int}/{pageSize:int}")]
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