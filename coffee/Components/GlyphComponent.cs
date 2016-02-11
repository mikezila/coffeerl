using System;
using RLNET;

namespace coffee
{
	public class GlyphComponent : Component
	{
		public RLCell Cell { get { return new RLCell (BackGroundColor, Color, GlyphChar); } }

		public char GlyphChar { get; private set; }

		public RLColor BackGroundColor { get; private set; }

		public RLColor Color { get; private set; }

		public GlyphComponent (GameObject parent, char glyph, RLColor color, RLColor backGroundColor) : base (parent)
		{
			GlyphChar = glyph;
			Color = color;
			BackGroundColor = backGroundColor;
		}
	}
}
