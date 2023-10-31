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

        public Enemy(string PATH, Vector2 Position, Vector2 Dimensions) : base(PATH, Position, Dimensions) 
        {

        }
        public override void Update(ref Vector2 OFFSET)
        {
            base.Update(ref OFFSET);
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
