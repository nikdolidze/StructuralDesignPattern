using Adapter4.business_logic;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
/*
  The rason it's called an adapter or a wrapper because usually you take some kind of dependency that might change in ther future and you wrap it in your logic to make it fit into
your whole businnes use cases
    The object adapter takes in the adaptee or whatewer we're adapting thar generic thing in ther constructor and then we maintain the pointer to it and we invoke whatever functions
into it. the class adapter  rather then receivieng  the thing  and pinting to it 
 */
namespace Adapter4
{
    public class ClassAdapter : SendGridClient, IUserNotificationService
    {
        public ClassAdapter(SendGridClientOptions options) : base(options)
        {
        }

        public Task NotifyUser(string userId, string message)
        {
            return SendEmailAsync(new SendGridMessage());
        }
    }

   
}
