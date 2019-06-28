using System.Linq;
using System.Collections.Generic;
using Webapi.Models;
using System;

namespace Webapi
{
  public class DataSeed
  {
    private readonly ApiContext _context;

    public DataSeed(ApiContext context)
    {
      _context = context;
    }

    public void SeedData(int numberOfCustomers, int numberOfOrders)
    {
      if (!_context.Customers.Any())
      {
        SeedCustomers(numberOfCustomers);
        _context.SaveChanges();
      }

      if (!_context.Orders.Any())
      {
        SeedOrders(numberOfOrders);
        _context.SaveChanges();
      }

      if (!_context.Servers.Any())
      {
        SeedServers();
        _context.SaveChanges();
      }
    }

    private void SeedCustomers(int amount)
    {
      List<Customer> customers = BuildCustomerList(amount);
      _context.AddRange(customers);
    }

    private void SeedOrders(int amount)
    {
      List<Order> orders = BuildOrderList(amount);
      _context.AddRange(orders);
    }

    private void SeedServers()
    {
      List<Server> servers = BuildServerList();
      _context.AddRange(servers);
    }

    private List<Customer> BuildCustomerList(int amount)
    {
      var customers = new List<Customer>();
      var names = new List<string>();

      for (int i = 1; i <= amount; i++)
      {
        string name = Helpers.MakeUniqueCustomerName(names);
        names.Add(name);

        customers.Add(new Customer
        {
          Id = i,
          Name = name,
          Email = Helpers.MakeCustomerEmail(name),
          State = Helpers.GetRandomState()
        });
      }

      return customers;
    }

    private List<Order> BuildOrderList(int amount)
    {
      var orders = new List<Order>();
      var rand = new Random();
      var numberOfCustomers = _context.Customers.Count();

      for (int i = 1; i <= amount; i++)
      {
        int randomCustomerId = rand.Next(1, (numberOfCustomers + 1));
        Customer randomCustomer = _context.Customers
          .First(customer => customer.Id == randomCustomerId);
        DateTime placed = Helpers.GetRandomOrderPlaced();
        DateTime? completed = Helpers.GetRandomOrderCompleted(placed);
        decimal total = Helpers.GetRandomOrderTotal();

        orders.Add(new Order
        {
          Id = i,
          Customer = randomCustomer,
          Total = total,
          Placed = placed,
          Completed = completed
        });
      }

      return orders;
    }

    private List<Server> BuildServerList() =>
      new List<Server>
      {
        new Server
        {
          Id = 1,
          Name = "Dev-Web",
          IsOnline = true
        },
        new Server
        {
          Id = 2,
          Name = "Dev-Email",
          IsOnline = false
        },
        new Server
        {
          Id = 3,
          Name = "Dev-Services",
          IsOnline = false
        },
        new Server
        {
          Id = 4,
          Name = "QA-Web",
          IsOnline = true
        },
        new Server
        {
          Id = 5,
          Name = "QA-Email",
          IsOnline = true
        },
        new Server
        {
          Id = 6,
          Name = "QA-Services",
          IsOnline = true
        },
        new Server
        {
          Id = 7,
          Name = "Prod-Web",
          IsOnline = true
        },
        new Server
        {
          Id = 8,
          Name = "Prod-Email",
          IsOnline = true
        },
        new Server
        {
          Id = 9,
          Name = "Prod-Services",
          IsOnline = true
        }
      };
  }
}