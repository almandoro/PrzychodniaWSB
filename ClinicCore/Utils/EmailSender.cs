using Microsoft.Extensions.Logging;
using PrzychodniaWSB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.ClinicCore.Utils {
    public class EmailSender {
        public static void Email(string htmlString,string receiver,string title = "Przychodnia WSB") {
            try {
                MailMessage message = new MailMessage();
                var smtp = new SmtpClient();
                message.From = new MailAddress("medicalcare@gmail.com");
                message.To.Add(new MailAddress(receiver));
                message.Subject = title;
                message.IsBodyHtml = true;
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("medicalcarewsb@gmail.com", "Dupa1234");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Logger.debug(e.Message); }
        }
    }
}
