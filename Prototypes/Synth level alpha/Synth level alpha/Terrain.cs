using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synth_level_alpha
{
    public class Terrain
    {
        public Texture2D texture;
        public Vector2 Position = new Vector2(0,0);
        public Terrain(Texture2D texture)
        {
            this.texture = texture;
        }
        public virtual void Update()
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position + Globals.offset, Color.White);
        }
    }
}
