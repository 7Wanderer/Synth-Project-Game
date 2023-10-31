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

    public enum AnimationState
    {
        Moving,
        MovingYOnly,
        Idle,
        Blink,
        Attack
    }
    public class Player : Unit
    {
        public float speed = 5f;
        float timeBetweenTextures = 100;
        float timeLeft = 0;
        public Player(string PATH, Vector2 Position, Vector2 Dimensions) : base(PATH, Position, Dimensions)
        {
           newDimX = 0;
        }

        void isMoving()
        {
            timeLeft += (float)Globals.gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timeLeft >= timeBetweenTextures)
            {
                timeLeft = 0;
                if (newDimX == Texture.Width - Dimensions.X)
                {
                    newDimX = 0;
                }
                else
                {
                    newDimX += (int)Dimensions.X;
                }
            }
        }
        public override void Update(ref Vector2 OFFSET)
        {

            bool checkScroll = false;
            if (Globals.inputManager.Up()) 
            { 
                Position.Y -= speed * 0.8f;
                checkScroll = true;
                isMoving();
            }
            if (Globals.inputManager.Down())
            { 
                Position.Y += speed * 0.8f;
                checkScroll = true;
                isMoving();
            }
            if (Globals.inputManager.Left()) 
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
                Position.X -= speed;
                checkScroll = true;
                isMoving();
            }
            if (Globals.inputManager.Right()) 
            {
                spriteEffects = SpriteEffects.None;
                Position.X += speed;
                checkScroll = true;
                isMoving();
            }
            if(Globals.inputManager.Blink())
            {
                if (spriteEffects == SpriteEffects.None)
                {
                    Position.X += speed * 30;
                    OFFSET.X -= speed * 30;
                }
                else
                {
                    Position.X -= speed * 30;
                    OFFSET.X += speed * 30;
                }
                checkScroll = true;
            }
            if(checkScroll)
            {
                GameGlobals.CheckScroll(Position);
            }
            base.Update(ref OFFSET);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
