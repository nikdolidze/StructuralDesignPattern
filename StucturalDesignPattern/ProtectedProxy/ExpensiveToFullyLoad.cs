using System;
using System.Collections.Generic;
/*
Problem : Need to control access to a type for performance, security, or other reasons.The proxy design pattern is all about controlling access to another instance.
Virtual Proxy is used to stand in for expensive-to-create objects.Itst purpose is genereally to optimize for  performance

The Remote Proxt is used to hide the detail of working with remote data or service.
The Smart proxy performs additional actions when a resource is accesed
The protected Proxy controls access to a sensitive resource by checking  for whether or not the client is authorized to perform those  operations.
*/
namespace ProtectedProxy
{
    public class ExpensiveToFullyLoad : BaseClassWithHistory
    {
        public static ExpensiveToFullyLoad Create()
        {
            return new VirtualExpensiveToFullyLoad();
        }

        public virtual IEnumerable<ExpensiveEntity> HomeEntities { get; protected set; }
        public virtual IEnumerable<ExpensiveEntity> AwayEntities { get; protected set; }

        protected ExpensiveToFullyLoad()
        {
            History.Add("Constructor called.");
        }
    }
}
