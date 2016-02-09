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

	public class Player : Actor
	{
		public Player (CMap map, string name)
		{
			this.map = map;
			Health = 100;
			Location = map.PlayerStart;
			Name = name;
		}

		public Player (CMap map)
		{
			this.map = map;
			Health = 100;
			Location = map.PlayerStart;
			Name = RandomizeName ();
		}

		// Random names!
		Random rand = new Random ();

		private string RandomizeName ()
		{
			string[] firstNames = new string[10];
			string[] lastNames = new string[10];

			firstNames [0] = "Malacai";
			firstNames [1] = "Guy";
			firstNames [2] = "Albert";
			firstNames [3] = "Gregor";
			firstNames [4] = "J";
			firstNames [5] = "Alex";
			firstNames [6] = "Zoe";
			firstNames [7] = "Nastasha";
			firstNames [8] = "Meryl";
			firstNames [9] = "M";

			lastNames [0] = "Cross";
			lastNames [1] = "Lambert";
			lastNames [2] = "Lawson";
			lastNames [3] = "King";
			lastNames [4] = "Porter";
			lastNames [5] = "Blade";
			lastNames [6] = "Guiver";
			lastNames [7] = "Slamm";
			lastNames [8] = "Xi";
			lastNames [9] = "Sly";

			return firstNames [rand.Next (10)] + " " + lastNames [rand.Next (10)];
		}
	}
}

