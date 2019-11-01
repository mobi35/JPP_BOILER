using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Utilities
{
    public class Email
    {

        [HttpPost]
        public ActionResult<IEnumerable<bool>> EmailSend([FromBody] string emailData, string emailAddress)
        {
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    using (var client = new SmtpClient("smtp.gmail.com", 587))
                    {
                        //provide credentials
                        client.Credentials = new NetworkCredential("jppboilerthesis@gmail.com", "caprojthesis");
                        client.EnableSsl = true;

                       
                        mailMessage.From = new MailAddress("jppboilerthesis@gmail.com");
                        mailMessage.To.Insert(0, new MailAddress(emailAddress));
                        mailMessage.Subject = "JPP BOILER";
                        mailMessage.Body = emailData;
                        //send email
                        client.Send(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // return StatusCode(500);
            }

            return null;
        }


    }
}
