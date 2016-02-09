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

	public class Monster : Actor
	{
		public MonsterStrength Strength { get; private set; }

		public MonsterType Type { get; private set; }

		public Monster (CMap map, Vector2 initialLocation, MonsterType monsterType, MonsterStrength monsterStrength)
		{
			Rand = new Random ();
			Strength = monsterStrength;
			Type = monsterType;
			Map = map;
			Location = initialLocation;
			Glyph = 'z';
		}

		public override void Update ()
		{
			Wander ();
		}

		public void Wander ()
		{
			bool moved = false;
			while (!moved)
				moved = !RandomMove ();
		}

		//Returns true if collided with wall
		private bool RandomMove ()
		{
			switch (Rand.Next (4)) {
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

