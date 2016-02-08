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
		private Player player;

		public Engine (RLRootConsole console)
		{
			game = console;
			game.Update += gameUpdate;
			game.Render += gameRender;
			map = new CMap ("map1.cmap");
			player = new Player (map, map.PlayerStart, "Dudeman Guyfellow");
			messages.Capacity = 100;
			messages.Add ("coffeeRogue v0.1 - \"Domino\"");
			messages.Add ("Entering floor 1..." + map.Name);
			messages.Add ("Prepare yourself!");
		}

		Random rand = new Random ();

		void RandomQuote ()
		{
			string[] quotes = new string[6];
			quotes [0] = "The way forward becomes clear.";
			quotes [1] = "The weight of the world seems lighter.";
			quotes [2] = "Death's advocate approaches...";
			quotes [3] = "The darkness here is tangible and unatural...";
			quotes [4] = "Your experience teaches you well.";
			quotes [5] = "You no longer fear fire.";

			messages.Add (quotes [rand.Next (6)]);
		}

		void renderUI ()
		{
			// Render the message scrollback
			int line = 0;
			game.Print (0, line++, messages [messages.Count - 3], RLColor.Gray);
			game.Print (0, line++, messages [messages.Count - 2], RLColor.LightGray);
			game.Print (0, line++, messages [messages.Count - 1], RLColor.White);

			// Render the tile type readout
			game.Print (0, line++, map.GetTile (player.Location.X, player.Location.Y).Name, RLColor.LightBlue);

			// Render HP
			game.Print (50, 0, "HP: " + player.Health.ToString (), RLColor.Red);
			game.Print (50, 1, "AP: 000", RLColor.Blue);
		}

		void renderPlayer ()
		{
			game.Set (player.Location.X + mapOrigin.X, player.Location.Y + mapOrigin.Y, RLColor.White, null, '@');
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

			bool moveCollide = false;
			Vector2 moveVector = Vector2.Zero;
			if (keypress != null) {
				switch (keypress.Key) {
				case RLKey.L:
					mapOrigin += Vector2.East;
					break;
				case RLKey.Up:
				case RLKey.W:
					moveCollide = player.Move (Direction.North);
					moveVector = Vector2.North;
					break;
				case RLKey.Down:
				case RLKey.S:
					moveCollide = player.Move (Direction.South);
					moveVector = Vector2.South;
					break;
				case RLKey.Left:
				case RLKey.A:
					moveCollide = player.Move (Direction.West);
					moveVector = Vector2.West;
					break;
				case RLKey.Right:
				case RLKey.D:
					moveCollide = player.Move (Direction.East);
					moveVector = Vector2.East;
					break;
				case RLKey.Q:
					RandomQuote ();
					break;
				case RLKey.Escape:
					game.Close ();
					break;
				}
				if (moveCollide) {
					string blockingType = map.GetTile (player.Location + moveVector).Name;
					messages.Add ("The way is blocked by a " + blockingType);
				}
			}
		}

		void gameRender (object sender, UpdateEventArgs e)
		{
			game.Clear ();
			renderMap ();
			renderUI ();
			renderPlayer ();
			game.Draw ();
		}
	}
}

