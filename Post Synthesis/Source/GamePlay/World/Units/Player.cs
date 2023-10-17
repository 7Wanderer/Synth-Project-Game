#region
using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Post_Synthesis.Source;
#endregion

namespace Post_Synthesis
{
    public class Player : Unit
    {
        public float speed = 5f;
        public Player(string PATH, Vector2 Position, Vector2 Dimensions) : base(PATH, Position, Dimensions)
        {
            scale = 0.2f;
        }
        public override void Update(Vector2 OFFSET)
        {
            bool checkScroll = false;
            if (Globals.inputManager.Up()) 
            { 
                Position.Y -= speed * 0.8f;
                checkScroll = true;
            }
            if (Globals.inputManager.Down())
            { 
                Position.Y += speed * 0.8f;
                checkScroll = true;
            }
            if (Globals.inputManager.Left()) 
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
                Position.X -= speed;
                checkScroll = true;
            }
            if (Globals.inputManager.Right()) 
            {
                spriteEffects = SpriteEffects.None;
                Position.X += speed;
                checkScroll = true;
            }
            if(Globals.inputManager.Blink())
            {
                if(spriteEffects == SpriteEffects.None)
                {
                    Position.X += speed * 30;
                    checkScroll = true;
                }
                else
                {
                    Position.X -= speed * 30;
                    checkScroll = true;
                }
            }
            if(checkScroll)
            {
                GameGlobals.CheckScroll(Position);
            }
            base.Update(OFFSET);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
