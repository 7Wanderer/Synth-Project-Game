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
        public Vector2 offset = new(0,0);

        public Player player;
        public List<Projectile2D> projectiles = new();
        public Floor floor;

        public World()
        {
            player = new Player("Assets\\Sprites\\testSprite", new Vector2(300, 300), new Vector2(640, 1080));
            floor = new();
            player.SetBounds(floor.mapSize, floor.tileSize);
            GameGlobals.PassProjectile = AddProjectile;
        }

        public virtual void Update()
        {
            player.Update();

            foreach(Projectile2D projectile in projectiles) 
            { 
                projectile.Update(offset, null);
            }
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2D)INFO);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            floor.Draw(OFFSET);
            foreach (Projectile2D projectile in projectiles)
            {
                projectile.Draw(offset);
            }
            player.Draw(OFFSET);
        }
    }
}
