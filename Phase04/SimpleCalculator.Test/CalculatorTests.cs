using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NSubstitute;
using SimpleCalculator.Business;
using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness.Operators;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SimpleCalculator.Test;

public class CalculatorTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IOperatorProvider _mockedOperatorProvider;

    public CalculatorTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _mockedOperatorProvider = Substitute.For<IOperatorProvider>();
    }
    
    [Theory]
    [InlineData(2, 4, 6)]
    [InlineData(10, 0, 10)]
    public void Calculate_givingTwoNumbersAndMockedMethods_returnSumOfThoseNumbers(int first, int second, int expected)
    {
        //Arrange
        var mockedOperatorToAddNumbers = Substitute.For<IOperator>();
        mockedOperatorToAddNumbers.Calculate(Arg.Is<int>(x => x == first), Arg.Is<int>(x => x == second)).Returns(expected);
        _mockedOperatorProvider.GetOperator(Arg.Any<OperatorEnum>()).Returns(mockedOperatorToAddNumbers);
        var calculator = new Calculator(_mockedOperatorProvider);

        //act
        var result = calculator.Calculate(first, second, OperatorEnum.sum);

        //assert
        _testOutputHelper.WriteLine("This is the result: {0}", result);
        result.Should().Be(6);
    }
}
