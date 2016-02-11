using System;

namespace coffee
{
	public class StatsComponent : Component
	{
		public int Health{ get; private set; }

		public int Attack{ get; private set; }

		public int Defense{ get; private set; }

		public int Speed{ get; private set; }

		public bool Alive{ get; private set; }

		public StatsComponent (GameObject parent, int attack, int defence, int speed) : base (parent)
		{
			Attack = attack;
			Defense = defence;
			Speed = speed;
			Alive = true;
			Health = 100;
		}

		public void DealDamage (int damage)
		{
			Health -= damage;
			if (Health <= 0)
				Alive = false;
		}
	}
}

