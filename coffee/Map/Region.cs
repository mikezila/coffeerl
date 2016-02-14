using System;

namespace coffee
{
	public class Region
	{
		public Vector2 Origin { get; private set; }

		public Vector2 Extent { get; private set; }

		public bool Terminal { get; set; }

		public bool AlreadyCut { get; set; }

		public Region (Vector2 origin, Vector2 extent)
		{
			Origin = origin;
			Extent = extent;
			Terminal = false;
			AlreadyCut = false;
		}
	}
}

