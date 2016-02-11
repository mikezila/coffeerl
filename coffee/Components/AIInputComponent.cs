using System;

namespace coffee
{
	public class AIInputComponent : Component
	{
		public bool Awake { get; private set; }

		public AIInputComponent (GameObject parent) : base (parent)
		{
			Awake = true;
		}

		public void Sleep ()
		{
			Awake = false;
		}

		public void Wake ()
		{
			Awake = true;
		}

		public override void Update ()
		{
			if (!Awake)
				return;

			Wander ();
		}

		public void Wander ()
		{
			MovementComponent Mover = Parent.GetComponent<MovementComponent> ();

			switch (Util.RandomNumber (0, 4)) {
			case 0:
				Mover.Move (Direction.North);
				break;
			case 1:
				Mover.Move (Direction.South);
				break;
			case 2:
				Mover.Move (Direction.East);
				break;
			case 3:
				Mover.Move (Direction.West);
				break;
			default:
				throw new Exception ("Picking a random direction has gone terribly wrong.");
			}
		}
	}
}


