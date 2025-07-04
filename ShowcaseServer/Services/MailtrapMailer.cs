using SendGrid;
using ShowcaseServer.Interface;
using System.Data;
using System.Net.Mail;
using System.Net;


namespace ShowcaseServer.Services
{
    public class MailtrapMailer:IMailSender
    {
        private SmtpClient Connect()
        {
            return new SmtpClient(Config.Mailtraphost, Config.MailtrapPort)
            {
                Credentials = new NetworkCredential(Config.MailtrapUser,Config.MailtrapPassword),
                EnableSsl = true
            };
        }

        public void Send(IMail mail)
        {
            SmtpClient client = Connect();
            client.Send(mail.Header.Sender, "Me@gmail.com", $"Contactverzoek van: {mail.Header.SenderName} ({mail.Body.Subject})", $"{mail.Header.SenderName} van {mail.Header.Sender} heeft hetvolgende gestuurd: \n\n{mail.Body.Message}");
        }
    }
}


