using System;

namespace coffee
{
	public class Cell
	{
		public Tile Tile { get; private set; }

		public GameObject Actor { get; set; }

		public Item Item { get; set; }

		public Cell (Tile tile)
		{
			Tile = tile;
		}

		public bool Blocked 
		{ get { return Tile.Solid || Actor != null; } }

		public void ClearActor ()
		{
			Actor = null;
		}

		public void ClearItem ()
		{
			Item = null;
		}
	}
}

