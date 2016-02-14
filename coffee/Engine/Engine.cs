using System;
using RLNET;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace coffee
{
	public class Engine
	{
		private GameManager manager;

		public Engine (RLRootConsole console)
		{
			Util.Console = console;
			Util.Messages = new MessageSystem ();
			manager = new GameManager ();
			Util.Console.Update += gameUpdate;
			Util.Console.Render += gameRender;
		}

		void renderUI ()
		{
			Util.Messages.RenderMessageScrollback ();
			manager.RenderUI ();
		}

		void renderGame ()
		{
			//An ugly-but-it-works way to stop the game rendering a shitload of frames
			//Improves window-drag responsiveness on Linux a lot, as well.
			System.Threading.Thread.Sleep (60);
			manager.Render ();

		}

		void gameUpdate (object sender, UpdateEventArgs e)
		{
			// Poll for a keypress
			RLKeyPress keypress = Util.Console.Keyboard.GetKeyPress ();

			// Before anything else, check if we should just quit.
			if (keypress != null && keypress.Key == RLKey.Escape)
				Util.Console.Close ();

			if (keypress != null && keypress.Key == RLKey.M)
				manager.ReGenMap ();

			// Send the keypress into the GameManger's update cycle
			manager.Update (keypress);
		}

		void gameRender (object sender, UpdateEventArgs e)
		{
			Util.Console.Clear ();
			renderUI ();
			renderGame ();
			Util.Console.Draw ();
		}
	}
}

