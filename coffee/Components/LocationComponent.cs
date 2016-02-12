using System;

namespace coffee
{
	public class LocationComponent : Component
	{
		public Vector2 Location { get; private set; }

		public bool Solid { get; set; }

		GameMap Map{ get; set; }

		public LocationComponent (GameObject parent, GameMap map, Vector2 initialLocation, bool solid) : base (parent)
		{
			Map = map;
			Location = initialLocation;
			Solid = solid;
			Spawn (initialLocation);
		}

		private void Spawn (Vector2 spawnLocation)
		{
			if (Map.GetCell (spawnLocation).Blocked) {
				throw new ArgumentException ("Tried to spawn in occupied or blocked cell.");
			} else
				Map.GetCell (spawnLocation).Actor = Parent;
		}

		public void TranslateLocation (Vector2 heading)
		{
			Map.GetCell (Location).ClearActor ();
			Location += heading;
			SetLocation (Location);
		}

		public void SetLocation (Vector2 destination)
		{
			Map.GetCell (Location).ClearActor ();
			Location = destination;
			Map.GetCell (Location).Actor = Parent;
		}

		public Cell.VisionState Visibility {
			get {
				return Map.GetCell (Location).Vision;
			}
		}
	}
}

