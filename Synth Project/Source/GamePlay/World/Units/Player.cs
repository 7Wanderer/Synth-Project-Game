#region
using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Synth_Project.Source.Engine;
#endregion

namespace Synth_Project
{
    public class Player : Unit
    {
        public float speed = 5f;
        public Player(string PATH, Vector2 Position, Vector2 Dimensions) : base(PATH, Position, Dimensions)
        {

        }

        public override void Update()
        {
            if (Globals.keyboard.GetPress("W")) Position.Y -= speed * 0.8f;
            if (Globals.keyboard.GetPress("S")) Position.Y += speed * 0.8f;
            if (Globals.keyboard.GetPress("A")) 
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
                Position.X -= speed;
            }
            if (Globals.keyboard.GetPress("D")) 
            {
                spriteEffects = SpriteEffects.None;
                Position.X += speed; 
            }

            base.Update();
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
