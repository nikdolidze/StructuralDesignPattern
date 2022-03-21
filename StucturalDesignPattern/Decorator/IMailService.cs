using System;
using System.Collections.Generic;
/*
this pattern allows  adding behavior dynamically to an individual object without affecting the bahaviour of other instance of the same class. It's sometimes referred to as a wrapper,witch is something 
the adapter is also simetimes referred to as. 
The intennt of this pattern is to attach  additional respoonsibilities  to an object dynamically. A decorator thus provides  a flexible   alternative to subclassing for extending functionality.
Component defines the interface for objects that can have responsibilities added to them dynamically, ConcreateComponenet defines an object to wich additional responsibilities can be attached. the other 
omplementnaion of componenets structurally called the decorator.
*/
namespace Decorator
{
    //Component (as interface)
    public interface IMailService
    {
        bool SendMail(string message);
    }
    public class CloudMainServer : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" " +
                $"sent via {nameof(CloudMainServer)}");
            return true;    
        }
    }
    public class OnPremiseMainService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" " +
                          $"sent via {nameof(OnPremiseMainService)}");
            return true;
        }
    }
    /// <summary>
    ///     Decorator
    /// </summary>
    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;

        public MailServiceDecoratorBase(IMailService mailService)
        {
            this._mailService = mailService;
        }
        public virtual bool SendMail(string message)
        {
         return  _mailService.SendMail(message);
        }
    }
    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService)
        {
        }
        public override bool SendMail(string message)
        {
            Console.WriteLine($"Collecting statistics is {nameof(StatisticsDecorator)}");
            return base.SendMail(message);  
        }
    }

    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        public List<string> SentMessages { get; private set; } = new List<string>();
        public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
        {
        }

        public override bool SendMail(string message)
        {
            if(base.SendMail(message))
            {
                SentMessages.Add(message);
                return true;
            }
            return false;
        }
    }

}







