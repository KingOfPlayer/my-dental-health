using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public interface IMailService
	{
		Task SendMail(string toMail);
		Task SendRevoceryMail(string toMail, string link);
	}
}
