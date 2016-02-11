using System;

namespace coffee
{
	public class AIInputComponent : Component
	{
		public AIInputComponent (GameObject parent) : base (parent)
		{
		}

		public override void Update ()
		{
			Wander ();
		}

		int stepCount = 0;

		public void Wander ()
		{
			MovementComponent Mover = Parent.GetComponent<MovementComponent> ();
			bool moved = false;
			stepCount++;
			Util.Messages.AddMessage ("Stepped " + stepCount.ToString () + " times.");
			while (!moved) {
				switch (Util.RandomNumber (0, 4)) {
				case 0:
					moved = !Mover.Move (Direction.North);
					break;
				case 1:
					moved = !Mover.Move (Direction.South);
					break;
				case 2:
					moved = !Mover.Move (Direction.East);
					break;
				case 3:
					moved = !Mover.Move (Direction.West);
					break;
				default:
					throw new Exception ("Picking a random direction has gone terribly wrong.");
				}
			}
		}
	}
}

