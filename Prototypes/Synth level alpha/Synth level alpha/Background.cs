using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Synth_level_alpha
{
    public class Background
    {
        public Texture2D texture;
        public Texture2D[] parallax; //Furthest away at the start of the array.
        public Vector2 Position = new Vector2(0,0);
        public Background(Texture2D texture, Texture2D[] parallax)
        {
            this.texture = texture;
            this.parallax = new Texture2D[parallax.Length];
            parallax.CopyTo(this.parallax, 0);
            
        }
        public virtual void Update()
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
            for(int i=0;i<parallax.Length;i++)
            {
                spriteBatch.Draw(parallax[i], Position + Globals.offset/(parallax.Length-i), Color.White);
            }
        }
    }
}

