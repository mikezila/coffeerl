using System;

namespace coffee
{
	public class LocationComponent : Component
	{
		public Vector2 Location { get; private set; }

		GameMap Map{ get; set; }

		public LocationComponent (GameObject parent, GameMap map, Vector2 initialLocation) : base (parent)
		{
			Map = map;
			Location = initialLocation;
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
	}
}

