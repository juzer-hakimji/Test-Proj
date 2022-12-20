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
	[DataRow(15000, 10, 2, 3150.00)]
	[DataRow(25000, 20, 5, 37208.00)]
	public void check_calculateInterest_returns_correct_amount(int principal, double interestRate, int period, double expectedInterestAmount)
	{
		// Given I have Interest Data
		var interestData = new Interest
		{
			principal = principal,
			interestRate = interestRate,
			period = period
		};

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
	[DynamicData(nameof(GetCalculateInterestData), DynamicDataSourceType.Method)]
	public void check_calculateInterest_returns_correct_amount2(Interest interestData, double expectedInterestAmount)
	{
		// I have mocked my interest repository to return interest data
		var moqManager = new Mock<IInterestRepository>();
		moqManager.Setup(m => m.GetInterestData(It.IsAny<Guid>())).Returns(interestData);

		// And I have instantiated my manager
		var interestManager = new InterestManager(moqManager.Object);

		// When I call the service
		var result = interestManager.CalculateInterest();

		// Then I expect the resulting interest amount to match the expected interest amount
		Assert.AreEqual(Math.Round(expectedInterestAmount, 2), Math.Round(result, 2));
	}

	private static IEnumerable<object[]> GetCalculateInterestData()
	{
		var interestData = new Interest
		{
			principal = 20000,
			interestRate = 12,
			period = 2
		};
		var expectedInterestAmount = 5088.00;
		yield return new object[] { interestData, expectedInterestAmount };

		interestData = new Interest
		{
			principal = 15000,
			interestRate = 10,
			period = 2
		};
		expectedInterestAmount = 3150.00;
		yield return new object[] { interestData, expectedInterestAmount };

		interestData = new Interest
		{
			principal = 25000,
			interestRate = 20,
			period = 5
		};
		expectedInterestAmount = 37208.00;
		yield return new object[] { interestData, expectedInterestAmount };

	}
}