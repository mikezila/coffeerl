using System;
using RLNET;
using System.Collections.Generic;

namespace coffee
{
	public class Engine
	{
		private RLRootConsole game;
		private List<string> messages = new List<string> ();
		private CMap map;

		// This is in map space, not screen space
		Vector2 playerPostion;

		public Engine (RLRootConsole console)
		{
			game = console;
			game.Update += gameUpdate;
			game.Render += gameRender;
			map = new CMap ("map1.cmap");
			playerPostion = map.PlayerStart;
			messages.Capacity = 100;
			messages.Add ("coffeeRogue v0.1 - \"Domino\"");
			messages.Add ("Entering floor 1..." + map.Name);
			messages.Add ("Prepare yourself!");
		}

		void renderUI ()
		{
			// Render the message scrollback
			int line = 0;
			game.Print (0, line++, messages [messages.Count - 3], RLColor.Gray);
			game.Print (0, line++, messages [messages.Count - 2], RLColor.LightGray);
			game.Print (0, line++, messages [messages.Count - 1], RLColor.White);

			// Render the tile type readout
			game.Print (0, line++, map.GetTile (playerPostion.X, playerPostion.Y).Name, RLColor.LightBlue);
		}

		void renderPlayer ()
		{
			game.Set (playerPostion.X + mapOrigin.X, playerPostion.Y + mapOrigin.Y, RLColor.White, null, '@');
		}

		// Where the top left of the map is drawn in screenspace
		Vector2 mapOrigin = new Vector2 (1, 5);

		void renderMap ()
		{
			for (int row = 0; row < map.Size.Y; row++) {
				for (int col = 0; col < map.Size.X; col++) {
					Tile tile = map.GetTile (col, row);
					game.Set (mapOrigin.X + col, mapOrigin.Y + row, tile.Color, null, tile.Glyph);
				}
			}
		}

		void gameUpdate (object sender, UpdateEventArgs e)
		{
			RLKeyPress keypress = game.Keyboard.GetKeyPress ();

			if (keypress != null) {
				switch (keypress.Key) {
				case RLKey.Up:
				case RLKey.W:
					messages.Add ("Death's advocate approaches...");
					playerPostion.Y--;
					break;
				case RLKey.Down:
					messages.Add ("The weight of the world feels lighter...");
					playerPostion.Y++;
					break;
				case RLKey.Left:
					messages.Add ("Your experience serves you well.");
					playerPostion.X--;
					break;
				case RLKey.Right:
					messages.Add ("You no longer fear fire.");
					playerPostion.X++;
					break;
				case RLKey.Escape:
					game.Close ();
					break;
				}
			}
		}

		void gameRender (object sender, UpdateEventArgs e)
		{
			game.Clear ();
			renderUI ();
			renderMap ();
			renderPlayer ();
			game.Draw ();
		}
	}
}

