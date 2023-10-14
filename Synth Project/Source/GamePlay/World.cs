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
            floor = new(Globals.screenHeight-400);
            player.SetBounds(floor.mapSize, floor.tileSize, floor.position);
            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.CheckScroll = CheckScroll;
        }

        public virtual void Update()
        {
            player.Update(offset);
            foreach(Projectile2D projectile in projectiles) 
            { 
                projectile.Update(offset, null);
            }
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2D)INFO);
        }
        public virtual void CheckScroll(object INFO)
        {
            Vector2 tempPos = (Vector2)INFO;
            if (tempPos.X < -offset.X + Globals.screenWidth *.4f
                && tempPos.X >= Globals.screenWidth/2)
            {
                offset = new(offset.X + player.speed,offset.Y);
            }
            if (tempPos.X > -offset.X + Globals.screenWidth * .6f
                && tempPos.X <= floor.mapSize.X-Globals.screenWidth / 2)
            {
                offset = new(offset.X - player.speed, offset.Y);
            }
        }
        public virtual void Draw(Vector2 OFFSET)
        {
            floor.Draw(offset);
            foreach (Projectile2D projectile in projectiles)
            {
                projectile.Draw(offset);
            }
            player.Draw(offset);
        }
    }
}
