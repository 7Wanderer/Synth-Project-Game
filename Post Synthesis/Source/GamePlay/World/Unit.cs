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
using SharpDX.MediaFoundation;
#endregion

namespace Post_Synthesis
{
    public class Unit : Basic2D
    {
        public Vector2 minPos, maxPos;
        public Unit(string PATH, Vector2 Position, Vector2 Dimensions) : base(PATH, Position, Dimensions)
        {

        }

        public void SetBounds(Point mapSize,Point tileSize, Vector2 Position)
        {
            minPos = new((-tileSize.X / 2) + origin.X + Position.X, (-tileSize.Y / 2) + Position.Y);
            maxPos = new(mapSize.X + (tileSize.X / 2) - Dimensions.X +Position.X, mapSize.Y - (tileSize.Y / 2) - origin.Y + Position.Y);
        } // This method is a whore. If the floor breaks, its this fuckers fault.

        public override void Update(Vector2 OFFSET)
        {
            Position = Vector2.Clamp(Position, minPos, maxPos);
            base.Update(OFFSET);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
