using Adapter4.business_logic;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Adapter4
{
    public class ObjectAdapter : IUserNotificationService
    {
        private readonly SendGridClient client;

        public ObjectAdapter(SendGridClient client)
        {
            this.client = client;
        }

        public Task NotifyUser(string userId, string message)
        {
            return client.SendEmailAsync(new SendGridMessage());
        }
    }
}
