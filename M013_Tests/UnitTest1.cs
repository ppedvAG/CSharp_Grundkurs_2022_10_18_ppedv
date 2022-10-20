using M013;

namespace M013_Tests
{
	[TestClass]
	public class M013_Rechner
	{
		Rechner r;

		[TestInitialize] //Vor den Tests wird diese Methode ausgeführt
		public void Init() => r = new();

		[TestCleanup] //Nach den Tests wird diese Methode ausgeführt
		public void Cleanup() => r = null;

		[TestMethod]
		[TestCategory("AddiereTest")]
		public void TestAddiere()
		{
			double x = r.Addiere(3, 4);
			Assert.AreEqual(7, x);
		}

		[TestMethod]
		[TestCategory("SubtrahiereTest")]
		public void TestSubtrahiere()
		{
			double x = r.Subtrahiere(10, 4);
			Assert.AreEqual(6, x);
		}
	}
}