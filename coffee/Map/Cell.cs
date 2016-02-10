using System;

namespace coffee
{
	public class Cell
	{
		public Tile Tile { get; private set; }

		public Actor Actor { get; set; }

		public Item Item { get; set; }

		public Cell (Tile tile)
		{
			Tile = tile;
		}

		public void RemoveActor ()
		{
			Actor = null;
		}

	}
}

