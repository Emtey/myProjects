using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.DirectX.DirectInput;

namespace MoonShooter
{
    public class FrameRate : Text2D
    {
        public FrameRate(Font font)
            : base(font)
        {
            Position = new Point(570, 0);
            Color = Color.DarkCyan;
        }

        public override void Update()
        {
            Text = "FPS: " + Game.CurrentFrameRate.ToString();
            if (Keyboard.IsTriggered(Key.F9))
                Visible = !Visible;

        }
    }
}
