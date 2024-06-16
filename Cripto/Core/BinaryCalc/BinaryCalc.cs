using System.Text;
namespace Cripto.Core.BinaryCalc;

public static class BinaryCalc
{
    public static string Calculate(
        BinaryOperation operation,
        string binaryStringOne,
        string? binaryStringTwo,
        int shift = 0)
    {
        switch (operation)
        {
            case BinaryOperation.Xor:
                if (binaryStringTwo == null)
                    throw new ArgumentNullException(nameof(binaryStringTwo));
                return Xor(binaryStringOne, binaryStringTwo);
            case BinaryOperation.And:
                if (binaryStringTwo == null)
                    throw new ArgumentNullException(nameof(binaryStringTwo));
                return And(binaryStringOne, binaryStringTwo);
            case BinaryOperation.Not:
                return Not(binaryStringOne);
            case BinaryOperation.Rotate:
                return Rotate(binaryStringOne, shift);
            default:
                throw new ArgumentException("Invalid operation");
        }
    }

    private static string Not(string binaryString)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < binaryString.Length; i++)
        {
            result.Append(binaryString[i] == '0' ? '1' : '0');
        }

        return result.ToString();
    }

    private static string Rotate(string binaryString, int shift)
    {
        var length = binaryString.Length;
        shift %= length;

        if (shift < 0)
        {
            shift = -shift;
            return binaryString.Substring(shift) + binaryString.Substring(0, shift);
        }

        return binaryString.Substring(length - shift) + binaryString.Substring(0, length - shift);
    }

    private static string And(string binaryStringOne, string binaryStringTwo)
    {
        if (binaryStringOne.Length < binaryStringTwo.Length)
        {
            binaryStringOne = binaryStringOne.PadLeft(binaryStringTwo.Length, '0');
        }
        else if (binaryStringTwo.Length < binaryStringOne.Length)
        {
            binaryStringTwo = binaryStringTwo.PadLeft(binaryStringOne.Length, '0');
        }

        StringBuilder result = new StringBuilder();
        for (var i = 0; i < binaryStringOne.Length; i++)
        {
            result.Append(binaryStringOne[i] - '0' & binaryStringTwo[i] - '0');
        }

        return result.ToString();
    }

    private static string Xor(string binaryStringOne, string binaryStringTwo)
    {
        if (binaryStringOne.Length < binaryStringTwo.Length)
        {
            binaryStringOne = binaryStringOne.PadLeft(binaryStringTwo.Length, '0');
        }
        else if (binaryStringTwo.Length < binaryStringOne.Length)
        {
            binaryStringTwo = binaryStringTwo.PadLeft(binaryStringOne.Length, '0');
        }

        StringBuilder result = new StringBuilder();
        for (var i = 0; i < binaryStringOne.Length; i++)
        {
            result.Append(binaryStringOne[i] - '0' ^ binaryStringTwo[i] - '0');
        }

        return result.ToString();
    }
}