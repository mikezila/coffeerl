using System;
using RLNET;

namespace coffee
{
	public class KeyboardInputComponent : Component
	{
		public KeyboardInputComponent (GameObject parent) : base (parent)
		{
		}

		public void Input (RLNET.RLKeyPress keypress)
		{
			switch (keypress.Key) {
			case RLKey.W:
				Parent.GetComponent<MovementComponent> ().Move (Direction.North);
				break;
			case RLKey.S:
				Parent.GetComponent<MovementComponent> ().Move (Direction.South);
				break;
			case RLKey.A:
				Parent.GetComponent<MovementComponent> ().Move (Direction.West);
				break;
			case RLKey.D:
				Parent.GetComponent<MovementComponent> ().Move (Direction.East);
				break;
			}
		}
	}
}

