using System;
using RLNET;
using System.Collections.Generic;

namespace coffee
{
	public class MessageSystem
	{
		private RLRootConsole game;
		private List<Message> messages;

		public MessageSystem ()
		{
			game = Util.Console;
			messages = new List<Message> ();

			AddMessage ("coffeeRL v0.2 - \"Uppercut\"");
			AddMessage ("Entering floor 1...");
			AddMessage ("Prepare yourself!");
		}

		Random rand = new Random ();

		public void RandomQuote ()
		{
			Message[] quotes = new Message[6];
			quotes [0] = new Message ("The way forward becomes clear.", Message.MessageType.MyteriousEvent);
			quotes [1] = new Message ("The weight of the world seems lighter.", Message.MessageType.Buff);
			quotes [2] = new Message ("Death's advocate approaches...", Message.MessageType.BadEvent);
			quotes [3] = new Message ("The darkness here is tangible and unatural...", Message.MessageType.Debuff);
			quotes [4] = new Message ("Your experience teaches you well.", Message.MessageType.Buff);
			quotes [5] = new Message ("A marvelous gem...", Message.MessageType.GoodEvent);

			messages.Add (quotes [rand.Next (6)]);
		}

		public void AddMessage (string message)
		{
			messages.Add (new Message (message, Message.MessageType.Generic));
		}

		public void AddMessage (string message, Message.MessageType type)
		{
			messages.Add (new Message (message, type));
		}

		//Kind of a hack; dirty.  I'd like it to be variable without so much hardcoding.
		//TODO: Redo this.
		public void RenderMessageScrollback ()
		{
			// Render the message scrollback
			int line = 0;
			//Oldest
			game.Print (0, line, messages [messages.Count - 3].TypeIcon, RLColor.Gray);
			game.SetColor (1, line, messages [messages.Count - 3].TypeIconColor);
			game.Print (3, line++, messages [messages.Count - 3].MessageString, RLColor.Gray);

			//Old
			game.Print (0, line, messages [messages.Count - 2].TypeIcon, RLColor.LightGray);
			game.SetColor (1, line, messages [messages.Count - 2].TypeIconColor);
			game.Print (3, line++, messages [messages.Count - 2].MessageString, RLColor.LightGray);

			//New
			game.Print (0, line, messages [messages.Count - 1].TypeIcon, RLColor.White);
			game.SetColor (1, line, messages [messages.Count - 1].TypeIconColor);
			game.Print (3, line++, messages [messages.Count - 1].MessageString, RLColor.White);
		}
	}
}
