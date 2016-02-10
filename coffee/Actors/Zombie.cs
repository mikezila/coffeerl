using System;

namespace coffee
{
	public class Zombie : Monster
	{
		public Zombie (CMap map, Vector2 initialLocation, MonsterStrength monsterStrength)
		{
			Strength = monsterStrength;
			Type = MonsterType.Zombie;
			Name = "Zombie";
			Map = map;
			Location = initialLocation;
			Glyph = 'z';
			Speed = 25;
		}

		public override void Update ()
		{
			Wander ();
		}
	}
}

