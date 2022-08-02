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
    
    [Fact]
    public void Calculate_givingTwoNumbersAndMockedMethods_returnSumOfThoseNumbers()
    {
        //Arrange
        IOperator mockedOperatorToAddNumbers = Substitute.For<IOperator>();
        mockedOperatorToAddNumbers.Calculate(Arg.Is<int>(x => x == 4), Arg.Is<int>(x => x == 2)).Returns(6);
        _mockedOperatorProvider.GetOperator(Arg.Any<OperatorEnum>()).Returns(mockedOperatorToAddNumbers);
        Calculator calculator = new Calculator(_mockedOperatorProvider);

        //act
        //doesn't matter which OperatorEnum is given, since 'GetOperator' is mocked 
        var result = calculator.Calculate(4, 2, OperatorEnum.division);

        //assert
        _testOutputHelper.WriteLine("This is the result: {0}", result);
        result.Should().Be(6);
    }
}