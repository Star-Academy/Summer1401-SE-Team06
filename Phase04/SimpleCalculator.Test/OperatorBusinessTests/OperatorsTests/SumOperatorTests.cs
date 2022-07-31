using FluentAssertions;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test.OperatorBusinessTests.OperatorsTests;

public class SumOperatorTests
{
    [Fact]
    public void Calculate_addTwoNumbers_TrueResultValue()
    {
        //arrange
        SumOperator theOperator = new SumOperator();
        
        //act
        var result = theOperator.Calculate(23, -34);
        
        //assert
        result.Should().Be(-11);
    }    
}