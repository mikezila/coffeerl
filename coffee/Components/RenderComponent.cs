using System;

namespace coffee
{
	public class RenderComponent : Component
	{
		public RenderComponent (Actor parent) : base (parent)
		{
		}

		public void Render ()
		{
			Vector2 location = Parent.GetComponent<LocationComponent> ().Location;
		}
	}
}

