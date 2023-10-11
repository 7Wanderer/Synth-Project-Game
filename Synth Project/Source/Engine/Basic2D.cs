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

namespace Synth_Project.Source.Engine
{
    public class Basic2D
    {
        public Vector2 Position, Dimensions;

        public Texture2D Texture;

        public SpriteEffects spriteEffects = SpriteEffects.None;

        public Basic2D(string PATH, Vector2 Position, Vector2 Dimensions)
        {
            this.Position = Position;
            this.Dimensions = Dimensions;

            Texture = Globals.content.Load<Texture2D>(PATH);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            if(Texture != null)
            {
                Globals.spriteBatch.Draw(Texture,
                    Position, new Rectangle(0,0,(int)Dimensions.X,(int)Dimensions.Y),
                    Color.White, 0f, new Vector2(Texture.Bounds.Width/2,Texture.Bounds.Height/2), 0.1f, spriteEffects,0f);
            }
        }
    }
}
