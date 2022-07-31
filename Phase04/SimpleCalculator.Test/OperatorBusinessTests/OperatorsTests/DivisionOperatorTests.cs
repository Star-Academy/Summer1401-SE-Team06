using FluentAssertions;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test.OperatorBusinessTests.OperatorsTests;

public class DivisionOperatorTests
{
    [Fact]
    public void Calculate_divideTwoNumbers_TrueResultValue()
    {
        //arrange
        DivisionOperator theOperator = new DivisionOperator();
        
        //act
        var result = theOperator.Calculate(108, 12);
        
        //assert
        result.Should().Be(9);
    } 
    
    [Fact]
    public void calculate_DivideByZero_DivideByZeroException()
    {
        //arrange
        DivisionOperator theOperator = new DivisionOperator();
        
        //act
        Action act = () => theOperator.Calculate(57, 0);
        
        //assert
        act.Should().Throw<DivideByZeroException>();
    } 
}