using System;

namespace coffee
{
	public class NameComponent : Component
	{
		public string Name { get; private set; }

		public NameComponent (Actor parent, string name) : base (parent)
		{
			Name = name;
		}

		public void Randomize ()
		{
			Name = Util.RandomName ();
		}
	}
}
