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
            player = new Player("Assets\\Sprites\\Syn\\walk cycle template", new Vector2(300, 500), new Vector2(128, 216));
            // testEnemy = new Unit("Assets\\Sprites\\test enemy",new Vector2(700,500),new Vector2(128,216));
            floor = new(Globals.screenHeight-400);
            List<Texture2D> t = new()
            {
                Globals.content.Load<Texture2D>("Assets\\World\\Backgrounds\\Alpha Level\\far"),
                Globals.content.Load<Texture2D>("Assets\\World\\Backgrounds\\Alpha Level\\mid"),
                Globals.content.Load<Texture2D>("Assets\\World\\Backgrounds\\Alpha Level\\near")
            }; // Can't wait for the day I'm gonna have to actually make a shitload of these
            background = new("Assets\\World\\Backgrounds\\Alpha Level\\Background1", new(0, 0),new(1600,900),t);
            player.SetBounds(floor.mapSize, floor.tileSize, floor.position);
            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.CheckScroll = CheckScroll;
        }

        public virtual void Update()
        {
            player.Update(ref offset);
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
            if (tempPos.X - 160 < -offset.X + Globals.screenWidth *.4f
                && tempPos.X >= Globals.screenWidth/2)
            {
                offset = new(offset.X + player.speed, offset.Y);
            }
            if (tempPos.X + 160 > -offset.X + Globals.screenWidth * .6f
                && tempPos.X <= floor.mapSize.X-Globals.screenWidth / 2)
            {
                offset = new(offset.X - player.speed, offset.Y);
            }
        }
        // Current problem - minimum offset is stuck at -160 once entering change for the first time.
        public virtual void Draw(Vector2 OFFSET)
        {
            background.Draw(offset);
            floor.Draw(offset);
            foreach (Projectile2D projectile in projectiles)
            {
                projectile.Draw(offset);
            }
            player.Draw(offset);
            Globals.spriteBatch.DrawString(Globals.gameFont, offset.ToString(), new(), Color.White);
        }
    }
}
