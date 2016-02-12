using System;

namespace coffee
{
	public class GameFlowComponent : Component
	{
		public bool StopFlow { get; private set; }

		public GameFlowComponent (GameObject parent) : base (parent)
		{
			StopFlow = true;
		}

		public void TurnComplete ()
		{
			StopFlow = false;
		}

		public void TurnBegins ()
		{
			StopFlow = true;
		}
	}
}

