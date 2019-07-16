using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Web.ViewModels;
using System.Threading.Tasks;
using System.Net.Mail;

namespace News.Web.Models
{
    public class ContactModel : PageModel
    {
        public string Email { get; set; }
        [BindProperty]
        public EmailViewModel emails { get; set; }
        public void OnGet()
        {

        }
        public async Task OnPost()
        {
            using (var smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                smtp.PickupDirectoryLocation = @"D:\MyMail";
                var msg = new MailMessage
                {
                    Body = emails.Body,
                    Subject = emails.Subject,
                    From = new MailAddress(emails.From),
                };
                msg.To.Add("uyenphuong1898@gmail.com");
                await smtp.SendMailAsync(msg);
            }
            
        }
    }
}
