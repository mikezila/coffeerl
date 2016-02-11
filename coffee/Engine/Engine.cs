using System;
using RLNET;
using System.Collections.Generic;

namespace coffee
{
	public class Engine
	{
		private GameManager manager;

		public Engine (RLRootConsole console)
		{
			Util.Console = console;
			Util.Messages = new MessageSystem ();
			manager = new GameManager ();
			Util.Console.Update += gameUpdate;
			Util.Console.Render += gameRender;
		}

		void renderUI ()
		{
			Util.Messages.RenderMessageScrollback ();

			// Render the tile type readout
			//game.Print (0, 3, map.GetTile (player.Location.X, player.Location.Y).Name, RLColor.LightBlue);

			// Render the player's name
			//game.Print (game.Width - player.Name.Length, 3, player.Name, RLColor.White);

			// Render HP
			//game.Print (game.Width - 7, 0, "HP: " + player.Health.ToString (), RLColor.Red);
			//game.Print (game.Width - 7, 1, "AP: 000", RLColor.Blue);
		}

		void renderGame ()
		{
			manager.Render ();
		}

		void gameUpdate (object sender, UpdateEventArgs e)
		{
			// Poll for a keypress
			RLKeyPress keypress = Util.Console.Keyboard.GetKeyPress ();

			// Before anything else, check if we should just quit.
			if (keypress != null && keypress.Key == RLKey.Escape)
				Util.Console.Close ();

			// Send the keypress into the GameManger's update cycle
			manager.Update (keypress);
		}

		void gameRender (object sender, UpdateEventArgs e)
		{
			Util.Console.Clear ();
			renderUI ();
			renderGame ();
			Util.Console.Draw ();
		}
	}
}

