#region
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
    public class Basic2D
    {
        public Vector2 Position, Dimensions, origin;

        public Texture2D Texture;

        public SpriteEffects spriteEffects = SpriteEffects.None;

        public float scale = 1f;
        public int newDimX;

        public Basic2D(string PATH, Vector2 Position, Vector2 Dimensions)
        {
            this.Position = Position;
            this.Dimensions = Dimensions;

            Texture = Globals.content.Load<Texture2D>(PATH);
            origin = new(Dimensions.X/2, Dimensions.Y/2);
        }

        public bool checkIfFlipped()
        {
            return spriteEffects == SpriteEffects.FlipHorizontally;
        }
        public virtual void Update(Vector2 OFFSET)
        {
            if (checkIfFlipped()) origin = new((Dimensions.X + 2*newDimX) / 2, Dimensions.Y / 2);
            else origin = new(Dimensions.X / 2, Dimensions.Y / 2);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if(Texture != null)
            {
                Globals.spriteBatch.Draw(Texture,
                    new Vector2(Position.X+OFFSET.X,Position.Y+OFFSET.Y), new Rectangle(newDimX,0,(int)Dimensions.X+newDimX,(int)Dimensions.Y),
                    Color.White, 0f, origin, scale, spriteEffects,0f);
            }
        }
    }
}
