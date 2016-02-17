using System;

namespace coffee
{
	public class Region
	{
		public Vector2 Origin { get; private set; }

		public Vector2 Extent { get; private set; }

		public bool Terminal { get; set; }

		public bool AlreadyCut { get; set; }

		public int Height { get { return Extent.Y - Origin.Y; } }

		public int Width { get { return Extent.X - Origin.X; } }

		public int Generation { get; private set; }

		public Region (Vector2 origin, Vector2 extent, int generation)
		{
			Origin = origin;
			Extent = extent;
			Terminal = false;
			AlreadyCut = false;
		}
	}
}

