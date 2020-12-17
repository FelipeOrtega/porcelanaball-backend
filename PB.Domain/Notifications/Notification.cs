namespace PB.Domain.Notifications
{
    public class Notification
    {
        public string errorMessage { get; }

        public Notification(string message)
        {
            errorMessage = message;
        }
    }
}
