using ShowcaseServer.Interface;
using ShowcaseServer.Models;

namespace ShowcaseServer.Services
{
    public class MailHandler
    {

        public IMail CreateMail(Header header,Body body)
        {
            return new Mail(header, body);
        }
    }
}
