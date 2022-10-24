using System.Collections;
using System.Diagnostics;

namespace M017;

internal class Program
{
	static void Main(string[] args)
	{
		Wagon w1 = new();
		Wagon w2 = new();
		if (w1 == w2)
		{
			Console.WriteLine("Gleich");
		}

		Zug z = new();
		z++;
		z++;
		z++;
		z++;
		z++;

		foreach (Wagon w in z)
		{
			Console.WriteLine(w.GetHashCode());
		}

		//Console.WriteLine(z[1]);
		////z[1] = new Wagon();
		//Console.WriteLine(z["Rot"]);
		//Console.WriteLine(z[10, "Rot"]);

		Stopwatch sw = new();
		sw.Start();
		Thread.Sleep(1000);
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);
	}
}

public class Zug : IEnumerable
{
	public List<Wagon> Wagons = new();

	public IEnumerator GetEnumerator()
	{
		return Wagons.GetEnumerator();
	}

	public static Zug operator ++(Zug z)
	{
		z.Wagons.Add(new Wagon());
		return z;
	}

	public Wagon this[int x]
	{
		get => Wagons[x];
		private set => Wagons[x] = value;
	}

	public Wagon this[string s]
	{
		get => Wagons.First(e => e.Farbe == s);
	}

	public Wagon this[int x, string s]
	{
		get => Wagons.First(e => e.AnzSitze == x && e.Farbe == s);
	}
}

public class Wagon
{
	public int AnzSitze;
	public string Farbe;

	public static bool operator ==(Wagon w1, Wagon w2)
	{
		return (w1.AnzSitze == w2.AnzSitze) && (w1.Farbe == w2.Farbe);
	}

	public static bool operator !=(Wagon w1, Wagon w2)
	{
		return !(w1 == w2);
	}
}