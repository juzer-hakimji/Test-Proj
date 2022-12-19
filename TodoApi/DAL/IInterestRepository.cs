
using TodoApi.Models;

namespace TodoApi.DAL
{
	public interface IInterestRepository
	{
		Interest GetInterestData(Guid UserId);
	}
}