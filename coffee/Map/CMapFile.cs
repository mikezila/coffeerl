using System;
using System.IO;

namespace coffee
{
	public class CMapFile : ICMap
	{
		// Part of header used to ID a coffeeMap file.
		const string Magic = "coffee";
		// Version number of map format that is supported.
		const int SupportedVersion = 1;

		public String Name { get; private set; }

		public Vector2 MapSize { get; private set; }

		public Vector2 PlayerStart { get; private set; }

		public char[] Tiles{ get; private set; }

		public CMapFile (string mapName)
		{
			LoadMap (mapName);
		}

		public char GetTile (Vector2 location)
		{
			return GetTile (location.X, location.Y);
		}

		public char GetTile (int x, int y)
		{
			if (x >= MapSize.X || x < 0 || y >= MapSize.Y || y < 0)
				throw new ArgumentException ("Map lookup out of range.");
			return Tiles [y * MapSize.X + x];
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
				MapSize = new Vector2 (Width, Height);
				Tiles = new char[MapSize.Size];

				//Grab player start
				string[] playerStart = file.ReadLine ().Split ('=') [1].Split (',');
				int startX = int.Parse (playerStart [0]);
				int startY = int.Parse (playerStart [1]);
				PlayerStart = new Vector2 (startX, startY);

				//Read in map data
				int currentTile = 0;
				while (currentTile < MapSize.Size) {
					char subject = (char)file.Read ();
					if (subject == '\n')
						continue;
					else {
						Tiles [currentTile] = subject;
						currentTile++;
					}
				}
			}
		}
	}
}

