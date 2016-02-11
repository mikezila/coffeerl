using System;

namespace coffee
{
	public class Cell
	{
		public enum VisionState : int
		{
			Hidden = 0,
			Seen,
			Visible
		}

		public GameObject Tile { get; private set; }

		public GameObject Actor { get; set; }

		public Item Item { get; set; }

		public Cell ()
		{

		}

		public void SetTile (GameObject tile)
		{
			Tile = tile;
		}

		public bool Blocked { 
			get { 

				return ((Tile != null && Tile.GetComponent<LocationComponent> ().Solid) || ((Actor != null) && Actor.GetComponent<LocationComponent> ().Solid));
			}
		}

		public void ClearActor ()
		{
			Actor = null;
		}

		public void ClearItem ()
		{
			Item = null;
		}
	}
}

