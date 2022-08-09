using FluentAssertions;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test.OperatorBusinessTests.OperatorsTests;

public class SubOperatorTests
{
    [Fact]
    public void Calculate_subTwoNumbers_TrueResultValue()
    {
        //arrange
        var theOperator = new SubOperator();
        
        //act
        var result = theOperator.Calculate(65, 33);
        
        //assert
        result.Should().Be(32);
    }    
}