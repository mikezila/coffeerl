﻿using System;

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

		public static Vector2 One{ get { return new Vector2 (1, 1); } }

		public static Vector2 operator + (Vector2 a, Vector2 b)
		{
			return new Vector2 (a.X + b.X, a.Y + b.Y);
		}

		public static Vector2 operator - (Vector2 a, Vector2 b)
		{
			return new Vector2 (a.X - b.X, a.Y - b.Y);
		}

		public static Vector2 operator + (Vector2 a, int b)
		{
			return new Vector2 (a.X + b, a.Y + b);
		}

		public static Vector2 operator - (Vector2 a, int b)
		{
			return new Vector2 (a.X - b, a.Y - b);
		}

		public static bool IsInside (Vector2 point, Vector2 bound)
		{
			return ((point.X >= 0) && (point.X < bound.X)) && ((point.Y >= 0) && (point.Y < bound.Y));
		}

		public override string ToString ()
		{
			return string.Format ("[Vector2: X={0}, Y={1}, Size={2}]", X, Y, Size);
		}

		public Vector2 (int x, int y)
		{
			X = x;
			Y = y;
		}
	}

	public static class Util
	{
		// Handy semi-consts
		public static readonly Vector2 mapOrigin = new Vector2 (1, 5);

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

		public static bool Same (this Vector2 s, Vector2 other)
		{
			return ((s.X == other.X) && (s.Y == other.Y));
		}

		public static Vector2 Abs (this Vector2 s)
		{
			return new Vector2 (Math.Abs (s.X), Math.Abs (s.Y));
		}

		//Function to get random number
		//http://stackoverflow.com/questions/767999/random-number-generator-only-generating-one-random-number/768001#768001
		private static readonly Random random = new Random (DateTime.Now.Millisecond);
		private static readonly object syncLock = new object ();

		public static int RandomNumber (int min, int max)
		{
			lock (syncLock) { // synchronize
				return random.Next (min, max);
			}
		}
	}
}

