using System;
using Jint;

namespace CSBorg
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("C# .NET/Mono can do "+ANSIColor.yellow+"colors"+ANSIColor.reset+", too!");

			// see also: https://github.com/sebastienros/jint

			var engine = new Engine()
				.SetValue("log", new Action<object>(Console.WriteLine))
				;

			engine.Execute (@"
				function hello() {
					log('Hello from JavaScript!');
				};

				hello();
			");

		}
	}
}
