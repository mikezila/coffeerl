using System;

namespace coffee
{
	public class Region
	{
		public Vector2 Origin { get; private set; }

		public Vector2 Extent { get; private set; }

		public int Generation { get; private set; }

		public bool Terminal { get; private set; }

		public Region (Vector2 origin, Vector2 extent, int generation)
		{
			Origin = origin;
			Extent = extent;
			Generation = generation;
		}
	}
}

