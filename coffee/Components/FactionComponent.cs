using System;

namespace coffee
{
	public enum Faction
	{
		Player,
		Monster
	}

	public class FactionComponent : Component
	{
		public Faction CurrentFaction { get; private set; }

		public FactionComponent (GameObject parent, Faction faction) : base (parent)
		{
			CurrentFaction = faction;
		}
	}
}

