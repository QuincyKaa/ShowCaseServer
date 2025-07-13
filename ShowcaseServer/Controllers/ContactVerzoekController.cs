using Microsoft.AspNetCore.Mvc;
using ShowcaseServer.Interface;
using ShowcaseServer.Models;

namespace ShowcaseServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ContactVerzoekController : Controller
    {

        public IMailSender Mailer { get; set; }

        public ContactVerzoekController(IMailSender mailer)
        {
            Mailer = mailer;
        }

        private bool ValidateForm(Mail mail)
        {
            int SenderNameLength = mail.Header.SenderName.Length;
            int SubjectLength = mail.Body.Subject.Length;
            int MessageLength = mail.Body.Message.Length;
            if ((3 <= SenderNameLength && SenderNameLength <= 120) && (3 <= SubjectLength && SubjectLength <= 200) && (3 <= MessageLength && MessageLength <= 600) && ValidateMail(mail.Header.Sender))
            {
                return true;
            }
            return false;



        }
        private bool ValidateMail(string mail)
        {
            if ((mail.Contains("@") && mail.IndexOf("@") > 0 && mail.LastIndexOf("@") < mail.Length - 1) && (8 <= mail.Length && mail.Length <= 50) && !mail.Contains(" "))
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Mail mail)
        {
            var apiKey = Request.Headers["API-Key"].FirstOrDefault();
            if (apiKey != "re58oWajrf")
            {
                return Content("Het verzenden is niet gelukt, probeer het later opnieuw");
            }
            if (ValidateForm(mail) != true)
            {
                return Content("Het verzenden is niet gelukt, probeer het later opnieuw");
            }
            else
            {
                Mailer.Send(mail);
                return Content("Het verzenden is gelukt");
            }

        }
    }
}
