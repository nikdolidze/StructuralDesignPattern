using System.Threading.Tasks;

namespace Adapter4.business_logic
{
    public interface IUserNotificationService
    {
        Task NotifyUser(string userId, string message);
    }
}
