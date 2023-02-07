using System.Diagnostics;

class Program
{
	static void Main(string[] args)
	{

		if (!System.Diagnostics.EventLog.Exists("MyLog"))
		{
			try
			{
				System.Diagnostics.EventLog.CreateEventSource("MySource", "MyLog");

			}
			catch (Exception ex)
			{
				Console.WriteLine("Error Creating EventLog: \n" + ex.ToString());

				return;
			}

			Console.WriteLine("Successfully created EventLog: Application and Services Logs\\MyLog");

		}

		var MyEventLog = new EventLog() { Source = "MyLog", EnableRaisingEvents = true };
		var MyEvent = new EventInstance(0, 1);

		try
		{
			MyEventLog.WriteEvent(MyEvent, "This is a message to be written");
		}

		catch (Exception ex)
		{
			Console.WriteLine("Error in WriteEvent: \n" + ex.ToString());

			return;
		}
		Console.WriteLine("WriteEvent success. Press any key to continue.");

		Console.ReadLine();
	}
}
