using MathNet.Numerics.LinearAlgebra;

namespace Cripto.Core.Converter;

public static class NumbersConverter
{
	/// <summary>
	/// Числа в бинарную строку
	/// </summary>
    public static string ConvertToBinary(List<long> decimalNumbers)
    {
		return string.Join("", decimalNumbers.Select(n => Convert.ToString(n, 2).PadLeft(5, '0')));
	}

	/// <summary>
	/// Одно число в бинарную строку
	/// </summary>
	/// <param name="decimalNumber"></param>
	/// <returns>бинарная строка</returns>
	public static string ConvertToBinary(long decimalNumber)
	{
		return Convert.ToString(decimalNumber, 2).PadLeft(5, '0');
	}
	
	/// <summary>
	/// Разделение строки по n символов
	/// </summary>
	/// <param name="binaryString"></param>
	/// <param name="count"></param>
	/// <returns>лист из строк</returns>
	public static List<string> BinarySeparation(string binaryString, int count)
	{
		var chunks = new List<string>();
		for (int i = binaryString.Length; i > 0; i -= count)
		{
			if (i - count < 0)
			{
				string chunk = binaryString.Substring(0, i);
				chunk = chunk.PadLeft(count, '0');
				chunks.Add(chunk);
			}
			else
			{
				chunks.Add(binaryString.Substring(i - count, count));
			}
		}
		chunks.Reverse();
		return chunks;
	}
	
	/// <summary>
	/// Бинарное число в десятичное
	/// </summary>
	/// <param name="binaryNumber"></param>
	/// <returns>десятичное число</returns>
	private static int ConvertToDecimal(string binaryNumber)
    {
        return Convert.ToInt32(binaryNumber, 2);
    }

	/// <summary>
	/// Бинарные строки в матрицу
	/// </summary>
	/// <param name="binaryStrings"></param>
	/// <returns>матрица</returns>
	public static Matrix<double> ConvertBinaryStringsToMatrix(List<string> binaryStrings)
	{
		int size = binaryStrings[0].Length;

		double[,] matrix = new double[binaryStrings.Count, size];

		for (int i = 0; i < binaryStrings.Count; i++)
		{
			for (int j = 0; j < size; j++)
			{
				matrix[i, j] = double.Parse(binaryStrings[i][j].ToString());
			}
		}

		return Matrix<double>.Build.DenseOfArray(matrix);
	}

	/// <summary>
	/// Матрица в бинарную строку
	/// </summary>
	/// <param name="M">матрица</param>
	/// <returns>бинарная строка</returns>
	public static string ConvertMatrixToBinaryString(Matrix<double> M)
	{
		return string.Join("", M.EnumerateRows().Select(row => string.Join("", row)));
	}
	
	/// <summary>
	/// Бинарные строки в числа
	/// </summary>
	/// <param name="separatedStrings"></param>
	/// <returns>лист из интов</returns>
	public static List<int> ConvertIntSeparation(List<string> separatedStrings)
	{
		var numbers = new List<int>();
		foreach (string chunk in separatedStrings)
		{
			numbers.Add(ConvertToDecimal(chunk));
		}
		return numbers;
	}
}

