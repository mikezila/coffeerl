using System;
using RLNET;
using System.Collections.Generic;

namespace coffee
{
	public class GameManager
	{
		List<GameObject> Objects { get; set; }

		GameMap Map { get; set; }

		GameObject Player { get; set; }

        List<UIWindow> Windows { get; set; }

		public GameManager ()
		{
            Windows = new List<UIWindow>();
			ReGenMap ();
		}

		// This is just a temp method to generate monsters until I have the map generator in and working.
		// At that point monsters will be generated at map creation.
		private GameObject MonsterMaker (Vector2 initialLocation)
		{
			GameObject monster = new GameObject ();
			monster.AddComponent<LocationComponent> (new LocationComponent (monster, Map, initialLocation, true));
			monster.AddComponent<GlyphComponent> (new GlyphComponent (monster, 'Z', RLColor.Green, RLColor.Black));
			monster.AddComponent<RenderComponent> (new RenderComponent (monster));
			monster.AddComponent<NameComponent> (new NameComponent (monster, "Zombie"));
			monster.AddComponent<MovementComponent> (new MovementComponent (monster, Map));
			monster.AddComponent<AIInputComponent> (new AIInputComponent (monster));
			monster.AddComponent<FactionComponent> (new FactionComponent (monster, Faction.Monster));

			return monster;
		}

		private GameObject PlayerMaker ()
		{
			GameObject player = new GameObject ();
			player.AddComponent<LocationComponent> (new LocationComponent (player, Map, Map.PlayerStart, true));
			player.AddComponent<GlyphComponent> (new GlyphComponent (player, '@', RLNET.RLColor.White, RLNET.RLColor.Black));
			player.AddComponent<RenderComponent> (new RenderComponent (player));
			player.AddComponent<MovementComponent> (new MovementComponent (player, Map));
			player.AddComponent<KeyboardInputComponent> (new KeyboardInputComponent (player));
			player.AddComponent<FactionComponent> (new FactionComponent (player, Faction.Player));
			player.AddComponent<VisionComponent> (new VisionComponent (player, Map, 4));
			player.AddComponent<GameFlowComponent> (new GameFlowComponent (player));
			return player;
		}

		public void ReGenMap ()
		{
			Map = new GameMap ();
			Objects = new List<GameObject> ();
			Player = PlayerMaker ();
			Objects.Add (Player);
		}

		//TODO: Undo this hack.  It's just in place as an experiment.
		public void Update (RLKeyPress keypress)
		{
			Player.GetComponent<GameFlowComponent> ().TurnBegins ();
			Player.Update ();
			if (keypress != null)
				Player.GetComponent<KeyboardInputComponent> ().Input (keypress);
			if (Player.GetComponent<GameFlowComponent> ().StopFlow)
				return;

			foreach (GameObject actor in Objects) {
//				if (keypress != null && actor.HasComponent<KeyboardInputComponent> ())
//					actor.GetComponent<KeyboardInputComponent> ().Input (keypress);
				actor.Update ();
			}
		}

		public void RenderUI ()
		{
			//Tile type readout
			if (Player != null)
				Util.Console.Print (0, 3, Map.GetCell (Player.GetComponent<LocationComponent> ().Location).Tile.GetComponent<NameComponent> ().Name, RLColor.Cyan);
		}

		public void Render ()
		{
			Map.Render ();
			foreach (GameObject actor in Objects) {
				if (Map.GetCell (actor.GetComponent<LocationComponent> ().Location).Vision != Cell.VisionState.Visible)
					continue;

				if (actor.HasComponent<RenderComponent> ()) {
					actor.GetComponent<RenderComponent> ().Render ();
				}
			}
		}
	}
}
