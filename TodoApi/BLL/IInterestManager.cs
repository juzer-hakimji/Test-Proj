
namespace TodoApi.BLL
{
	public interface IInterestManager
	{
		double CalculateInterest(int principal, double interestRate, int period);
	}
}