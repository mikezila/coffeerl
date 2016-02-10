using System;

namespace coffee
{
	public class LocationComponent
	{
		public Vector2 Location { get; private set; }

		public LocationComponent (Vector2 initialLocation)
		{
			Location = initialLocation;
		}
	}
}

