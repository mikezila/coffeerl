using System;

namespace coffee
{
	public class NameComponent : Component
	{
		public string Name { get; private set; }

		public string Title { get; private set; }

		public string NameAndTitle { get { return Name + ", " + Title; } }

		public NameComponent (GameObject parent, string name) : base (parent)
		{
			Name = name;
		}

		public NameComponent (GameObject parent) : base (parent)
		{
			Name = RandomName ();
		}

		public void Randomize ()
		{
			Name = RandomName ();
			Title = RandomTitle ();
		}

		private static string RandomTitle ()
		{
			string[] titles = new string[7];

			titles [0] = "the Uncharitable";
			titles [1] = "the Daring";
			titles [2] = "Collector of Bones";
			titles [3] = "Executor";
			titles [4] = "Keeper of Blades";
			titles [5] = "the Champion";
			titles [6] = "Title Holder";

			return titles [Util.RandomNumber (0, 7)];
		}

		private static string RandomName ()
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

			return firstNames [Util.RandomNumber (1, 10)] + " " + lastNames [Util.RandomNumber (1, 10)];
		}
	}
}
