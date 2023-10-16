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
using SharpDX.Direct2D1;
using System.Threading.Tasks;
#endregion

namespace Post_Synthesis
{
    public class Background : Basic2D
    {
        List<Texture2D> parallaxTextures;
        public Background(string PATH, Vector2 Position, Vector2 Dimensions, List<Texture2D> parallaxTextures) : base(PATH, Position, Dimensions)
        {
            this.parallaxTextures = parallaxTextures;
            this.origin = new(0, 0);
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(new());
            for (int i = 0; i < parallaxTextures.Count; i++)
            {
                Globals.spriteBatch.Draw(parallaxTextures[i], Position + OFFSET / (parallaxTextures.Count - i), Color.White);
            } 
        }
    }
}
