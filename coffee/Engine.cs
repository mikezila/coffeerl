using System;
using RLNET;
using System.Collections.Generic;

namespace coffee
{
	public class Engine
	{
		private RLRootConsole game;
		private CMap map;
		private MessageSystem messages;
		private Player player;

		public Engine (RLRootConsole console)
		{
			game = console;
			game.Update += gameUpdate;
			game.Render += gameRender;
			messages = new MessageSystem (game);
			map = new CMap ("map1.cmap");
			player = new Player (map);
			actors.Add (player);
			actors.Add (new Zombie (map, new Vector2 (3, 3), MonsterStrength.Normal));
			actors.Add (new Imp (map, new Vector2 (20, 2), MonsterStrength.Normal));
			actors.Add (new Demon (map, new Vector2 (20, 8), MonsterStrength.Normal));
		}

		void renderUI ()
		{
			messages.RenderMessageScrollback ();

			// Render the tile type readout
			game.Print (0, 3, map.GetTile (player.Location.X, player.Location.Y).Name, RLColor.LightBlue);

			// Render the player's name
			game.Print (game.Width - player.Name.Length, 3, player.Name, RLColor.White);

			// Render HP
			game.Print (game.Width - 7, 0, "HP: " + player.Health.ToString (), RLColor.Red);
			game.Print (game.Width - 7, 1, "AP: 000", RLColor.Blue);
		}

		List<Actor> actors = new List<Actor> ();

		void renderActors ()
		{
			foreach (Actor actor in actors) {
				game.Set (actor.Location.X + mapOrigin.X, actor.Location.Y + mapOrigin.Y, RLColor.White, null, actor.Glyph);
			}
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
			bool completeTurn = false;
			Vector2 moveVector = Vector2.Zero;
			if (keypress != null) {
				switch (keypress.Key) {
				case RLKey.Up:
				case RLKey.W:
					moveCollide = player.Move (Direction.North);
					moveVector = Vector2.North;
					completeTurn = true;
					break;
				case RLKey.Down:
				case RLKey.S:
					moveCollide = player.Move (Direction.South);
					moveVector = Vector2.South;
					completeTurn = true;
					break;
				case RLKey.Left:
				case RLKey.A:
					moveCollide = player.Move (Direction.West);
					moveVector = Vector2.West;
					completeTurn = true;
					break;
				case RLKey.Right:
				case RLKey.D:
					moveCollide = player.Move (Direction.East);
					moveVector = Vector2.East;
					completeTurn = true;
					break;
				case RLKey.Q:
					messages.RandomQuote ();
					break;
				case RLKey.X:
					messages.AddMessage ("You wait.", Message.MessageType.Generic);
					completeTurn = true;
					break;
				case RLKey.Escape:
					game.Close ();
					break;
				}
				if (moveCollide) {
					string blockingType = map.GetTile (player.Location + moveVector).Name;
					messages.AddMessage ("The way is blocked by a " + blockingType);
				}
				if (completeTurn) {
					actors.Sort ();
					foreach (Actor actor in actors) {
						actor.Update ();
					}
				}
			}
		}

		void gameRender (object sender, UpdateEventArgs e)
		{
			game.Clear ();
			renderMap ();
			renderUI ();
			renderActors ();
			game.Draw ();
		}
	}
}

