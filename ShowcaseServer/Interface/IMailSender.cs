using SendGrid;

namespace ShowcaseServer.Interface
{
    public interface IMailSender
    {
        public void Send(IMail mail);
        
    }
}
