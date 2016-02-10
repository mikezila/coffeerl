using System;

namespace coffee
{
	public abstract class Component
	{
		public Actor Parent { get; private set; }

		public Component (Actor parent)
		{
			Parent = parent;
		}

		public virtual void Update ()
		{
		}
	}
}

