using System;

namespace coffee
{
	public abstract class Actor
	{
		protected CMap map;

		public Vector2 Location{ get; protected set; }

		public string Name { get; protected set; }

		public int Health { get; protected set; }

		// Returns true if collides with a solid.
		public virtual bool Move (Direction heading)
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

