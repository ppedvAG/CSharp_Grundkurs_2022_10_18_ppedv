namespace M014;

internal class EventComponent
{
	static void Main(string[] args)
	{
		Component comp = new();
		comp.ProcessCompleted += () => Console.WriteLine("Prozess ist fertig, hat 2 Sekunden gedauert");
		comp.ValueChanged += (i) => Console.WriteLine($"Zähler: {i}, von 10"); //Das Verhalten der Komponente anpassen
		comp.StartProcess();
	}
}

class Component
{
	public event Action ProcessCompleted;

	public event Action<int> ValueChanged; //Action mit Parameter als EventHandler

	public void StartProcess()
	{
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(200);
			ValueChanged(i); //Benachrichtigen wenn Prozess voran geht
		}
		ProcessCompleted(); //Benachrichtigen wenn fertig
	}
}