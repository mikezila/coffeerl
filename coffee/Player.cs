using System;

namespace coffee
{
	public enum Direction
	{
		None,
		North,
		South,
		East,
		West
	}

	public class Player
	{
		public string Name { get; private set; }

		public int Health { get; private set; }

		public Vector2 Location { get; private set; }

		private CMap map;

		public Player (CMap map, Vector2 initialLocation, string name)
		{
			this.map = map;
			Health = 100;
			Location = initialLocation;
			Name = name;
		}

		// Returns true if collides with a solid.
		public bool Move (Direction heading)
		{
			switch (heading) {
			case Direction.North:
				if (map.IsTileSolid (Location + Vector2.North))
					return true;
				else {
					Location += Vector2.North;
					return false;
				}
			case Direction.South:
				if (map.IsTileSolid (Location + Vector2.South))
					return true;
				else {
					Location += Vector2.South;
					return false;
				}
			case Direction.East:
				if (map.IsTileSolid (Location + Vector2.East))
					return true;
				else {
					Location += Vector2.East;
					return false;
				}
			case Direction.West:
				if (map.IsTileSolid (Location + Vector2.West))
					return true;
				else {
					Location += Vector2.West;
					return false;
				}
			default:
				throw new ArgumentException ("Bad move direction.");
			}
		}
	}
}

