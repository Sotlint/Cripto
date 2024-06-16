using Cripto.Core.BinaryCalc;
using Cripto.Core.Converter;

namespace Cripto.Workspace;

public class Workspace
{
    public void Work()
    {
        var massage = Conditions.Message;
        var с0Binary = NumbersConverter.ConvertToBinary(Conditions.C0);

        //сообщение в строчку и в бинарное
        var messageNumbers = AlphabetConverter.ConvertCharsToNumbers(massage, Conditions.Alphabet);
        var messageBinary = NumbersConverter.ConvertToBinary(messageNumbers);
        var messageBinarySeparation = NumbersConverter.BinarySeparation(messageBinary, 5);

        // шифртексты в строчку (двочиное по блокам)
        // 1
        var cypherTextOneNumbers =
            AlphabetConverter.ConvertCharsToNumbers(Conditions.CypherTextOne, Conditions.Alphabet);
        var cypherTextOneBinary = NumbersConverter.ConvertToBinary(cypherTextOneNumbers);
        var cypherTextOneBinarySeparation = NumbersConverter.BinarySeparation(cypherTextOneBinary, 5);
        // 2
        var cypherTextTwoNumbers =
            AlphabetConverter.ConvertCharsToNumbers(Conditions.CypherTextTwo, Conditions.Alphabet);
        var cypherTextTwoBinary = NumbersConverter.ConvertToBinary(cypherTextTwoNumbers);
        var cypherTextTwoBinarySeparation = NumbersConverter.BinarySeparation(cypherTextTwoBinary, 5);
        // 3
        var cypherTextThreeNumbers =
            AlphabetConverter.ConvertCharsToNumbers(Conditions.CypherTextThree, Conditions.Alphabet);
        var cypherTextThreeBinary = NumbersConverter.ConvertToBinary(cypherTextThreeNumbers);
        var cypherTextThreeBinarySeparation = NumbersConverter.BinarySeparation(cypherTextThreeBinary, 5);

        CriptName(cypherTextOneBinarySeparation, messageBinarySeparation, с0Binary);
        CriptName(cypherTextTwoBinarySeparation, messageBinarySeparation, с0Binary);
        CriptName(cypherTextThreeBinarySeparation, messageBinarySeparation, с0Binary);

        //ввод кол-ва букв имени
        Console.Write("Кол-во букв в первом имени: ");
        var count1 = Convert.ToInt64(Console.ReadLine());
        Console.Write("Кол-во букв в втором имени: ");
        var count2 = Convert.ToInt64(Console.ReadLine());
        Console.Write("Кол-во букв в третьем имени: ");
        var count3 = Convert.ToInt64(Console.ReadLine());

        //степени
        var degree1 = count1 * 5;
        var degree2 = count2 * 5;
        var degree3 = count3 * 5;
        
        var k1 = Math.Pow(2, degree1);
        var k2 = Math.Pow(2, degree2);
        var k3 = Math.Pow(2, degree3);

        var resultNumbers = new List<int>();
        resultNumbers.Add( Log2Formula(k1));
        resultNumbers.Add( Log2Formula(k2));
        resultNumbers.Add( Log2Formula(k3));

        AlphabetConverter.ConvertNumbersToAlphabets(resultNumbers,Conditions.Alphabet);
    }

    private int Log2Formula(double k)
    {
        var log32Base2ForK = Math.Log2(k);
        var denominator = 0.726 * Math.Log2(32);
        return (int)(log32Base2ForK / denominator);
    }

    private void CriptName(List<string> sypherText, List<string> message, string c0)
    {
        //начинаем считать
        var cypherTextOneBinaryResult = new List<string>();

        //сдвиг вправо на 1
        var initstep1 = BinaryCalc.Calculate(BinaryOperation.Rotate, c0, null, 1);
        //and c0
        var initstep2 = BinaryCalc.Calculate(BinaryOperation.And, initstep1, c0);
        //invert
        var initstep3 = BinaryCalc.Calculate(BinaryOperation.Not, initstep2, null);
        //and c0
        var initstep4 = BinaryCalc.Calculate(BinaryOperation.And, initstep3, c0);
        //xor первый блок шифртекста
        var initstep5 = BinaryCalc.Calculate(BinaryOperation.Xor, initstep4, sypherText.First());

        var initstep6 = BinaryCalc.Calculate(BinaryOperation.Xor, initstep5, message.First());
        //сохраняем
        cypherTextOneBinaryResult.Add(initstep6);
        for (int i = 0; i < sypherText.Count - 1; i++)
        {
            //сдвиг вправо на 1
            var step1 = BinaryCalc.Calculate(BinaryOperation.Rotate, sypherText[i], null, 1);
            //x and c0
            var step3 = BinaryCalc.Calculate(BinaryOperation.And, step1, step1);
            //invert
            var step4 = BinaryCalc.Calculate(BinaryOperation.Not, step3, null);
            //and c0
            var step5 = BinaryCalc.Calculate(BinaryOperation.And, step4, c0);
            //xor suphertext[i]
            var step6 = BinaryCalc.Calculate(BinaryOperation.Xor, step5, sypherText[i + 1]);
            //xor message[count]
            var step7 = BinaryCalc.Calculate(BinaryOperation.Xor, step6, message[i + 1]);

            //сохраняем
            cypherTextOneBinaryResult.Add(step7);
        }


        var separetedNumberResult = NumbersConverter.ConvertIntSeparation(cypherTextOneBinaryResult);
        AlphabetConverter.ConvertNumbersToAlphabets(separetedNumberResult, Conditions.Alphabet);
        Console.WriteLine();
    }
}