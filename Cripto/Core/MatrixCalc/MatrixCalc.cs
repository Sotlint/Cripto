using Cripto.Core.BinaryCalc;
using MathNet.Numerics.LinearAlgebra;

namespace Cripto.Core.MatrixCalc;

public static class MatrixCalc
{
    public static Matrix<double> Calculate(
        MatrixOperation operation,
        Matrix<double> matrix1,
        Matrix<double>? matrix2,
        long? module)
    {
        switch (operation)
        {
            case MatrixOperation.Multiply:
                if (matrix2 == null)
                    throw new ArgumentNullException(nameof(matrix2));
                return Multiply(matrix1, matrix2);
            case MatrixOperation.Inverse:
                return Inverse(matrix1);
            case MatrixOperation.ModuloTwo:
                if (module == null)
                    throw new ArgumentNullException(nameof(module));
                return Module(matrix1, module.Value);
            case MatrixOperation.MatrixXor:
                if (matrix2 == null)
                    throw new ArgumentNullException(nameof(matrix2));
                return Xor(matrix1, matrix2);
            default:
                throw new ArgumentException("Invalid operation");
        }
    }

    private static Matrix<double> Multiply(Matrix<double> matrix1, Matrix<double> matrix2)
    {
        return matrix1 * matrix2;
    }

    private static Matrix<double> Inverse(Matrix<double> matrix)
    {
        return matrix.Inverse();
    }

    private static Matrix<double> Module(Matrix<double> matrix, long module)
    {
        return matrix.Map(x => Math.Abs(x % module));
    }

    private static Matrix<double> Xor(Matrix<double> matrix1, Matrix<double> matrix2)
    {
        var rowCount = matrix1.RowCount;
        var columnCount = matrix1.ColumnCount;

        var resultMatrix = new double[rowCount, columnCount];

        for (var i = 0; i < rowCount; i++)
        {
            var binary1 = string.Join("", matrix1.Row(i)
                .Select(x => Convert.ToString((long)x, 2).PadLeft(8, '0')));

            var binary2 = string.Join("", matrix2.Row(i)
                .Select(x => Convert.ToString((long)x, 2).PadLeft(8, '0')));

            var xorResult = BinaryCalc.BinaryCalc
                .Calculate(BinaryOperation.Xor, binary1, binary2);

            for (var j = 0; j < columnCount; j++)
            {
                resultMatrix[i, j] = Convert.ToInt32(xorResult.Substring(j * 8, 8), 2);
            }
        }

        return Matrix<double>.Build.DenseOfArray(resultMatrix);
    }
}