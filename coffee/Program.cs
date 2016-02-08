using RLNET;
using System;
using System.Collections.Generic;

namespace coffee
{
	public class Program
	{
		static RLRootConsole game;

		public static void Main ()
		{
			RLSettings setup = new RLSettings ();
			setup.Scale = 2f;
			setup.BitmapFile = "ascii_8x8.png";
			setup.CharWidth = setup.CharHeight = 8;
			setup.WindowBorder = RLWindowBorder.Fixed;
			setup.Width = 60;
			setup.Height = 40;
			setup.Title = "coffee";
			game = new RLRootConsole (setup);
			new Engine (game);
			game.Run ();
		}
	}
}