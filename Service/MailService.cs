using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Service
{
	public  class MailService : IMailService
	{
		private readonly SmtpClient smtpClient;
		private readonly string fromEmail;

		public MailService(IConfiguration configuration)
		{
			smtpClient = new SmtpClient("smtp.gmail.com")
			{
				Port = 587,
				Credentials = new NetworkCredential(
					configuration["EmailSettings:Username"],
					configuration["EmailSettings:Password"]),
				EnableSsl = true,
			};

			fromEmail = configuration["EmailSettings:FromEmail"]!;
		}
		public async Task SendMail(string toMail)
		{
			var mailMessage = new MailMessage
			{
				From = new MailAddress(fromEmail),
				Subject = "test",
				Body = "test",
				IsBodyHtml = true,
			};

			mailMessage.To.Add(toMail);

			await smtpClient.SendMailAsync(mailMessage);
		}
		public async Task SendRevoceryMail(string toMail,string link)
		{
			var mailMessage = new MailMessage
			{
				From = new MailAddress(fromEmail),
				Subject = "Reset Password - My Dental Health",
				Body = $"<html><body><a href={link}>Reset Password<a></body></html>",
				IsBodyHtml = true,
			};

			mailMessage.To.Add(toMail);

			await smtpClient.SendMailAsync(mailMessage);
		}
	}
}
