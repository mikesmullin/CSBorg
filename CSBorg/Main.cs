using System;
using System.IO;
using Jint;
using Renci.SshNet;

namespace CSBorg
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("C# .NET/Mono can do "+ANSIColor.yellow+"colors"+ANSIColor.reset+", too!");

			using (var client = new SshClient("localhost", "developer", "tunafish"))
			{
				client.Connect();
				var sshResult = client.RunCommand("date");
				Console.WriteLine(sshResult.Result);
				client.Disconnect();
				Console.WriteLine ("C# .NET/Mono can connect over SSH, too!");
			}

			// see also: https://github.com/sebastienros/jint
			string CoffeeScript = File.ReadAllText(Path.Combine("resources", "coffee-script-1.8.0", "coffee-script.min.js"));
			var result = new Engine()
				.SetValue("__source", "a = b: c: 1")
				.Execute(CoffeeScript + "\nCoffeeScript.compile(__source, {bare: true});")
				.GetCompletionValue()
				.ToObject();
			Console.WriteLine(result);
			Console.WriteLine("C# .NET/Mono can compile CSON, too!");
		}
	}
}
