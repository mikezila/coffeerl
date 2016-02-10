using System;
using RLNET;

namespace coffee
{
	public class RenderComponent : Component
	{
		public RenderComponent (Actor parent) : base (parent)
		{
		}

		public void Render (Vector2 mapOrigin)
		{
			Vector2 location = Parent.GetComponent<LocationComponent> ().Location;
			RLColor color = Parent.GetComponent<GlyphComponent> ().Color;
			RLColor backgroundColor = Parent.GetComponent<GlyphComponent> ().BackGroundColor;
			char glyph = Parent.GetComponent<GlyphComponent> ().Glyph;

			Util.Console.Set (mapOrigin.X + location.X, mapOrigin.Y + location.Y, color, backgroundColor, glyph);
		}
	}
}

