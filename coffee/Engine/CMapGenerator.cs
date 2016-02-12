using System;

namespace coffee
{
	public class CMapGenerator : ICMap
	{
		// This is arbitrary, just something the feels good.
		// I want maps to always be one screen.
		public Vector2 MapSize { get { return new Vector2 (78, 28); } }

		public char[] Tiles { get; set; }

		public string Name { get; set; }

		public Vector2 PlayerStart { get; private set; }

		public CMapGenerator ()
		{
			Tiles = new char[MapSize.Size];
			for (int i = 0; i < MapSize.Size; i++) {
				Tiles [i] = '5';
			}

			PlayerStart = Vector2.Zero;
			Tiles [0] = '1';
		}
	}
}

