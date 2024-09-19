namespace Service
{
	public interface IMailService
	{
		Task SendMail(string toMail);
		Task SendRevoceryMail(string toMail, string name, string link);
		Task SendNewUserMail(string toMail, string name);
	}
}
