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
#endregion

namespace Post_Synthesis.Source
{
    public class World
    {
        public Vector2 offset = new(0,0);

        public Player player;
        public Unit testEnemy;
        public List<Projectile2D> projectiles = new();
        public Floor floor;
        public Background background;

        public World()
        {
            player = new Player("Assets\\Sprites\\Syn\\test sprite", new Vector2(300, 500), new Vector2(128, 216));
            testEnemy = new Unit("Assets\\Sprites\\test enemy",new Vector2(700,500),new Vector2(128,216));
            floor = new(Globals.screenHeight-400);
            List<Texture2D> t = new()
            {
                Globals.content.Load<Texture2D>("Assets\\World\\Backgrounds\\far"),
                Globals.content.Load<Texture2D>("Assets\\World\\Backgrounds\\mid"),
                Globals.content.Load<Texture2D>("Assets\\World\\Backgrounds\\near")
            };
            background = new("Assets\\World\\Backgrounds\\Background1", new(0, 0),new(1600,900),t);
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
                offset = new(offset.X + player.speed*2,offset.Y);
            }
            if (tempPos.X > -offset.X + Globals.screenWidth * .6f
                && tempPos.X <= floor.mapSize.X-Globals.screenWidth / 2)
            {
                offset = new(offset.X - player.speed*2, offset.Y);
            }
        }
        public virtual void Draw(Vector2 OFFSET)
        {
            background.Draw(offset);
            floor.Draw(offset);
            foreach (Projectile2D projectile in projectiles)
            {
                projectile.Draw(offset);
            }
            player.Draw(offset);
        }
    }
}
