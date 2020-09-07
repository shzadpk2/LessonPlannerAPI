using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace LessonPlanner.Common
{
    public static class EmailHelper
    {
        public static bool SendEmailToUser(string _Subject, string _Body, string _toEmail)
        {
            bool isEmailSent = false;
            try
            {
                string fromEmail = "notification@hexaplay.net";
                string fromEmailPassword = "2lq42u@W";
                string smtpServer = "mail.hexaplay.net";
                int portNo = 587;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(fromEmail);
                mailMessage.To.Add(_toEmail);
                mailMessage.Subject = _Subject;

                mailMessage.Body = _Body;
                mailMessage.IsBodyHtml = true;


                SmtpClient smtpClient = new SmtpClient(smtpServer, portNo);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new
                    System.Net.NetworkCredential(fromEmail, fromEmailPassword);
                smtpClient.Send(mailMessage);


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
