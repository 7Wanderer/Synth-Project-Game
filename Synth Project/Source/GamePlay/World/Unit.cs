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
        public Unit(string PATH, Vector2 Position, Vector2 Dimensions) : base(PATH, Position, Dimensions)
        {

        }

        public override void Update()
        {

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }

    }
}
