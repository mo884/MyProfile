using System.Net.Mail;
using System.Net;
using MyProfile.BL.ModelVM;

namespace MyProfile.BL.Helper
{
    public static class MailSender
    {
        public static string SendEmail(MailVM mail)
        {
            try
            {
                var smtp = new SmtpClient("smtp.office365.com", 587);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Timeout = 100000;
                smtp.Credentials = new NetworkCredential("mohamedessam77740@outlook.com", "AKDDDRERE234%", "FRYMA");
                //Sender  / reciever / body/message
                MailMessage MailMessage = new MailMessage("mohamedessam77740@outlook.com", mail.Email);
                MailMessage.Subject = mail.Email;
                MailMessage.IsBodyHtml = true;
                MailMessage.Body = $"<h3 style='color:red;'>{mail.Message}</h3>";
                smtp.Send(MailMessage);
                return "Succeed";
            }
            catch (Exception ex)
            {
                return "Faild";
            }
        }
    }
}
