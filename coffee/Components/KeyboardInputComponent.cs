using System;

namespace coffee
{
	public class KeyboardInputComponent : Component
	{
		public KeyboardInputComponent (GameObject parent) : base (parent)
		{
		}

		public void Input (RLNET.RLKeyPress keypress)
		{
			if (keypress.Key == RLNET.RLKey.Q)
				Util.Messages.RandomQuote ();

			if (keypress.Key == RLNET.RLKey.W)
				Parent.GetComponent<MovementComponent> ().Move (Direction.North);
		}
	}
}

