using System;
using System.IO;

namespace coffee
{
	public class Vector2
	{
		public int X;
		public int Y;

		public int Size{ get { return X * Y; } }

		public static Vector2 North{ get { return new Vector2 (0, -1); } }

		public static Vector2 South{ get { return new Vector2 (0, 1); } }

		public static Vector2 East{ get { return new Vector2 (1, 0); } }

		public static Vector2 West{ get { return new Vector2 (-1, 0); } }

		public static Vector2 Zero{ get { return new Vector2 (0, 0); } }

		public static Vector2 operator + (Vector2 a, Vector2 b)
		{
			return new Vector2 (a.X + b.X, a.Y + b.Y);
		}

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

		public bool IsTileSolid (Vector2 location)
		{
			return IsTileSolid (location.X, location.Y);
		}

		public bool IsTileSolid (int x, int y)
		{
			return GetTile (x, y).Solid;
		}

		public Tile GetTile (Vector2 location)
		{
			return GetTile (location.X, location.Y);
		}

		public Tile GetTile (int x, int y)
		{
			if (x >= Size.X || x < 0 || y >= Size.Y || y < 0)
				throw new ArgumentException ("Map lookup out of range.");
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

