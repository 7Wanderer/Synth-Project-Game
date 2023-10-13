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
    public class Unit : Basic2D
    {
        public Vector2 minPos, maxPos;
        public Unit(string PATH, Vector2 Position, Vector2 Dimensions) : base(PATH, Position, Dimensions)
        {

        }

        public void SetBounds(Point mapSize,Point tileSize)
        {
            minPos = new((-tileSize.X / 2) + origin.X, (-tileSize.Y / 2) + origin.Y);
            maxPos = new(mapSize.X - (tileSize.X / 2) - origin.X, mapSize.Y - (tileSize.Y / 2) - origin.Y);
        }

        public override void Update()
        {
            Position = Vector2.Clamp(Position, minPos, maxPos);
            base.Update();
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
