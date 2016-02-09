using System;

namespace coffee
{
	public class Imp : Monster
	{
		public Imp (CMap map, Vector2 initialLocation, MonsterStrength monsterStrength)
		{
			Strength = monsterStrength;
			Type = MonsterType.Imp;
			Map = map;
			Location = initialLocation;
			Glyph = 'i';
			Speed = 75;
		}

		public override void Update ()
		{
			Wander ();
		}
	}
}

