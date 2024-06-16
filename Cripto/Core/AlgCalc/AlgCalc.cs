namespace Cripto.Core.AlgCalc;

public static class AlgCalc
{
    
    /// <summary>
    /// Найти число/число подходящие под значение функции ейлера
    /// </summary>
    /// <param name="eulerPhiValue">значение функции ейлера</param>
    /// <param name="start">от</param>
    /// <param name="end">до</param>
    public static List<int> FindNumbersByEulerPhi(int eulerPhiValue, int start, int end)
    {
        var numbers = new List<int>();
        for (int i = start; i <= end; i++)
        {
            if (EulerPhi(i) == eulerPhiValue)
            {
                numbers.Add(i);
            }
        }
        return numbers;
    }
    
    /// <summary>
    /// Функция эйлера
    /// </summary>
    /// <param name="n"> число </param>
    public static int EulerPhi(int n)
    {
        int result = n;

        for (int p = 2; p * p <= n; ++p)
        {
            if (n % p == 0)
            {
                while (n % p == 0)
                    n /= p;
                result -= result / p;
            }
        }

        if (n > 1)
            result -= result / n;
        return result;
    }

    /// <summary>
    /// Китайская теорема об остатках
    /// </summary>
    /// <param name="n">массив модулей</param>
    /// <param name="a">массив остатков</param>
    public static int ChineseRemainderTheorem(int[] n, int[] a)
    {
        var prod = n.Aggregate(1, (i, j) => i * j);
        var sm = 0;
        for (var i = 0; i < n.Length; i++)
        {
            var p = prod / n[i];
            sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
        }

        return sm % prod;
    }

    private static int ModularMultiplicativeInverse(int a, int mod)
    {
        int b = a % mod;
        for (int x = 1; x < mod; x++)
        {
            if ((b * x) % mod == 1)
            {
                return x;
            }
        }

        return 1;
    }

    /// <summary>
    /// Число по модулю
    /// </summary>
    /// <param name="number">число</param>
    /// <param name="module">модуль</param>
    public static int Module(int number, int module)
    {
        var result = number % module;
        return result < 0 ? result + module : result;
    }
    
    /// <summary>
    /// Модульное обратное
    /// </summary>
    /// <param name="a">число</param>
    /// <param name="m">модуль</param>
    /// <exception cref="Exception">Обратного не существует</exception>
    public static int ModInverse(int a, int m)
    {
        a = a % m;
        for (int x = 1; x < m; x++)
        {
            if ((a * x) % m == 1)
            {
                return x;
            }
        }
        // Обратный элемент не существует
        throw new Exception("Modular inverse does not exist");
    }
    
    /// <summary>
    /// Числа взаимопростые?
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool AreCoprime(int a, int b)
    {
        return Gcd(a, b) == 1;
    }

    /// <summary>
    /// Алгоритм Евклида
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
    
    /// <summary>
    /// Поиск взаимопростых чисел на заданном интервале
    /// </summary>
    /// <param name="start">от</param>
    /// <param name="end">до</param>
    /// <param name="count">нужное количество чисел</param>
    /// <returns>item1 item2</returns>
    public static List<Tuple<int, int>> FindCoprimes(int start, int end, int count)
    {
        var coprimes = new List<Tuple<int, int>>();
        for (int i = start; i <= end && coprimes.Count < count; i++)
        {
            for (int j = i + 1; j <= end && coprimes.Count < count; j++)
            {
                if (AreCoprime(i, j))
                {
                    coprimes.Add(new Tuple<int, int>(i, j));
                }
            }
        }
        return coprimes;
    }
}