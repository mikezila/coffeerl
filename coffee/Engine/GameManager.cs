using System;
using RLNET;
using System.Collections.Generic;

namespace coffee
{
	public class GameManager
	{
		List<GameObject> Objects { get; set; }

		GameMap Map { get; set; }

		public GameManager ()
		{
			Map = new GameMap ("map1.cmap");
			Objects = new List<GameObject> ();

			GameObject player = new GameObject ();
			player.AddComponent<LocationComponent> (new LocationComponent (player, Map, new Vector2 (3, 3)));
			player.AddComponent<GlyphComponent> (new GlyphComponent (player, '@', RLNET.RLColor.White, RLNET.RLColor.Black));
			player.AddComponent<RenderComponent> (new RenderComponent (player));
			player.AddComponent<MovementComponent> (new MovementComponent (player, Map));
			player.AddComponent<KeyboardInputComponent> (new KeyboardInputComponent (player));

			Objects.Add (MonsterMaker (new Vector2 (4, 2)));

			Objects.Add (player);
		}

		// This is just a temp method to generate monsters until I have the map generator in and working.
		// At that point monsters will be generated at map creation.
		private GameObject MonsterMaker (Vector2 initialLocation)
		{
			GameObject monster = new GameObject ();
			monster.AddComponent<LocationComponent> (new LocationComponent (monster, Map, initialLocation));
			monster.AddComponent<GlyphComponent> (new GlyphComponent (monster, 'Z', RLColor.Green, RLColor.Black));
			monster.AddComponent<RenderComponent> (new RenderComponent (monster));
			monster.AddComponent<NameComponent> (new NameComponent (monster, "Zombie"));
			monster.AddComponent<MovementComponent> (new MovementComponent (monster, Map));
			monster.AddComponent<AIInputComponent> (new AIInputComponent (monster));

			return monster;
		}

		public void Update (RLKeyPress keypress)
		{
			foreach (GameObject actor in Objects) {
				if (keypress != null && actor.HasComponent<KeyboardInputComponent> ())
					actor.GetComponent<KeyboardInputComponent> ().Input (keypress);
				actor.Update ();
			}
		}

		public void Render ()
		{
			Map.Render ();
			foreach (GameObject actor in Objects) {
				if (actor.HasComponent<RenderComponent> ()) {
					actor.GetComponent<RenderComponent> ().Render ();
				}
			}
		}
	}
}
