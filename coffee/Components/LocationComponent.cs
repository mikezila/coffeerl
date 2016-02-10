using System;

namespace coffee
{
	public class LocationComponent : Component
	{
		public Vector2 Location { get; private set; }

		public LocationComponent (Actor parent, Vector2 initialLocation) : base (parent)
		{
			Location = initialLocation;
		}
	}
}

