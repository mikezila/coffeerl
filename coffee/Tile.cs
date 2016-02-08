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
			BloodyFloor,
			Wall = solidIndex,
			Tree,
			Crate
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
					return "Floor (Wet)";
				case TileType.BloodyFloor:
					return "Floor (Bloody)";
				case TileType.Tree:
					return "Tree";
				case TileType.Crate:
					return "Crate";
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
				case TileType.BloodyFloor:
				case TileType.WetFloor:
					return '.';
				case TileType.Wall:
				case TileType.Tree:
				case TileType.Crate:
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
				case TileType.BloodyFloor:
					return RLColor.Red;
				case TileType.WetFloor:
					return RLColor.Blue;
				case TileType.Tree:
					return RLColor.Green;
				case TileType.Crate:
					return RLColor.Brown;
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

