using System;

namespace coffee
{
	public class MovementComponent : Component
	{
		GameMap Map { get; set; }

		public MovementComponent (GameObject parent, GameMap map) : base (parent)
		{
			Map = map;
		}

		//returns false if the move fails due to collision with another actor/solid tile
		public bool Move (Direction heading)
		{
			LocationComponent Transform = Parent.GetComponent<LocationComponent> ();

			switch (heading) {
			case Direction.North:
				Cell cell = Map.GetCell (Transform.Location + Vector2.North);
				if (cell.Blocked)
					return false;
				else {
					cell.Actor = Parent;
					Map.GetCell (Transform.Location).ClearActor ();
					Transform.Location += Vector2.North;
					return true;
				}
			}
			return false;
		}
	}
}
