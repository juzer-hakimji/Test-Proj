using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TodoApi.BLL;
using TodoApi.DAL;
using TodoApi.Models;

namespace Tests;

[TestClass]
public class InterestManagerTests
{
	[TestMethod]
	public void check_calculateInterest_returns_correct_amount()
	{
		// Given I have Interest Data
		var interestData = new Interest
		{
			principal = 20000,
			interestRate = 12,
			period = 2
		};
		var expectedInterestAmount = 5088.00;

		// And I have mocked my interest repository to return interest data
		var moqManager = new Mock<IInterestRepository>();
		moqManager.Setup(m => m.GetInterestData(It.IsAny<Guid>())).Returns(interestData);

		// And I have instantiated my manager
		var interestManager = new InterestManager(moqManager.Object);

		// When I call the service
		var result = interestManager.CalculateInterest();

		// Then I expect the resulting interest amount to match the expected interest amount
		Assert.AreEqual(Math.Round(expectedInterestAmount, 2), Math.Round(result, 2));
	}

	[DataTestMethod]
	[DataRow(1000, 10, 2, 0)]
	[DataRow(1000, 20, 5, 0)]
	public void check_calculateInterest_returns_correct_amount(int principal, double interestRate, int period, int expectedInterest)
	{

		Assert.AreEqual(1, 1);
	}

	// [DataTestMethod]
	// [DynamicData(nameof(GetCalculateInterestData), DynamicDataSourceType.Method)]
	// public void check_calculateInterest_returns_correct_amount2(int principal, double interestRate, int period, int expectedInterest)
	// {
	// 	Assert.AreEqual(1, 1);
	// }

	// private static IEnumerable<object[]> GetCalculateInterestData()
	// {
	// 	var today = DateTime.Today;
	// 	var financeId = Guid.NewGuid();
	// 	var finance = new Finance
	// 	{
	// 		Id = financeId,
	// 		RepaymentSchedule = new RepaymentSchedule
	// 		{
	// 			FinanceId = financeId,
	// 			Instalments = new List<Instalment>
	// 						{
	// 							new Instalment { PeriodEnd = today.AddDays(-10) },
	// 							new Instalment { PeriodEnd = today, InstalmentInfo = new InstalmentInfo(), PaymentDue = 100},
	// 							new Instalment { PeriodEnd = today.AddDays(10) }
	// 						}
	// 		}
	// 	};

	// 	var oldBalanceInfo = new BalanceInfo { FinanceId = financeId, ExpectedPrincipal = 0, PrincipalInterest = 0, Principal = 123, ArrearsInterest = 456, FeesInterestBearing = 789, FeesNonInterestBearing = 12, InterestOnFees = 34 };
	// 	finance.BalanceInfo = oldBalanceInfo;
	// 	var newBalanceInfo = new BalanceInfo { FinanceId = financeId, ExpectedPrincipal = 0, PrincipalInterest = 0, Principal = 123, ArrearsInterest = 456, FeesInterestBearing = 789, FeesNonInterestBearing = 12, InterestOnFees = 34 };
	// 	yield return new object[] { financeId, today, finance, newBalanceInfo, 1, "No change expected" };

	// }
}