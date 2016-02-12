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
			if (!Enabled)
				return;

			Vector2 location = Parent.GetComponent<LocationComponent> ().Location;

			Util.Console.Set (Util.mapOrigin.X + location.X, Util.mapOrigin.Y + location.Y, Parent.GetComponent<GlyphComponent> ().Cell);
		}
	}
}

