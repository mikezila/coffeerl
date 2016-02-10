using System;
using RLNET;

namespace coffee
{
	public class Message
	{
		public enum MessageType : int
		{
			Generic = 0,
			Buff,
			Debuff,
			GoodEvent,
			BadEvent,
			MyteriousEvent
		}

		public RLColor TypeIconColor {
			get {
				switch (Type) {
				case MessageType.Generic:
					return RLColor.LightGray;
				case MessageType.MyteriousEvent:
					return RLColor.LightBlue;
				case MessageType.GoodEvent:
				case MessageType.Buff:
					return RLColor.Green;
				case MessageType.Debuff:
				case MessageType.BadEvent:
					return RLColor.Red;
				default:
					throw new ArgumentException ("Bad icon color.");				
				}
			}
		}

		private const string iconBracket = "[]";
		private const int iconBracketPoint = 1;

		public string TypeIcon {
			get {
				switch (Type) {
				case MessageType.Generic:
					return iconBracket.Insert (iconBracketPoint, '-'.ToString ());
				case MessageType.Buff:
					return iconBracket.Insert (iconBracketPoint, ((char)30).ToString ());
				case MessageType.Debuff:
					return iconBracket.Insert (iconBracketPoint, ((char)31).ToString ());
				case MessageType.GoodEvent:
				case MessageType.BadEvent:
					return iconBracket.Insert (iconBracketPoint, '!'.ToString ());
				case MessageType.MyteriousEvent:
					return iconBracket.Insert (iconBracketPoint, '?'.ToString ());
				default:
					throw new ArgumentException ("Bad message type.");
				}
			}
		}

		public string MessageString { get; private set; }

		public MessageType Type { get; private set; }

		public Message (string message, MessageType type)
		{
			MessageString = message;
			Type = type;
		}
	}
}

