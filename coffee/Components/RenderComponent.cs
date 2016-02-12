using System;
using RLNET;

namespace coffee
{
	public class RenderComponent : Component
	{
		public bool Enabled { get; set; }

		public RenderComponent (GameObject parent) : base (parent)
		{
			Enabled = true;
		}

		public void Render ()
		{
			Cell.VisionState visibility = Parent.GetComponent<LocationComponent> ().Visibility;
			if (!Enabled || visibility == Cell.VisionState.Hidden)
				return;

			Vector2 location = Parent.GetComponent<LocationComponent> ().Location;

			switch (visibility) {
			case Cell.VisionState.Seen:
				Util.Console.Set (Util.mapOrigin.X + location.X, Util.mapOrigin.Y + location.Y, Parent.GetComponent<GlyphComponent> ().Cell);
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

