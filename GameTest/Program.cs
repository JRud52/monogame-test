#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace GameTest
{
	static class Program
	{
		private static Game1 game;

		internal static void RunGame()
		{
			game = new Game1();
			game.Run();
		}

		[STAThread]

		static void Main(string[] args)
		{
			RunGame();
		}
	}
}
