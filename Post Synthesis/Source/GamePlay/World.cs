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
        public Enemy testEnemy;
        public List<Projectile2D> projectiles = new();
        public Floor floor;
        public Background background;

        public World()
        {
            player = new Player("Assets\\Sprites\\Syn\\walk cycle template", new Vector2(300, 500), new Vector2(128, 216));
            testEnemy = new Enemy("Assets\\Sprites\\test enemy s",new Vector2(1200,550),new Vector2(128,216));
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
            GameGlobals.CheckBlink = Blink;
        }
        int roundToTen(float number)
        {
            return ((int)(number / 10)) * 10;
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
            if (offset.X < -tempPos.X + Globals.screenWidth *.4f
                    && offset.X < 0)
                offset.X += player.speed * 2;
            else if (offset.X > -tempPos.X + Globals.screenWidth *.6f
                    && offset.X > -floor.mapSize.X+ Globals.screenWidth)
                offset.X -= player.speed * 2;
        }        

        public virtual void Blink(object INFO)
        {
            Vector2 tempPos = (Vector2)INFO;
            if(offset.X < -tempPos.X + Globals.screenWidth / 2
                    && offset.X < 0)
                offset.X += roundToTen(player.speed * 3);
            else if (offset.X > -tempPos.X + Globals.screenWidth / 2
                    && offset.X > -floor.mapSize.X+ Globals.screenWidth)
                offset.X -= roundToTen(player.speed * 3);
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
            testEnemy.Draw(offset);
            Globals.spriteBatch.DrawString(Globals.gameFont, offset.ToString(), new(), Color.White);
        }
    }
}
