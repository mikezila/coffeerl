using System;
using System.Collections.Generic;

namespace coffee
{
	public class VisionComponent : Component
	{
		public int Range { get; set; }

		GameMap Map { get; set; }

		public VisionComponent (GameObject parent, GameMap map, int visionRange) : base (parent)
		{
			Map = map;
			Range = visionRange;
		}

		List<Cell> seenLastTurn = new List<Cell> ();

		public override void Update ()
		{
			//Unsee things we saw last turn
			foreach (Cell cell in seenLastTurn)
				cell.UnseeTile ();

			seenLastTurn.Clear ();

			Vector2 visionOrigin = Parent.GetComponent<LocationComponent> ().Location + new Vector2 (-Range, -Range);

			for (int i = 0; i < Range * 2 + 1; i++) {
				for (int j = 0; j < Range * 2 + 1; j++) {
					Vector2 subject = visionOrigin + new Vector2 (i, j);
					if (Vector2.IsInside (subject, Map.Size)) {
						seenLastTurn.Add (Map.GetCell (subject));
						Map.GetCell (subject).SeeTile ();
					}
				}
			}
		}
	}
}

