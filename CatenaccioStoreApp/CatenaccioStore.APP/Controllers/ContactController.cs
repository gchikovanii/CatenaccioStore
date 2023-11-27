using CatenaccioStore.APP.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;

namespace CatenaccioStore.APP.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm([FromBody] ContactVM formData)
        {
            try
            {
                if (formData == null)
                {
                    _logger.LogError("Invalid form data: formData is null.");
                    return Json(new { code = 0, message = "Invalid form data." });
                }

                SendEmail(formData.Email, formData.Subject, $"Message from {formData.Name}: {formData.Message}");

                var response = new { code = 1, message = "Form submitted successfully. Email sent!" };
                return Json(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
                var errorResponse = new { code = 0, message = $"Error sending email: {ex.Message}" };
                return Json(errorResponse);
            }
        }

        private void SendEmail(string toAddress, string subject, string body)
        {
            using (SmtpClient smtpClient = new SmtpClient("sandbox.smtp.mailtrap.io", 2525))
            {
                smtpClient.Credentials = new NetworkCredential("0f5028e5f3f2f2", "1d96717c83dc33");
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("catenaccio.geo@gmail.com");
                    mailMessage.To.Add(toAddress);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    smtpClient.Send(mailMessage);
                }
            }
        }
    }
}
