using System;
using System.Collections.Generic;

namespace coffee
{
	public class CMapGenerator : ICMap
	{
		// This is arbitrary, just something that feels good.
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

			PlayerStart = Vector2.One;
			Name = "Debug Land";

			FillCell (Vector2.One, '1');

			BSPGen ();
		}

		private void BSPGen ()
		{
			List<Region> regions = new List<Region> ();

			//Root region
			regions.Add (new Region (Vector2.Zero, MapSize - 1));
			regions [0].Terminal = false;

			regions.AddRange (SliceRegion (regions [0]));



			//Carve out our terminal regions
			foreach (Region node in regions)
				if (node.Terminal)
					CarveRegion (node, 1);
		}

		private Region[] SliceRegion (Region subject)
		{
			const int wallMarginX = 8;
			const int wallMarginY = 5;
			int slicePoint;

			Region[] nextGen = new Region[2];

			int sliceType = Util.RandomNumber (0, 2);

			switch (sliceType) {
			case 0: // Vertical slice
				slicePoint = Util.RandomNumber (subject.Origin.X + wallMarginX, subject.Extent.X - wallMarginX);
				nextGen [0] = new Region (subject.Origin, new Vector2 (slicePoint, subject.Extent.Y));
				nextGen [1] = new Region (new Vector2 (subject.Origin.X + slicePoint + 1, subject.Origin.Y), subject.Extent);
				nextGen [0].Terminal = true;
				nextGen [1].Terminal = true;
				break;
			case 1: // Horizontal slice
				slicePoint = Util.RandomNumber (subject.Origin.Y + wallMarginY, subject.Extent.Y - wallMarginY);
				nextGen [0] = new Region (subject.Origin, new Vector2 (subject.Extent.X, slicePoint));
				nextGen [1] = new Region (new Vector2 (subject.Origin.X, subject.Origin.Y + slicePoint + 1), subject.Extent);
				nextGen [0].Terminal = true;
				nextGen [1].Terminal = true;
				break;
			default:
				throw new Exception ("Level generator is busted.");
			}

			return nextGen;
		}

		private void CarveRegion (Region Region, int wallThickness = 0)
		{
			Carve (Region.Origin, Region.Extent, wallThickness);
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

