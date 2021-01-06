using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelAgency.Models;

namespace TravelAgency.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactFormModel Contact { get; set; }
        public async Task OnGetAsync()
        {
            Contact = new ContactFormModel();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // create and send the mail here
            var mailbody = $@"Hello website owner,

                This is a new contact request from your website:

                Name: {Contact.Name}
                LastName: {Contact.LastName}
                Email: {Contact.Email}
                Message: ""{Contact.Message}""


                Cheers,
                The websites contact form";

            SendMail(mailbody);
            return RedirectToPage("Index");
        }

        private void SendMail(string mailbody)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("xavier.burzig@gmail.com");
                mail.To.Add("xavier.burzig@gmail.com");
                mail.Subject = "Hello World";
                mail.Body = mailbody;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    #region HIDDEN PASSWORD
                    smtp.Credentials = new NetworkCredential("xavier.burzig@gmail.com", "YOURMDP");
                    #endregion

                    smtp.EnableSsl = true;
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception exp)
                    {
                        //Log if any errors occur
                        Console.WriteLine(exp);
                    }
                    
                }
            }
        }
    }
}