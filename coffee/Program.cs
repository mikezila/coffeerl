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
			setup.Scale = 1f;
			setup.BitmapFile = "dsc8x12.png";
			setup.CharWidth = 8;
			setup.CharHeight = 12;
			setup.WindowBorder = RLWindowBorder.Fixed;
			setup.Width = 80;
			setup.Height = 40;
			setup.Title = "coffee";
			game = new RLRootConsole (setup);
			new Engine (game);
			game.Run ();
		}
	}
}