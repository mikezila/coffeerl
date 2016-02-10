using System;

namespace coffee
{
	public enum Direction
	{
		None,
		North,
		South,
		East,
		West
	}

	public class Vector2
	{
		public int X { get; set; }

		public int Y{ get; set; }

		public int Size{ get { return X * Y; } }

		public static Vector2 North{ get { return new Vector2 (0, -1); } }

		public static Vector2 South{ get { return new Vector2 (0, 1); } }

		public static Vector2 East{ get { return new Vector2 (1, 0); } }

		public static Vector2 West{ get { return new Vector2 (-1, 0); } }

		public static Vector2 Zero{ get { return new Vector2 (0, 0); } }

		public static Vector2 operator + (Vector2 a, Vector2 b)
		{
			return new Vector2 (a.X + b.X, a.Y + b.Y);
		}

		public Vector2 (int width, int height)
		{
			X = width;
			Y = height;
		}
	}

	public static class Util
	{
		private static RLNET.RLRootConsole _console;
		private static MessageSystem _messages;

		public static RLNET.RLRootConsole Console {
			get {
				return _console;
			}
			set {
				_console = value;
			}
		}

		public static MessageSystem Messages {
			get {
				return _messages;
			}
			set {
				_messages = value;
			}
		}

		public static string RandomName ()
		{
			string[] firstNames = new string[10];
			string[] lastNames = new string[10];

			firstNames [0] = "Malacai";
			firstNames [1] = "Guy";
			firstNames [2] = "Albert";
			firstNames [3] = "Gregor";
			firstNames [4] = "J";
			firstNames [5] = "Alex";
			firstNames [6] = "Zoe";
			firstNames [7] = "Nastasha";
			firstNames [8] = "Meryl";
			firstNames [9] = "M";

			lastNames [0] = "Cross";
			lastNames [1] = "Lambert";
			lastNames [2] = "Lawson";
			lastNames [3] = "King";
			lastNames [4] = "Porter";
			lastNames [5] = "Blade";
			lastNames [6] = "Guiver";
			lastNames [7] = "Slamm";
			lastNames [8] = "Xi";
			lastNames [9] = "Sly";

			return firstNames [Util.RandomNumber (1, 10)] + " " + lastNames [Util.RandomNumber (1, 10)];
		}

		//Function to get random number
		//http://stackoverflow.com/questions/767999/random-number-generator-only-generating-one-random-number/768001#768001
		private static readonly Random random = new Random ();
		private static readonly object syncLock = new object ();

		public static int RandomNumber (int min, int max)
		{
			lock (syncLock) { // synchronize
				return random.Next (min, max);
			}
		}
	}
}

