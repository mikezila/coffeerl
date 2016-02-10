using System;

namespace coffee
{
	public class KeyboardInputComponent : Component
	{
		public KeyboardInputComponent (Actor parent) : base (parent)
		{
		}

		public override void Update ()
		{

		}

		public void Input (RLNET.RLKeyPress keypress)
		{
			if (keypress.Key == RLNET.RLKey.Q)
				Util.Messages.AddMessage ("HERP DERP");
		}
	}
}

