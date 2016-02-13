using System;
using System.Collections.Generic;

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

		public Stack<Region> Divisions { get; set; }

		public CMapGenerator ()
		{
			Tiles = new char[MapSize.Size];
			for (int i = 0; i < MapSize.Size; i++) {
				Tiles [i] = '5';
			}

			PlayerStart = new Vector2 (1, 1);

			Carve (new Vector2 (0, 0), new Vector2 (MapSize.X - 1, MapSize.Y - 1), 1);
		}

		// The origin must be the top left, the extent the bottom right
		private void Carve (Vector2 origin, Vector2 extent, int wallThickness = 0)
		{
			origin += wallThickness;
			extent -= wallThickness;

			for (int i = 0; i <= extent.X - origin.X; i++) {
				for (int j = 0; j <= extent.Y - origin.Y; j++) {
					Tiles [(origin.Y + j) * MapSize.X + (origin.X + i)] = '1';
				}
			}
		}

		private void FillCell (Vector2 cell, char type)
		{
			Tiles [cell.Y * MapSize.X + cell.X] = type;
		}
	}
}

