using FluentAssertions;
using SimpleCalculator.Business.Abstraction;
using SimpleCalculator.Business.Enums;
using SimpleCalculator.Business.OperatorBusiness;
using SimpleCalculator.Business.OperatorBusiness.Operators;

namespace SimpleCalculator.Test.OperatorBusinessTests;

public class OperatorProviderTests
{
    
    [Theory]
    [MemberData(nameof(MyTestGenerator.OperatorEnums), MemberType = typeof(MyTestGenerator))]
    public void getProvider_givingOneOperatorEnum_ReturnsCorrespondingIOperator(OperatorEnum operatorEnum, IOperator expectedIOperator)
    {
        //arrange
        var operatorProvider = new OperatorProvider();
        
        //act
        var returnedOperator = operatorProvider.GetOperator(operatorEnum);

        //assert
        returnedOperator.Should().BeOfType(expectedIOperator.GetType());
    } 
}

public static class MyTestGenerator
{
    public static TheoryData<OperatorEnum, IOperator> OperatorEnums()
        => new TheoryData<OperatorEnum, IOperator> {
            { OperatorEnum.sum , new SumOperator()},
            { OperatorEnum.sub, new SubOperator()},
            { OperatorEnum.division, new DivisionOperator()},
            { OperatorEnum.multiply, new MultiplyOperator()},
        };
}