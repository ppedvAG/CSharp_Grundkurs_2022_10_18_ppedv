namespace M014;

internal class Events
{
	static event EventHandler TestEvent;

	static event EventHandler<TestEventArgs> ArgsEvent;

	static void Main(string[] args)
	{
		TestEvent += Events_TestEvent; //Extra Methode anhängen, Events können nicht instanziert werden
		TestEvent(null, EventArgs.Empty); //Event ausführen

		ArgsEvent += Events_ArgsEvent;
		ArgsEvent.Invoke(null, new TestEventArgs { Status = "OK", Message = "Ein Test" });

		TestEvent += (sender, args) => Console.WriteLine(args); //Anonyme Methode anhängen
	}

	private static void Events_TestEvent(object? sender, EventArgs e)
	{
		Console.WriteLine("Test");
	}

	private static void Events_ArgsEvent(object? sender, TestEventArgs e)
	{
		e.Test();
		Console.WriteLine(e.Message);
		Console.WriteLine(e.Status);
	}
}

internal class TestEventArgs : EventArgs
{
	public string Status { get; set; }

	public string Message { get; set; }

	public void Test() => Console.WriteLine($"Status: {Status}, Nachricht: {Message}");
}