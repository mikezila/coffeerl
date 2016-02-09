using System;

namespace coffee
{
	public enum MonsterType : byte
	{
		Zombie = 0,
		Imp,
		Demon
	}

	public enum MonsterClass : byte
	{
		Normal = 0,
		Elite,
		Champion
	}

	public class Monster : Actor
	{
		public Monster (CMap map, Vector2 initialLocation)
		{
		}
	}
}

