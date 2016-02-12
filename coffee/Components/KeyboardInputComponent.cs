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
			GameFlowComponent turn = Parent.GetComponent<GameFlowComponent> ();

			switch (keypress.Key) {
			case RLKey.W:
				Parent.GetComponent<MovementComponent> ().Move (Direction.North);
				turn.TurnComplete ();
				break;
			case RLKey.S:
				Parent.GetComponent<MovementComponent> ().Move (Direction.South);
				turn.TurnComplete ();
				break;
			case RLKey.A:
				Parent.GetComponent<MovementComponent> ().Move (Direction.West);
				turn.TurnComplete ();
				break;
			case RLKey.D:
				Parent.GetComponent<MovementComponent> ().Move (Direction.East);
				turn.TurnComplete ();
				break;
			case RLKey.Z:
				Parent.GetComponent<VisionComponent> ().Range = 2;
				Util.Messages.AddMessage ("The darkness closes in on you.", Message.MessageType.Debuff);
				turn.TurnComplete ();
				break;
			case RLKey.X:
				Parent.GetComponent<VisionComponent> ().Range = 4;
				Util.Messages.AddMessage ("Your vision clears.", Message.MessageType.Buff);
				turn.TurnComplete ();
				break;
			case RLKey.C:
				Parent.GetComponent<VisionComponent> ().Range = 8;
				Util.Messages.AddMessage ("The way forward becomes clear.", Message.MessageType.Buff);
				turn.TurnComplete ();
				break;
			}
		}
	}
}

