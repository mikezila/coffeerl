using System;

namespace coffee
{
	public abstract class Component
	{
		public GameObject Parent { get; private set; }

		public Component (GameObject parent)
		{
			Parent = parent;
		}

		public virtual void Update ()
		{
		}
	}
}

