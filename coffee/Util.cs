using System;

namespace coffee
{
	public static class Util
	{
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

