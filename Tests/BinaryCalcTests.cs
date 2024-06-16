using Cripto.Core.BinaryCalc;

namespace Tests;

[TestFixture]
public class BinaryOperationTests
{
    [Test]
    public void TestCalculateXor()
    {
        var result = BinaryCalc.Calculate(BinaryOperation.Xor, "10101", "11011");
        Assert.That(result, Is.EqualTo("01110"));
    }

    [Test]
    public void TestCalculateAnd()
    {
        var result = BinaryCalc.Calculate(BinaryOperation.And, "10101", "11011");
        Assert.That(result, Is.EqualTo("10001"));
    }

    [Test]
    public void TestCalculateNot()
    {
        var result = BinaryCalc.Calculate(BinaryOperation.Not, "10101", null);
        Assert.That(result, Is.EqualTo("01010"));
    }

    [Test]
    public void TestCalculateRotate()
    {
        var result1 = BinaryCalc.Calculate(BinaryOperation.Rotate, "10101", null, 2);
        var result2 = BinaryCalc.Calculate(BinaryOperation.Rotate, "11101", null, -3);
        Assert.That(result1, Is.EqualTo("01101"));
        Assert.That(result2, Is.EqualTo("01111"));
    }

    [Test]
    public void TestCalculateInvalidOperation()
    {
        Assert.Throws<ArgumentException>(() => BinaryCalc.Calculate((BinaryOperation)123, "10101", "11011"));
    }
}