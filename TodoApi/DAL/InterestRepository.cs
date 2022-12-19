
using TodoApi.Models;

namespace TodoApi.DAL
{
	public class InterestRepository : IInterestRepository
	{
		public Interest GetInterestData(Guid UserId)
		{
			//In real life scenario we will get data from database but for demo purpose we will hardcode it for now

			return new Interest
			{
				principal = 20000,
				interestRate = 15,
				period = 4
			};

		}
	}
}