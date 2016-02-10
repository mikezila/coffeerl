using System;

namespace coffee
{
	public class Demon : Monster
	{
		public Demon (CMap map, Vector2 initialLocation, MonsterStrength monsterStrength)
		{
			Strength = monsterStrength;
			Type = MonsterType.Demon;
			Name = "Demon";
			Map = map;
			Location = initialLocation;
			Glyph = 'd';
			Speed = 50;
		}

		public override void Update ()
		{
			Wander ();
		}
	}
}

