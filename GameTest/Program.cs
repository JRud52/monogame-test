#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace GameTest
{
	static class Program
	{
		static GameManager game;

		internal static void RunGame()
		{
			game = new GameManager();
			game.Run();
		}

		[STAThread]

		static void Main(string[] args)
		{
			RunGame();
		}
	}
}
