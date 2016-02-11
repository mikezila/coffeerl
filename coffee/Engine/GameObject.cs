using System;
using System.Linq;
using System.Collections.Generic;

namespace coffee
{
	public sealed class GameObject
	{
		public List<Component> Components { get; private set; }

		public GameObject ()
		{
			Components = new List<Component> ();
		}

		public T GetComponent<T> ()
		{
			return Components.OfType<T> ().First ();
		}

		public void AddComponent<T> (Component component)
		{
			if (Components.OfType<T> ().Count () > 0)
				throw new ArgumentException ("Trying to add duplicate component");
			else
				Components.Add (component);
		}

		public bool HasComponent<T> ()
		{
			return Components.OfType<T> ().Count () > 0;
		}

		public void Update ()
		{
			foreach (Component component in Components)
				component.Update ();
		}
	}
}

