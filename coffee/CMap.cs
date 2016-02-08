using System;
using System.IO;

namespace coffee
{
	public struct Vector2
	{
		public int X;
		public int Y;

		public int Size{ get { return X * Y; } }

		public Vector2 (int width, int height)
		{
			X = width;
			Y = height;
		}
	}

	public class CMap
	{
		// Part of header used to ID a coffeeMap file.
		const string Magic = "coffee";
		// Version number of map format that is supported.
		const int SupportedVersion = 1;

		public String Name { get; private set; }

		public Vector2 Size { get; private set; }

		public Vector2 PlayerStart { get; private set; }

		Tile[] Tiles{ get; set; }

		public CMap (string mapName)
		{
			LoadMap (mapName);
		}

		public Tile GetTile (int x, int y)
		{
			return Tiles [y * Size.X + x];
		}

		void LoadMap (string mapName)
		{
			using (var file = File.OpenText (mapName)) {
				//Check to see if the header is the right version and throw up if it's not.
				if (file.ReadLine () != Magic || !file.ReadLine ().EndsWith ("1")) {
					throw new Exception ("Bad map header or the wrong map version.");
				}

				//Grab map name
				Name = file.ReadLine ();

				//Grab map size
				string[] mapSize = file.ReadLine ().Split ('=') [1].Split ('x');
				int Width = int.Parse (mapSize [0]);
				int Height = int.Parse (mapSize [1]);
				Size = new Vector2 (Width, Height);
				Tiles = new Tile[Size.Size];

				//Grab player start
				string[] playerStart = file.ReadLine ().Split ('=') [1].Split (',');
				int startX = int.Parse (playerStart [0]);
				int startY = int.Parse (playerStart [1]);
				PlayerStart = new Vector2 (startX, startY);

				//Read in map data
				int currentTile = 0;
				while (currentTile < Size.Size) {
					char subject = (char)file.Read ();
					if (subject == '\n')
						continue;
					else {
						Tiles [currentTile] = new Tile ((Tile.TileType)int.Parse (subject.ToString ()));
						currentTile++;
					}
				}
			}
		}
	}
}

