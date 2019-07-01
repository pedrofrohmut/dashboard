using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Webapi.Models;
using System.Threading.Tasks;
using Webapi.Services;

namespace Webapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomersController : ControllerBase
  {
    private readonly ICustomersService customerService;

    public CustomersController(ICustomersService customerService)
    {
      this.customerService = customerService;
    }

    /*
      GET api/customers
     */
    [HttpGet(Name = "GetAllCustomers")]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
    {
      return Ok(new
      {
        data = await this.customerService.GetAllAsync()
      });
    }
    /*
      GET api/customers/5
   */
    [HttpGet("{id:int}", Name = "GetCustomerById")]
    public async Task<ActionResult<Customer>> GetById(int id)
    {
      var data = await this.customerService.GetByIdAsync(id);
      if (data == null)
      {
        return NotFound(new { message = "No customer found with passed Id" });
      }
      return Ok(new { data });
    }

    /*
      POST api/customers
      {
        "Name": "customer-name",
        "Email": "customer-email",
        "State": "customer-state"
      }
     */
    [HttpPost(Name = "CreateACustomer")]
    public async Task<ActionResult> Create([FromBody] Customer newCustomer)
    {
      if (newCustomer == null)
      {
        return BadRequest(new { message = "Invalid request. The User was Null." });
      }
      await this.customerService.CreateAsync(newCustomer);
      return CreatedAtRoute("GetCustomerById", new { id = newCustomer.Id }, newCustomer);
    }

    /*
      PUT api/customers/5
      {
        "Id": 5,
        "Name": "customer-name",
        "Email": "customer-email",
        "State": "customer-state"
      }
     */
    [HttpPut("{id:int}", Name = "UpdateACustomer")]
    public async Task<ActionResult> UpdateAsync(int id, [FromBody] Customer updatedCustomer)
    {
      if (id < 0 || id != updatedCustomer.Id)
      {
        return BadRequest(new
        {
          message = "The id and updated customer Id does not match."
        });
      }

      var customer = await this.customerService.GetByIdAsync(id);
      if (customer == null)
      {
        NotFound(new
        {
          message = "There is no user found with the parameter id passed."
        });
      }

      await this.customerService.UpdateAsync(updatedCustomer);
      return Ok(new { message = "Customer Updated" });
    }

    /*
      DELETE api/customers/5
     */
    [HttpDelete("{id:int}", Name = "DeleteACustomer")]
    public async Task<ActionResult> Delete(int id)
    {
      var customer = await this.customerService.GetByIdAsync(id);
      if (customer == null)
      {
        return BadRequest(new
        {
          message = "No customer found with the passed id. No rows affected"
        });
      }

      await this.customerService.DeleteAsync(customer);
      return Ok(new
      {
        message = "Customer successfully deleted from persistence"
      });
    }
  }
}