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
			case RLKey.Z:
				Parent.GetComponent<VisionComponent> ().Range = 2;
				Util.Messages.AddMessage ("The darkness closes in on you.", Message.MessageType.Debuff);
				break;
			case RLKey.X:
				Parent.GetComponent<VisionComponent> ().Range = 4;
				Util.Messages.AddMessage ("Your vision clears.", Message.MessageType.Buff);
				break;
			case RLKey.C:
				Parent.GetComponent<VisionComponent> ().Range = 8;
				Util.Messages.AddMessage ("The way forward becomes clear.", Message.MessageType.Buff);
				break;
			}
		}
	}
}

