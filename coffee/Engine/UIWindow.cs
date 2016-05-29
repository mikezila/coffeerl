using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee
{
    class UIWindow
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public bool Enabled { get; private set; }
        public string Header { get; private set; }
        public Vector2 Location { get; private set; }

        public UIWindow(int height, int width, string header = "")
        {
            Height = height;
            Width = width;
            Header = header;
        }

        public void Enable(Vector2 location)
        {
            if (Enabled)
                throw new Exception("Tried to enable a window that was already enabled.");

            Enabled = true;
            Location = location;
        }

        public void Disable()
        {
            Location = null;
            Enabled = false;
        }

        public void Draw()
        {
            if (!Enabled)
                return;
        }
    }
}
