using System;
/*
 it is intended to provide a higher level interface over a subsystem to make  the subsistem easier to use.
The intent of this pattern is to provide a unified interface to a set of interfaces in a subsystem. it defines a higher-level interface that makes a subsystem easier to use.
Facade knows whitch subsystem classes are responsible for a request , and delegates client requests to approptiate subsystem objcets.
 */
namespace Facade
{   /// <summary>
/// Subsystem classs
/// </summary>
    public class OrderService
    {
        public bool HasEnoughOrders(int customerId)
        {
            return customerId > 5;
        }
    }
    /// <summary>
    ///    Subsystem classs 
    /// </summary>
    public class CustomerDiscoutBaseService
    {
        public double CalculateDicoutnBase(int cusomerid)
        {
            return cusomerid > 8 ? 10 : 20;
        }
    }

    public class DayOfTheWeekFactoryService
    {
        public double CalculateDayOfWeekFactor()
        {
            switch (DateTime.UtcNow.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                case DayOfWeek.Saturday:
                    return 0.8;
                default:
                    return 1.2;
            }
        }
    }

    public class DiscoutFacade
    {
        private readonly OrderService orderService = new();
        private readonly CustomerDiscoutBaseService customerDiscoutBaseService = new();
        private readonly DayOfTheWeekFactoryService dayOfTheWeekFactoryService = new();

        public double CalculateDiscountPercentage(int customerid)
        {
            if (!orderService.HasEnoughOrders(customerid))
            {
                return 0;
            }
            return customerDiscoutBaseService.CalculateDicoutnBase(customerid)
                * dayOfTheWeekFactoryService.CalculateDayOfWeekFactor();
        }
    }

}
