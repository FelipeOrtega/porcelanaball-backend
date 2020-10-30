namespace PB.Domain.Notifications
{
    public class Notification
    {
        public string ErrorMessage { get; }

        public Notification(string message)
        {
            ErrorMessage = message;
        }
    }
}
