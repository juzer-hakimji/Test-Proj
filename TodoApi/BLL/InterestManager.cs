
using TodoApi.DAL;
using TodoApi.Models;

namespace TodoApi.BLL
{
	public class InterestManager : IInterestManager
	{

		public IInterestRepository _InterestRepository { get; set; }
		public InterestManager(IInterestRepository interestRepository)
		{
			_InterestRepository = interestRepository;
		}
		public double CalculateInterest(int principal, double interestRate, int period)
		{
			return (principal * Math.Pow((1 + interestRate / 100), period)) - principal;
		}

		public double CalculateInterest()
		{
			var interestData = _InterestRepository.GetInterestData(Guid.NewGuid());
			return (interestData.principal * Math.Pow((1 + interestData.interestRate / 100), interestData.period)) - interestData.principal;
		}
	}
}