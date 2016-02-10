using System;
using System.Linq;
using System.Collections.Generic;

namespace coffee
{
	public class Actor
	{
		public List<Component> Components { get; private set; }

		public Actor ()
		{

		}

		public T GetComponent<T> ()
		{
			return Components.OfType<T> ().First ();
		}

		public void Update ()
		{
			foreach (Component component in Components)
				component.Update ();
		}
	}
}

