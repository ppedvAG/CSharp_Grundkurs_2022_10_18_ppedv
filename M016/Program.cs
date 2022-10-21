using Newtonsoft.Json;
using System.Text.Json;
using System.Xml.Serialization;

namespace M016;

internal class Program
{
	static void Main(string[] args)
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfade zu speziellen Ordnern unter Windows

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath)) //Alles zum Thema Folder
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "M016.txt"); //File Pfad

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

		//Streams();

		//NewtonsoftJson();

		//SystemJson();

		//XML();
	}

	public static void Streams()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfade zu speziellen Ordnern unter Windows

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath)) //Alles zum Thema Folder
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "M016.txt"); //File Pfad

		StreamWriter sw = new StreamWriter(filePath);
		sw.WriteLine("Test1"); //Stream füllen
		sw.WriteLine("Test2");
		sw.WriteLine("Test3");
		//sw.Flush(); //Streaminhalt in das File schreiben
		sw.Close(); //Am Ende schließen + Flush()

		using (StreamWriter sw2 = new StreamWriter(filePath)) { } //Schließst sich automatisch am Ende des Blocks

		using StreamWriter sw3 = new StreamWriter(filePath); //Seit C# 10: using Statement, schließst sich am Ende der Methode

		using StreamReader sr = new StreamReader(filePath);
		List<string> lines = new();
		while (!sr.EndOfStream)
			lines.Add(sr.ReadLine());

		File.WriteAllText(filePath, "123456\n123456");

		File.ReadAllText(filePath);

		File.ReadAllLines(filePath);
	}

	public static void NewtonsoftJson()
	{
		//string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfade zu speziellen Ordnern unter Windows

		//string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		//if (!Directory.Exists(folderPath)) //Alles zum Thema Folder
		//	Directory.CreateDirectory(folderPath);

		//string filePath = Path.Combine(folderPath, "M016.txt"); //File Pfad

		//List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		//{
		//	new Fahrzeug(251, FahrzeugMarke.BMW),
		//	new Fahrzeug(274, FahrzeugMarke.BMW),
		//	new Fahrzeug(146, FahrzeugMarke.BMW),
		//	new Fahrzeug(208, FahrzeugMarke.Audi),
		//	new Fahrzeug(189, FahrzeugMarke.Audi),
		//	new Fahrzeug(133, FahrzeugMarke.VW),
		//	new Fahrzeug(253, FahrzeugMarke.VW),
		//	new Fahrzeug(304, FahrzeugMarke.BMW),
		//	new Fahrzeug(151, FahrzeugMarke.VW),
		//	new Fahrzeug(250, FahrzeugMarke.VW),
		//	new Fahrzeug(217, FahrzeugMarke.Audi),
		//	new Fahrzeug(125, FahrzeugMarke.Audi)
		//};

		//JsonSerializerSettings settings = new JsonSerializerSettings();
		//settings.TypeNameHandling = TypeNameHandling.Objects;

		//string json = JsonConvert.SerializeObject(fahrzeuge); //Formatting.Indented
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//Fahrzeug[] fzg = JsonConvert.DeserializeObject<Fahrzeug[]>(readJson);
	}

	public static void SystemJson()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfade zu speziellen Ordnern unter Windows

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath)) //Alles zum Thema Folder
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "M016.txt"); //File Pfad

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

		string json = JsonSerializer.Serialize(fahrzeuge);
		File.WriteAllText(filePath, json);

		string readJson = File.ReadAllText(filePath);
		Fahrzeug[] fzg = JsonSerializer.Deserialize<Fahrzeug[]>(readJson);
	}

	public static void XML()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfade zu speziellen Ordnern unter Windows

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath)) //Alles zum Thema Folder
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "M016.txt"); //File Pfad

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

		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		using (FileStream fs = new FileStream(filePath, FileMode.Create))
			xml.Serialize(fs, fahrzeuge);

		List<Fahrzeug> readXml;
		using (FileStream fs = new FileStream(filePath, FileMode.Open))
			readXml = xml.Deserialize(fs) as List<Fahrzeug>;
	}
}

public class Fahrzeug
{
	[XmlAttribute]
	public int MaxV;

	[XmlAttribute]
	public FahrzeugMarke Marke;

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}

	public Fahrzeug() { }
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}