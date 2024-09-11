namespace Repository.Interfaces
{
	public interface IRepositoryManager
	{
		IUserRepository UserRepository { get; }
		ITargetRepository TargetRepository { get; }
		IAdviceRepository AdviceRepository { get; }
	}
}
