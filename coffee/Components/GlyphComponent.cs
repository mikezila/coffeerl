using System;
using RLNET;

namespace coffee
{
	public class GlyphComponent : Component
	{
		public char Glyph { get; private set; }

		public RLColor BackGroundColor { get; private set; }

		public RLColor Color { get; private set; }

		public GlyphComponent (Actor parent, char glyph, RLColor color, RLColor backGroundColor) : base (parent)
		{
			Glyph = glyph;
			Color = color;
			BackGroundColor = backGroundColor;
		}
	}
}
