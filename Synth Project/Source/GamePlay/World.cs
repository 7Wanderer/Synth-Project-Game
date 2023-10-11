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

namespace Synth_Project.Source.GamePlay
{
    public class World
    {
        public Player player;

        public World()
        {
            player = new Player("Assets\\Sprites\\testSprite", new Vector2(300, 300), new Vector2(640, 1080));
        }

        public virtual void Update()
        {
            player.Update();
        }

        public virtual void Draw()
        {
            player.Draw();
        }
    }
}
