namespace TimingServiceTest;


internal class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Start");

		TimingTestCode t=new TimingTestCode();
		t.Start();

		//Thread.Sleep(30000);

        Console.WriteLine("End!");
    }
}
