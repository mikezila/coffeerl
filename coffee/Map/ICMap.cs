using System;

namespace coffee
{
	public interface ICMap
	{
		char[] Tiles{ get; }

		string Name{ get; }

		Vector2 MapSize { get; }

		Vector2 PlayerStart{ get; }
	}
}

