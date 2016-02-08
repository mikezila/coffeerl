using System;
using RLNET;

namespace coffee
{
	public class Tile
	{
		// Types with a type higher than this are "solid" and cannot be moved through.
		const int solidIndex = 5;

		public enum TileType : int
		{
			Void = 0,
			Floor = 1,
			WetFloor,
			Wall = solidIndex,
			Tree,
		}

		public bool Solid { get { return((int)Type >= solidIndex); } }

		public string Name {
			get {
				switch (Type) {
				case TileType.Floor:
					return "Floor";
				case TileType.Void:
					return "Void";
				case TileType.Wall:
					return "Wall";
				case TileType.WetFloor:
					return "Wet Floor";
				case TileType.Tree:
					return "Tree";
				default:
					throw new Exception ("Bad tile type: " + Type);
				}
			}
		}

		public char Glyph {
			get {
				switch (Type) {
				case TileType.Void:
					return ' ';
				case TileType.Floor:
				case TileType.WetFloor:
					return '.';
				case TileType.Wall:
				case TileType.Tree:
					return '#';
				default:
					throw new Exception ("Bad tile type: " + Type);
				}
			}
		}

		public RLColor Color {
			get {
				switch (Type) {
				case TileType.Void:
				case TileType.Wall:
				case TileType.Floor:
					return RLColor.White;
				case TileType.WetFloor:
					return RLColor.Blue;
				case TileType.Tree:
					return RLColor.Green;
				default:
					return RLColor.White;
				}
			}
		}

		TileType Type;

		public Tile (TileType type)
		{
			Type = type;
		}
	}
}

