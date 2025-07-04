using ShowcaseServer.Interface;

namespace ShowcaseServer.Models
{
    public class Body
    {
        public string Subject { get; set; }
        public string Message { get; set; }

        public Body(string subject, string message)
        {
            Subject = subject;
            Message = message;
        }

    }
}
