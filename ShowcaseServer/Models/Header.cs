using ShowcaseServer.Interface;

namespace ShowcaseServer.Models
{
    public class Header
    {
        public string Sender { get; set; }
        public string SenderName { get; set; }

        public string? Recipient { get; set; }
        public string? RecipientName { get; set; }

        public Header(string sender, string senderName, string recipient, string recipientName)
        {
            Sender = sender;
            SenderName = senderName;
            Recipient = recipient;
            RecipientName = recipientName;
        } 
    }
}
