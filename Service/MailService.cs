﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Drawing;

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
		public async Task SendRevoceryMail(string toMail, string name, string link)
		{
			var mailMessage = new MailMessage
			{
				From = new MailAddress(fromEmail),
				Subject = "Reset Password - My Dental Health",
				/*Body = "<!DOCTYPE html><html><head></head><body style=\"display:flex;width:100%;justify-content:center;background-color:#c3c3c3;font-family:system-ui, -apple-system, &quot;Segoe UI&quot;, Roboto, &quot;Helvetica Neue&quot;, Arial, &quot;Noto Sans&quot;, &quot;Liberation Sans&quot;, sans-serif, &quot;Apple Color Emoji&quot;, &quot;Segoe UI Emoji&quot;, &quot;Segoe UI Symbol&quot;, &quot;Noto Color Emoji&quot;;\"><div style=\"background-color:white;border:white;border-radius:5px;margin:5rem 1rem 5rem 1rem;padding:2rem;\"><div style=\"padding-left:1rem;\"><p class=\"boxheader\"style=\"font-size:2rem;\">Reset Password</p></div><hr><div style=\"font-size:2rem;\"><p>Hi " +
				$"{name}" +
				",</p><p>My Dental Health Customer, there was recently a request to change the password on your account.<br>There is your password reset link</p><a href=\"" +
				$"{link}" +
				"\"style=\"border:0.1rem;border-style:solid;border-color:blue;border-radius:0.5rem;background:blue;color:white;text-decoration:none;padding:0.8rem;display:inline-block;transition:0.2s;\"> Reset Password </a></div></div></body></html>",
				*/
				Body = "<!DOCTYPE html><html><head><meta http-equiv=\"Content-Type\" content=\"text/html\"; charset=\"windows-1252\"></head><body style=\"width: 100%;background-color:#c3c3c3;font-family:system-ui, -apple-system, \"Segoe UI\", Roboto, \"Helvetica Neue\", Arial, \"Noto Sans\", \"Liberation Sans\", sans-serif, \"Apple Color Emoji\", \"Segoe UI Emoji\", \"Segoe UI Symbol\", \"Noto Color Emoji\";\"><table style=\"width: 100%;background-color:#c3c3c3;\"><tbody><tr><td align=\"center\"><table style=\"width: 600px;\"><tbody><tr><td><div style=\"background-color:white;border:white;border-radius:5px;margin:5rem 1rem 5rem 1rem;padding:2rem;text-align: left;\"><div style=\"padding-left:1rem;\"><p class=\"boxheader\" style=\"font-size:2rem;\">Reset Password</p></div><hr><div style=\"font-size: 1rem;\"><p>Hi " +
				$"{name}" +
				",</p><p>My Dental Health Customer, there was recently a request to change the password on your account.</p><p>There is your password reset link</p><a href=\"" +
				$"{link}" +
				"\" style=\"border:0.1rem;border-style:solid;border-color:blue;border-radius:0.5rem;background:blue;color:white;text-decoration:none;padding:0.8rem;display:inline-block;transition:0.2s;\"> Reset Password </a></div></div></td></tr></tbody></table></td></tr></tbody></table></body></html>",
				IsBodyHtml = true,
			};

			mailMessage.To.Add(toMail);

			await smtpClient.SendMailAsync(mailMessage);
		}
	}
}
