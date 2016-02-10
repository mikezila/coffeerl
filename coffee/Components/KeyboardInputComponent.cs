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
			RLNET.RLKeyPress keypress = Util.Console.Keyboard.GetKeyPress ();
			if (keypress == null)
				return;
			if (keypress.Key == RLNET.RLKey.Q)
				Util.Messages.AddMessage ("HERP DERP");
		}
	}
}

