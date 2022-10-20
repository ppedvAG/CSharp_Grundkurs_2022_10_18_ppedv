using System.Diagnostics;
using System.Text;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		List<int> list = Enumerable.Range(1, 20).ToList(); //Erstellt eine Liste von Ints von <Start> mit <Anzahl Elementen>

		Console.WriteLine(list.Average());
		Console.WriteLine(list.Min());
		Console.WriteLine(list.Max());
		Console.WriteLine(list.Sum());

		Console.WriteLine(list.First()); //Erstes Element der Liste, Exception wenn Liste leer
		Console.WriteLine(list.FirstOrDefault()); //Erstes Element der Liste, null wenn Liste leer

		Console.WriteLine(list.Last());
		Console.WriteLine(list.LastOrDefault());

		Console.WriteLine(list.First(e => e % 3 == 0)); //Das erste Element das durch 3 teilbar ist
		//Console.WriteLine(list.First(e => e % 50 == 0)); //Exception, da kein Element der Bedingung entspricht
		Console.WriteLine(list.FirstOrDefault(e => e % 50 == 0)); //null oder hier 0
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq Schreibweisen
		//Alle BMWs mit Foreach
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmws = (from f in fahrzeuge 
							   where f.Marke == FahrzeugMarke.BMW 
							   select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		//Alle Fahrzeuge mit MaxV > 200
		fahrzeuge.Where(f => f.MaxV > 200);

		//Alle VWs mit MaxV > 200
		fahrzeuge.Where(e => e.MaxV > 200 && e.Marke == FahrzeugMarke.VW);

		//Alle Marken extrahieren
		List<FahrzeugMarke> marken = fahrzeuge.Select(e => e.Marke).ToList();

		//Alle Marken nur einmal ausgeben
		marken.Distinct();

		//Nimm das erste Fahrzeug pro Marke aus der Liste
		fahrzeuge.DistinctBy(e => e.Marke);

		List<string> str = new() { "das", "ist", "ein", "test" };
		str.Select(e => char.ToUpper(e[0]) + e[1..]); //Jedes Wort groß schreiben

		//Meine Fahrzeuge in Schiffe umwandeln
		fahrzeuge.Select(e => new Schiff(e.MaxV));

		//Vom langsamsten zum schnellsten Auto sortieren
		fahrzeuge.OrderBy(e => e.MaxV);

		//Vom schnellsten zum langsamsten Auto sortieren
		fahrzeuge.OrderByDescending(e => e.MaxV);

		//Nach Marke und danach nach Geschwindigkeit sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);

		fahrzeuge.OrderBy(e => e.MaxV).First(); //langsamste
		fahrzeuge.OrderBy(e => e.MaxV).Last(); //schnellstes

		fahrzeuge.MinBy(e => e.MaxV); //Das langsamste Auto
		fahrzeuge.MaxBy(e => e.MaxV); //Das schnellste Auto

		fahrzeuge.Min(e => e.MaxV); //Die niedrigste Geschwindigkeit statt dem Fahrzeug
		fahrzeuge.Max(e => e.MaxV); //Die höchste Geschwindigkeit statt dem Fahrzeug

		//Wieviele Audis haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.Audi);

		//Fahren alle Fahrzeuge in unserer Liste schneller als 200?
		fahrzeuge.All(e => e.MaxV >= 200);

		//Fährt mindestens ein Fahrzeug mindestens 200km/h?
		fahrzeuge.Any(e => e.MaxV >= 200);

		//Schauen ob die Liste leer ist
		fahrzeuge.Any(); //fahrzeuge.Count > 0

		fahrzeuge.Chunk(5); //Teile die Liste in 5 große Arrays auf, der Rest kommt ins letzte Array

		fahrzeuge.Skip(2).Take(5); //Überspringe 2, nimm 5 -> Neue Liste mit mittleren 5 Fahrzeugen

		fahrzeuge.GroupBy(e => e.Marke); //Teilt die Liste in eine Liste von Gruppen auf (Audi-Gruppe, BMW-Gruppe, VW-Gruppe)

		fahrzeuge.GroupBy(e => e.Marke).Where(e => e.Key == FahrzeugMarke.VW); //Die VW Gruppe entnehmen

		fahrzeuge.GroupBy(e => e.Marke).First(e => e.Key == FahrzeugMarke.VW).ToList(); //Die Autos aus der VW Gruppe entnehmen

		Dictionary<FahrzeugMarke, List<Fahrzeug>> grouped = fahrzeuge.GroupBy(e => e.Marke).ToDictionary(e => e.Key, e => e.ToList()); //GroupBy zu einem Dictionary konvertieren
		Console.WriteLine(grouped[FahrzeugMarke.VW]); //Gruppe jetzt angreifbar mit [Marke]

		string ausgabe = string.Empty; //selbiges wie ""
		foreach (Fahrzeug f in fahrzeuge)
			ausgabe += $"Das Fahrzeug hat die Marke {f.Marke} und kann maximal {f.MaxV} fahren.\n";
		Console.WriteLine(ausgabe);

		Console.WriteLine("Aggregate:");
		Console.WriteLine(fahrzeuge.Aggregate(string.Empty, (agg, e) => agg + $"Das Fahrzeug hat die Marke {e.Marke} und kann maximal {e.MaxV} fahren.\n"));

		Console.WriteLine(fahrzeuge.Aggregate(new StringBuilder(), (agg, e) => agg.AppendLine($"Das Fahrzeug hat die Marke {e.Marke} und kann maximal {e.MaxV} fahren.")).ToString());

		fahrzeuge.Sum(e => e.MaxV);
		fahrzeuge.Aggregate(0, (agg, e) => agg + e.MaxV);

		#region Erweiterungsmethoden
		38927.Quersumme();
		int zahl = 37;
		zahl.Quersumme(); //Alle ints haben diese Methode

		fahrzeuge.Shuffle(); //Hier könnten noch weiter Linq Funktion angehängt werden
		#endregion
	}
}

[DebuggerDisplay("Marke: {Marke}, Geschwindigkeit: {MaxV} - {typeof(Fahrzeug).FullName}")]
public class Fahrzeug
{
	public int MaxV;

	public FahrzeugMarke Marke;

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}
}

//public record Fahrzeug(int MaxV, FahrzeugMarke Marke); selbiges wie die obere Klasse

public record Schiff(int MaxV);

public enum FahrzeugMarke
{
	Audi, BMW, VW
}