namespace M014;

internal class ActionPredicateFunc
{
	static void Main(string[] args)
	{
		Action<int, int> action = Addiere; //Action: Methode mit void und bis zu 16 Parametern
		action += Subtrahiere;
		action(4, 6);
		action?.Invoke(4, 6); //Funktioniert wie Delegate

		DoAction(6, 3, Addiere); //Verhalten von Methoden anpassen ohne den Code anzupassen
		DoAction(6, 3, Subtrahiere); //Unterschiedliche Actions als Parameter
		DoAction(6, 3, action); //Eine Action Variable übergeben

		Predicate<int> predicate = CheckForZero; //Predicate: Methode mit bool als Rückgabewert und genau einem Parameter
		predicate += CheckForOne;
		bool b = predicate(4); //Ergebnis in bool Variable schreiben
		bool? b2 = predicate?.Invoke(3); //Hier bool? weil ?.Invoke könnte null sein wenn Predicate null ist

		DoPredicate(4, CheckForZero);
		DoPredicate(4, CheckForOne);
		DoPredicate(4, predicate); //Hier wird das Ergebnis von der letzten Methode genommen

		Func<int, int, double> func = Multipliziere; //Func: Methode mit Rückgabewert, bis zu 16 Parameter, Rückgabe muss letztes Generic sein
		func += Dividiere;
		double d = func(3, 5); //Hier auch wieder nur letztes Ergebnis
		double? d2 = func?.Invoke(3, 5); //Hier auch wieder double?

		DoFunc(5, 2, Multipliziere);
		DoFunc(5, 2, Dividiere);
		DoFunc(5, 2, func);

		func += delegate (int x, int y) { return x + y; };
		func += (int x, int y) => { return x + y; };
		func += (x, y) => { return x - y; };
		func += (x, y) => (double) x / y;

		DoAction(5, 1, (x, y) => Console.WriteLine(x + y)); //Anonyme Action
		DoPredicate(3, e => e % 2 == 0); //Anonyme Predicate
		DoFunc(6, 2, (x, y) => x + y); //Anonyme Func
	}

	static void Addiere(int z1, int z2) => Console.WriteLine(z1 + z2);

	static void Subtrahiere(int arg1, int arg2) => Console.WriteLine(arg1 - arg2);

	static void DoAction(int z1, int z2, Action<int, int> a) => a?.Invoke(z1, z2);

	private static bool CheckForZero(int obj) => obj == 0;

	private static bool CheckForOne(int obj) => obj == 1;

	static bool DoPredicate(int z1, Predicate<int> p) => p.Invoke(z1);

	private static double Multipliziere(int arg1, int arg2) => arg1 * arg2;

	private static double Dividiere(int arg1, int arg2) => (double) arg1 / arg2;

	static double DoFunc(int z1, int z2, Func<int, int, double> func) => func.Invoke(z1, z2);
}
