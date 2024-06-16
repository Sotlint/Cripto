namespace Cripto.Core.Converter;

public static class AlphabetConverter
{
    
    /// <summary>
    /// Из чисел в слово (для ответов сверки и тд)
    /// </summary>
    /// <param name="numbers">список полученных числовых значений</param>
    /// <param name="alphabet">алфавит буквы-цифры</param>
    public static void ConvertNumbersToAlphabets(List<int> numbers, Dictionary<char, long> alphabet)
    {
        foreach (var number in numbers)
        {
            foreach (KeyValuePair<char, long> entry in alphabet)
            {
                if (entry.Value == number)
                {
                    Console.Write(entry.Key);
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Из букв в числа
    /// </summary>
    /// <param name="word">то что нужно перевести по алфавиту</param>
    /// <param name="alphabet">алфавит буквы-цифры</param>
    public static List<long> ConvertCharsToNumbers(string word, Dictionary<char, long> alphabet)
    {
        return word.Select(c => alphabet[c]).ToList();
    }
}

