using System;
using RLNET;

namespace coffee
{
	public class RenderComponent : Component
	{
		public bool Enabled { get; set; }

		private bool fullBright = true;

		public RenderComponent (GameObject parent) : base (parent)
		{
			Enabled = true;
		}

		public void Render ()
		{
			Cell.VisionState visibility = Parent.GetComponent<LocationComponent> ().Visibility;

			//TODO: Remember to remove this
			//Debugging, set to full-bright
			if (fullBright)
				visibility = Cell.VisionState.Visible;

			if (!Enabled || visibility == Cell.VisionState.Hidden)
				return;

			Vector2 location = Parent.GetComponent<LocationComponent> ().Location;

			switch (visibility) {
			case Cell.VisionState.Seen:
				Util.Console.Set (Util.mapOrigin.X + location.X, Util.mapOrigin.Y + location.Y, Parent.GetComponent<GlyphComponent> ().DimCell);
				break;
			case Cell.VisionState.Visible:
				Util.Console.Set (Util.mapOrigin.X + location.X, Util.mapOrigin.Y + location.Y, Parent.GetComponent<GlyphComponent> ().Cell);
				break;
			default:
				throw new ArgumentOutOfRangeException ("Bad vision state encountered");
			}
		}
	}
}

