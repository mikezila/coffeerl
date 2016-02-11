using System;

namespace coffee
{
	public class MovementComponent : Component
	{
		GameMap Map { get; set; }

		public MovementComponent (GameObject parent, GameMap map) : base (parent)
		{
			Map = map;
			Map.GetCell (Parent.GetComponent<LocationComponent> ().Location).Actor = parent;
		}

		//returns false if the move fails due to collision with another actor/solid tile
		public bool Move (Direction heading)
		{
			LocationComponent Transform = Parent.GetComponent<LocationComponent> ();
			Cell cell;

			switch (heading) {
			case Direction.North:
				cell = Map.GetCell (Transform.Location + Vector2.North);
				if (cell.Blocked)
					return false;
				else {
					Transform.TranslateLocation (Vector2.North);
					return true;
				}
			case Direction.South:
				cell = Map.GetCell (Transform.Location + Vector2.South);
				if (cell.Blocked)
					return false;
				else {
					Transform.TranslateLocation (Vector2.South);
					return true;
				}
			
			case Direction.East:
				cell = Map.GetCell (Transform.Location + Vector2.East);
				if (cell.Blocked)
					return false;
				else {
					Transform.TranslateLocation (Vector2.East);
					return true;
				}
			case Direction.West:
				cell = Map.GetCell (Transform.Location + Vector2.West);
				if (cell.Blocked)
					return false;
				else {
					Transform.TranslateLocation (Vector2.West);
					return true;
				}
			case Direction.None:
			default:
				throw new ArgumentException ("Invalid movement heading");
			}
		}
	}
}
