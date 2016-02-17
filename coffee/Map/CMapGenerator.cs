using System;
using System.Collections.Generic;

namespace coffee
{
	public class CMapGenerator : ICMap
	{
		// This is arbitrary, just something that feels good.
		// I want maps to always be one screen.
		public Vector2 MapSize { get { return new Vector2 (118, 50); } }

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

			// To carve out a place for the player to stand.
			// Just to make sure they don't spawn inside solid wall.
			FillCell (Vector2.One, '1');

			BSPGen ();
		}


		//TODO: This whole thing stinks.  I'm not sure if I should be impressed with myself or ashamed.
		private void BSPGen ()
		{
			List<Region> regions = new List<Region> ();

			//Root region
			Region root = new Region (Vector2.Zero, MapSize - 1, 0);
			root.Terminal = false;
			regions.Add (root);

			//Max number of division levels
			const int levels = 5;

			for (int i = 0; i <= levels; i++) {
				List<Region> newGeneration = new List<Region> ();
				foreach (Region node in regions) {
					if (node.AlreadyCut || node.Terminal)
						continue;
					node.AlreadyCut = true;
					newGeneration.AddRange (SliceRegion (node));
				}

				if (i == levels)
					foreach (Region node in newGeneration)
						node.Terminal = true;

				regions.AddRange (newGeneration);
				newGeneration.Clear ();
			}

			//Carve out our terminal regions
			foreach (Region node in regions) {
				if (node.Terminal)
					Carve (node, 1);
			}

			foreach (Region node in regions) {
				Console.WriteLine (node.Generation);
			}
		}

		private Region[] SliceRegion (Region subject)
		{
			const int wallMarginX = 2;
			const int wallMarginY = 2;
			int slicePoint;

			Region[] nextGen = new Region[2];

			int sliceType = Util.RandomNumber (0, 2);

			switch (sliceType) {
			case 0: // Vertical slice
				slicePoint = (subject.Extent.X - subject.Origin.X) / 2;
				nextGen [0] = new Region (subject.Origin, new Vector2 (subject.Origin.X + slicePoint, subject.Extent.Y), subject.Generation + 1); 
				nextGen [1] = new Region (new Vector2 (subject.Origin.X + slicePoint + 1, subject.Origin.Y), subject.Extent, subject.Generation + 1); 
				break;
			case 1: // Horizontal slice
				slicePoint = (subject.Extent.Y - subject.Origin.Y) / 2;
				nextGen [0] = new Region (subject.Origin, new Vector2 (subject.Extent.X, subject.Origin.Y + slicePoint), subject.Generation + 1);
				nextGen [1] = new Region (new Vector2 (subject.Origin.X, subject.Origin.Y + slicePoint + 1), subject.Extent, subject.Generation + 1);
				break;
			default:
				throw new Exception ("Bad cut type.");
			}

			//Mark any regions smaller than this to not be split again
			const int minSize = 6;

			for (int i = 0; i < 2; i++) {
				if (nextGen [i].Width <= minSize || nextGen [i].Height <= minSize)
					nextGen [i].Terminal = true;
					
			}

			return nextGen;
		}

		private void Carve (Region Region, int wallThickness = 0)
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

