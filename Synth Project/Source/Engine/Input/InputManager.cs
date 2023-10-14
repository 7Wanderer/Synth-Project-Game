using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Synth_Project.Source.Engine.Input
{
    public class InputManager
    {
        public BaseKeyboard keyboard = new();
        public InputManager() { }

        public bool Left()
        {
            if (keyboard.GetPress("A")
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X <= -0.5

                ) return true;
            return false;
        }
        public bool Right() 
        {
            if (keyboard.GetPress("D")
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X >= 0.5



                ) return true;
            return false;
        }
        public bool Up() 
        {
            if (keyboard.GetPress("W")
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y >= 0.5



                ) return true;
            return false;
        }
        public bool Down()
        {
            if (keyboard.GetPress("S")
                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y <= -0.5



                ) return true;
            return false;
        }
        public bool Blink()
        {
            if (keyboard.GetPress("Q")
                || GamePad.GetState(PlayerIndex.One).Triggers.Left >= 0.5


                ) return true;
            return false;
        }
        public bool Attack()
        {
            if (keyboard.GetPress("E")
                || GamePad.GetState(PlayerIndex.One).Triggers.Right >= 0.5



                ) return true;
            return false;
        }
    }
}
