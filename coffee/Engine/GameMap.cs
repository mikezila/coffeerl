using System;
using RLNET;

namespace coffee
{
	public class GameMap
	{
		Cell[] Cells { get; set; }

		public Vector2 Size { get; private set; }

		public GameMap (string mapName)
		{
			CMapFile map = new CMapFile (mapName);
			Cells = new Cell[map.MapSize.Size];
			Size = map.MapSize;
			for (int i = 0; i < Size.Size; i++) {
				Cells [i] = new Cell ();
				Cells [i].SetTile (CreateTile (map.Tiles [i], i));
			}
		}

		private GameObject CreateTile (char primative, int location)
		{
			GameObject tile = new GameObject ();
			tile.AddComponent<RenderComponent> (new RenderComponent (tile));

			switch (primative) {
			case '0':
				tile.AddComponent<LocationComponent> (new LocationComponent (tile, this, CellNumberToVector2 (location), true));
				tile.AddComponent<NameComponent> (new NameComponent (tile, "Floor"));
				tile.AddComponent<GlyphComponent> (new GlyphComponent (tile, ' ', RLColor.Black, RLColor.Black));
				break;
			case '1':
				tile.AddComponent<LocationComponent> (new LocationComponent (tile, this, CellNumberToVector2 (location), false));
				tile.AddComponent<NameComponent> (new NameComponent (tile, "Floor"));
				tile.AddComponent<GlyphComponent> (new GlyphComponent (tile, '.', RLColor.White, RLColor.Black));
				break;
			case '2':
				tile.AddComponent<LocationComponent> (new LocationComponent (tile, this, CellNumberToVector2 (location), false));
				tile.AddComponent<NameComponent> (new NameComponent (tile, "Floor (Wet)"));
				tile.AddComponent<GlyphComponent> (new GlyphComponent (tile, '.', RLColor.Blue, RLColor.Black));
				break;
			case '3':
				tile.AddComponent<LocationComponent> (new LocationComponent (tile, this, CellNumberToVector2 (location), false));
				tile.AddComponent<NameComponent> (new NameComponent (tile, "Floor (Bloody)"));
				tile.AddComponent<GlyphComponent> (new GlyphComponent (tile, '.', RLColor.Red, RLColor.Black));
				break;
			case '5':
				tile.AddComponent<LocationComponent> (new LocationComponent (tile, this, CellNumberToVector2 (location), true));
				tile.AddComponent<NameComponent> (new NameComponent (tile, "Wall"));
				tile.AddComponent<GlyphComponent> (new GlyphComponent (tile, '#', RLColor.White, RLColor.Black));
				break;
			case '6':
				tile.AddComponent<LocationComponent> (new LocationComponent (tile, this, CellNumberToVector2 (location), true));
				tile.AddComponent<NameComponent> (new NameComponent (tile, "Tree"));
				tile.AddComponent<GlyphComponent> (new GlyphComponent (tile, '#', RLColor.Green, RLColor.Black));
				break;
			case '7':
				tile.AddComponent<LocationComponent> (new LocationComponent (tile, this, CellNumberToVector2 (location), true));
				tile.AddComponent<NameComponent> (new NameComponent (tile, "Crate"));
				tile.AddComponent<GlyphComponent> (new GlyphComponent (tile, '#', RLColor.Brown, RLColor.Black));
				break;
			default:
				throw new ArgumentException ("Invalid tile type: " + primative);
			}

			return tile;

		}

		private Vector2 CellNumberToVector2 (int i)
		{
			return new Vector2 (i % Size.X, i / Size.X);
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
			foreach (Cell cell in Cells) {
				cell.Tile.GetComponent<RenderComponent> ().Render ();
			}

//			for (int row = 0; row < Size.Y; row++) {
//				for (int col = 0; col < Size.X; col++) {
//					LegacyTile tile = GetCell (col, row).Tile;
//					Util.Console.Set (mapOrigin.X + col, mapOrigin.Y + row, tile.Color, null, tile.Glyph);
//				}
//			}
		}
	}
}

