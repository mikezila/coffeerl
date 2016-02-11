using System;

namespace coffee
{
	public class LocationComponent : Component
	{
		public Vector2 Location { get; set; }

		public LocationComponent (GameObject parent, Vector2 initialLocation) : base (parent)
		{
			Location = initialLocation;
		}
	}
}

