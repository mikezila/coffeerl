using System;
using System.Collections.Generic;

namespace coffee
{
	public class InventoryComponent : Component
	{
		public List<Item> Inventory = new List<Item> ();

		public InventoryComponent (Actor parent) : base (parent)
		{

		}

		public void AddItem (Item newItem)
		{
			throw new NotImplementedException ();
		}
	}
}
