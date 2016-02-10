using System;
using RLNET;
using System.Collections.Generic;

namespace coffee
{
	public class FloorManager
	{
		Cell[] Cells { get; set; }

		public Vector2 Size { get; private set; }

		List<Actor> Actors { get; set; }

		public FloorManager (CMap map)
		{
			Size = map.Size;
			Cells = new Cell[map.Size.Size];

			for (int i = 0; i < Size.Size; i++)
				Cells [i] = new Cell (map.Tiles [i]);

			Actors = new List<Actor> ();

			Actor player = new Actor ();
			player.AddComponent<LocationComponent> (new LocationComponent (player, new Vector2 (3, 3)));
			player.AddComponent<GlyphComponent> (new GlyphComponent (player, '@', RLNET.RLColor.White, RLNET.RLColor.Green));
			player.AddComponent<RenderComponent> (new RenderComponent (player));
			player.AddComponent<KeyboardInputComponent> (new KeyboardInputComponent (player));

			Actors.Add (player);
		}

		public void UpdateActors (RLKeyPress keypress)
		{
			foreach (Actor actor in Actors) {
				if (keypress != null && actor.HasComponent<KeyboardInputComponent> ())
					actor.GetComponent<KeyboardInputComponent> ().Input (keypress);
				actor.Update ();
			}
		}

		Vector2 mapOrigin = new Vector2 (1, 5);

		public void RenderActors ()
		{
			foreach (Actor actor in Actors) {
				if (actor.HasComponent<RenderComponent> ()) {
					actor.GetComponent<RenderComponent> ().Render (mapOrigin);
				}
			}
		}

		public Cell GetCell (Vector2 location)
		{
			return GetCell (location.X, location.Y);
		}

		public Cell GetCell (int x, int y)
		{
			if (x >= Size.X || x < 0 || y >= Size.Y || y < 0)
				throw new ArgumentException ("Map lookup out of range.");
			return Cells [y * Size.X + x];
		}

		private void RelocateActor (Vector2 origin, Vector2 destination)
		{
			GetCell (destination).Actor = GetCell (origin).Actor;
			GetCell (origin).RemoveActor ();
		}
	}
}
