using System;
using System.Collections.Generic;

namespace Webapi
{
  public class Helpers
  {
    private static Random _rand = new Random();

    private static readonly List<string> businessPrefix = new List<string>()
    {
      "ABC", "XYZ", "Main St", "Sales", "Enterprize", "Ready", "Quick",
      "Budge", "Peak", "Magic", "Family", "Confort"
    };

    private static readonly List<string> businessSufix = new List<string>()
    {
      "Corporation", "Co", "Logistics", "Transit", "Bakery", "Goods", "Foods",
      "Cleaners", "Hotels", "Planners", "Automotives", "Books"
    };

    private static readonly List<string> usStates = new List<string>()
    {
      "AK", "AL", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
      "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "MD", "ME",
      "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
      "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
      "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
    };

    private static string GetRandom(IList<string> items) => items[_rand.Next(items.Count)];

    internal static string MakeUniqueCustomerName(List<string> names)
    {
      int limit = businessPrefix.Count * businessSufix.Count;
      if (names.Count >= limit) { return "No names available"; }

      var testCase = MakeCustomerName();
      while (names.Contains(testCase))
      {
        testCase = MakeCustomerName();
      }
      return testCase;
    }

    private static string MakeCustomerName() => $"{GetRandom(businessPrefix)} {GetRandom(businessSufix)}";

    internal static string MakeCustomerEmail(string customerName) => $"{customerName.ToLower()}@email.com";

    internal static string GetRandomState() => GetRandom(usStates);

    internal static decimal GetRandomOrderTotal() => _rand.Next(100, 5000);

    internal static DateTime GetRandomOrderPlaced()
    {
      var end = DateTime.Now;
      var start = end.AddDays(-90);

      TimeSpan possibleTimeSpan = end - start;
      TimeSpan newTimeSpan = new TimeSpan(0, _rand.Next(0, (int)possibleTimeSpan.TotalMinutes), 0);

      return start - newTimeSpan;
    }

    internal static DateTime? GetRandomOrderCompleted(DateTime orderPlaced)
    {
      var now = DateTime.Now;
      var timePassed = now - orderPlaced;

      var minTimeForOrder = TimeSpan.FromDays(7);
      if (timePassed < minTimeForOrder)
      {
        return null;
      }

      return orderPlaced.AddDays(_rand.Next(7, 14));
    }
  }
}