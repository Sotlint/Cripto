using Cripto.Core.AlgCalc;

namespace Tests;

public class AlgCalcTests
{

	[Test]
	public void TestEulerPhi()
	{
		Assert.That(AlgCalc.EulerPhi(10), Is.EqualTo(4));
		Assert.That(AlgCalc.EulerPhi(1), Is.EqualTo(1));
	}

	[Test]
	public void TestAreCoprime()
	{
		Assert.That(AlgCalc.AreCoprime(4, 9), Is.EqualTo(true));
		Assert.That(AlgCalc.AreCoprime(4, 8), Is.EqualTo(false));
	}

	[Test]
	public void TestFindNumbersByEulerPhi()
	{
		List<int> numbers = AlgCalc.FindNumbersByEulerPhi(4, 1, 10);
		CollectionAssert.AreEqual(new List<int> { 5, 8, 10 }, numbers);
	}

	[Test]
	public void TestChineseRemainderTheorem()
	{
		int[] n = { 3, 4, 5 };
		int[] a = { 2, 3, 1 };
		Assert.That(AlgCalc.ChineseRemainderTheorem(n, a), Is.EqualTo(11));
	}

	[Test]
	public void TestModInverse()
	{
		Assert.That(AlgCalc.ModInverse(4, 7), Is.EqualTo(2));
		Assert.Throws<System.Exception>(() => AlgCalc.ModInverse(2, 4));
	}

	[Test]
	public void TestFindCoprimes()
	{
		List<Tuple<int, int>> coprimes = AlgCalc.FindCoprimes(1, 10, 5);
		CollectionAssert.AreEqual(new List<Tuple<int, int>>
		{
			new Tuple<int, int>(1, 2),
			new Tuple<int, int>(1, 3),
			new Tuple<int, int>(1, 4),
			new Tuple<int, int>(1, 5),
			new Tuple<int, int>(1, 6)
		}, coprimes);
	}
}

