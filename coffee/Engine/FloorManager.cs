using System;
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
		}

		public void UpdateActors ()
		{
			foreach (Actor actor in Actors)
				actor.Update ();
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

		// Returns false if there is a collision and the move failed.
		//		public bool MoveActor (Direction heading, Cell actor)
		//		{
		//			switch (heading) {
		//			case Direction.North:
		//				if (Map.IsTileSolid (Location + Vector2.North))
		//					return true;
		//				else {
		//					Location += Vector2.North;
		//					return false;
		//				}
		//			case Direction.South:
		//				if (Map.IsTileSolid (Location + Vector2.South))
		//					return true;
		//				else {
		//					Location += Vector2.South;
		//					return false;
		//				}
		//			case Direction.East:
		//				if (Map.IsTileSolid (Location + Vector2.East))
		//					return true;
		//				else {
		//					Location += Vector2.East;
		//					return false;
		//				}
		//			case Direction.West:
		//				if (Map.IsTileSolid (Location + Vector2.West))
		//					return true;
		//				else {
		//					Location += Vector2.West;
		//					return false;
		//				}
		//			default:
		//				throw new ArgumentException ("Bad move direction.");
		//			}
		//		}
	}
}

