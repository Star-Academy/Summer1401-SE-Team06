using FluentAssertions;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test.OperatorBusinessTests.OperatorsTests;

public class MultiplyOperatorTests
{
    [Fact]
    public void Calculate_multiplyTwoNumbers_TrueResultValue()
    {
        //arrange
        MultiplyOperator theOperator = new MultiplyOperator();
        
        //act
        var result = theOperator.Calculate(12, 21);
        
        //assert
        result.Should().Be(252);
    }    
}