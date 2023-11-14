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
    public class Enemy : Unit
    {
        public Texture2D punctuation = Globals.content.Load<Texture2D>("Assets\\GUI\\punctuation"); //0=question, 1=exclamation
        public Rectangle DimensionRect;
        public Enemy(string PATH, Vector2 Position, Vector2 Dimensions) : base(PATH, Position, Dimensions) 
        {
            DimensionRect = new Rectangle(0, 0, punctuation.Width - 10, punctuation.Height);
        }
        public override void Update(Vector2 OFFSET)
        {
            base.Update(OFFSET);
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
            Globals.spriteBatch.Draw(punctuation, new Vector2(Position.X + OFFSET.X,Position.Y-Dimensions.Y/2-40+OFFSET.Y), DimensionRect,Color.White);
            Globals.spriteBatch.DrawString(Globals.gameFont, (Position.X-Globals.screenWidth/2).ToString(), new(0, 100), Color.White);
        }
    }
}
