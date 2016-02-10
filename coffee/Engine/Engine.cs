using System;
using RLNET;
using System.Collections.Generic;

namespace coffee
{
	public class Engine
	{
		private FloorManager manager;

		public Engine (RLRootConsole console)
		{
			Util.Console = console;
			Util.Messages = new MessageSystem ();
			manager = new FloorManager (new CMap ("map1.cmap"));
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

		void renderActors ()
		{

		}

		// Where the top left of the map is drawn in screenspace
		Vector2 mapOrigin = new Vector2 (1, 5);

		void renderMap ()
		{
			for (int row = 0; row < manager.Size.Y; row++) {
				for (int col = 0; col < manager.Size.X; col++) {
					Tile tile = manager.GetCell (col, row).Tile;
					Util.Console.Set (mapOrigin.X + col, mapOrigin.Y + row, tile.Color, null, tile.Glyph);
				}
			}
		}

		void gameUpdate (object sender, UpdateEventArgs e)
		{
			RLKeyPress keypress = Util.Console.Keyboard.GetKeyPress ();

			Vector2 moveVector = Vector2.Zero;
			if (keypress != null) {
				switch (keypress.Key) {
				case RLKey.Q:
					Util.Messages.RandomQuote ();
					break;
				case RLKey.Escape:
					Util.Console.Close ();
					break;
				}
			}
		}

		void gameRender (object sender, UpdateEventArgs e)
		{
			Util.Console.Clear ();
			renderMap ();
			renderUI ();
			renderActors ();
			Util.Console.Draw ();
		}
	}
}

