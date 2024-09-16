namespace Service.Interfaces
{
	public interface IServiceManager
	{
		IUserService UserService { get; }
		ITargetService TargetService { get; }
		IAdviceService AdviceService { get; }
		IMailService MailService { get; }
	}
}
