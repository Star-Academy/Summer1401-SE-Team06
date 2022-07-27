using FluentAssertions;
using SimpleCalculator.Business;
using SimpleCalculator.Business.Enums;

namespace TestProject1;

public class UnitTest1
{
    [Theory]
    [InlineData(10, 20, 30, OperatorEnum.sum)]
    [InlineData(10, -10, 0, OperatorEnum.sum)]
    [InlineData(50, 20, 30, OperatorEnum.sub)]
    [InlineData(10, 20, 200, OperatorEnum.multiply)]
    [InlineData(10, 0, 0, OperatorEnum.multiply)]
    [InlineData(100, 10, 10, OperatorEnum.division)]
    
    public void Calculate_AllOperators_TrueResultValue(int first, int second, int result, OperatorEnum operatorEnum)
    {
        var calculator = new Calculator(); 
        var expected = calculator.Calculate(first, second, operatorEnum);
        expected.Should().Be(result);
    }
    
    [Fact]
    public void Divide_DivideByZero_DivideByZeroException()
    {
        var calculator = new Calculator(); 
        Action act = () =>  calculator.Calculate(100, 0, OperatorEnum.division);
        act.Should().Throw<DivideByZeroException>();
    }
}