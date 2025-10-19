using Calculator.BusinessLogic;

namespace Calculator.Tests;

public class CalculatorTests
{
    private readonly BusinessLogic.Calculator _calculator;

    public CalculatorTests()
    {
        _calculator = new BusinessLogic.Calculator();
    }

    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        double a = 5;
        double b = 3;

        // Act
        double result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Add_NegativeNumbers_ReturnsCorrectSum()
    {
        // Arrange
        double a = -5;
        double b = -3;

        // Act
        double result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(-8, result);
    }

    [Fact]
    public void Subtract_TwoNumbers_ReturnsCorrectDifference()
    {
        // Arrange
        double a = 10;
        double b = 4;

        // Act
        double result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Multiply_TwoNumbers_ReturnsCorrectProduct()
    {
        // Arrange
        double a = 6;
        double b = 7;

        // Act
        double result = _calculator.Multiply(a, b);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public void Multiply_ByZero_ReturnsZero()
    {
        // Arrange
        double a = 5;
        double b = 0;

        // Act
        double result = _calculator.Multiply(a, b);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Divide_TwoNumbers_ReturnsCorrectQuotient()
    {
        // Arrange
        double a = 10;
        double b = 2;

        // Act
        double result = _calculator.Divide(a, b);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        double a = 10;
        double b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
    }

    [Fact]
    public void Divide_DecimalNumbers_ReturnsCorrectQuotient()
    {
        // Arrange
        double a = 7;
        double b = 2;

        // Act
        double result = _calculator.Divide(a, b);

        // Assert
        Assert.Equal(3.5, result);
    }
}
