using System;

namespace coffee
{
	public enum MonsterType : byte
	{
		Zombie = 0,
		Imp,
		Demon
	}

	public enum MonsterStrength : byte
	{
		Normal = 0,
		Elite,
		Champion
	}

	public abstract class Monster : Actor
	{
		public MonsterStrength Strength { get; protected set; }

		public MonsterType Type { get; protected set; }

		public void Wander ()
		{
			bool moved = false;
			while (!moved)
				moved = !RandomMove ();
		}

		//Returns true if collided with wall
		private bool RandomMove ()
		{
			switch (Util.RandomNumber (0, 4)) {
			case 0:
				return Move (Direction.North);
			case 1:
				return Move (Direction.South);
			case 2:
				return Move (Direction.East);
			case 3:
				return Move (Direction.West);
			default:
				throw new Exception ("Bad move direction");
			}
		}
	}
}

