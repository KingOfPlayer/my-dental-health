using Entity.Models.Advice;

namespace Service.Interfaces
{
	public interface IAdviceService
	{
		Advice? GetRandomAdvice();
	}
}
