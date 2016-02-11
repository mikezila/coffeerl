using System;

namespace coffee
{
	public class GameMap
	{
		Cell[] Cells { get; set; }

		public Vector2 Size { get; private set; }

		static readonly Vector2 mapOrigin = new Vector2 (1, 5);

		public GameMap (string mapName)
		{
			CMapFile map = new CMapFile (mapName);
			Cells = new Cell[map.MapSize.Size];
			Size = map.MapSize;
			for (int i = 0; i < Size.Size; i++)
				Cells [i] = new Cell (map.Tiles [i]);
		}

		public Cell GetCell (Vector2 location)
		{
			return GetCell (location.X, location.Y);
		}

		public Cell GetCell (int x, int y)
		{
			if (x >= Size.X || x < 0 || y >= Size.Y || y < 0)
				throw new ArgumentException ("Map lookup out of range.");
			return Cells [y * Size.X + x];
		}

		private void RelocateActor (Vector2 origin, Vector2 destination)
		{
			GetCell (destination).Actor = GetCell (origin).Actor;
			GetCell (origin).ClearActor ();
		}

		public void Render ()
		{
			for (int row = 0; row < Size.Y; row++) {
				for (int col = 0; col < Size.X; col++) {
					Tile tile = GetCell (col, row).Tile;
					Util.Console.Set (mapOrigin.X + col, mapOrigin.Y + row, tile.Color, null, tile.Glyph);
				}
			}
		}
	}
}

