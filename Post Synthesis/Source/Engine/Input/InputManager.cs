﻿#region
using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace Post_Synthesis
{
    public class InputManager
    {
        public BaseKeyboard keyboard = new();
        bool blinkOnce = false, continueOnce = false;
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
            if (Keyboard.GetState().IsKeyUp(Keys.LeftShift)
                && GamePad.GetState(PlayerIndex.One).Triggers.Left < 0.5) blinkOnce = false;

            if ((Keyboard.GetState().IsKeyDown(Keys.LeftShift)
                || GamePad.GetState(PlayerIndex.One).Triggers.Left >= 0.5

                    ) && !blinkOnce
                ) 
            { 
                blinkOnce = true;
                return true;
            }
            return false;

        }
        public bool Attack()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space)
                || GamePad.GetState(PlayerIndex.One).Triggers.Right >= 0.5



                ) return true;
            return false;
        }
        public bool Continue()
        {
            if (Keyboard.GetState().IsKeyUp(Keys.Enter)
                && GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Released) continueOnce = false;

            if ((Keyboard.GetState().IsKeyDown(Keys.Enter)
                || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed

                    ) && !continueOnce

                ) 
            {
                continueOnce = true;
                return true;
            }
            return false;
        }
    }
}
