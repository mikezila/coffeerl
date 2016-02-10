using System;

namespace coffee
{
	public class StatsComponent
	{
		public int Attack{ get; private set; }

		public int Defense{ get; private set; }

		public int Speed{ get; private set; }

		public StatsComponent (int attack, int defence, int speed)
		{
			Attack = attack;
			Defense = defence;
			Speed = speed;
		}

		public void Update ()
		{

		}
	}
}

