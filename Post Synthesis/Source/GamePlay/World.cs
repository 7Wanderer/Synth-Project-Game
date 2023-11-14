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
using System.Reflection.Metadata;
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
            testEnemy.SetBounds(floor.mapSize, floor.tileSize, floor.position);
            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.CheckScroll = CheckScroll; 
            Globals.scriptManager = new(new TestScript1(), new List<Actor>()
            {
                new Actor(Globals.content.Load<Texture2D>("Assets\\Portraits\\syn alpha"),null,"Syn"),
                new Actor(Globals.content.Load<Texture2D>("Assets\\Portraits\\flint alpha"),null,"Flint"),
                new Actor(Globals.content.Load<Texture2D>("Assets\\Portraits\\sasha alpha"),null,"Sasha")
            });
        }
        int roundToTen(float number)
        {
            return ((int)(number / 10)) * 10;
        }
        public virtual void Update()
        {
            player.Update(offset);
            if (testEnemy != null)
            {
                testEnemy.Update(offset);
                if (Math.Abs(player.Position.X - testEnemy.Position.X + 20) < 30 && Math.Abs(player.Position.Y - testEnemy.Position.Y) < 30)
                {
                    testEnemy.DimensionRect = new(0, 0, testEnemy.punctuation.Width - 15, testEnemy.punctuation.Height);
                    if (Globals.inputManager.Attack())
                    {
                        testEnemy = null;
                        Globals.scriptManager.inactive = false;
                    }
                }
                else testEnemy.DimensionRect = new(20, 0, testEnemy.punctuation.Width, testEnemy.punctuation.Height);
            }
            foreach (Projectile2D projectile in projectiles) 
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
                offset.X += player.speed;
            else if (offset.X > -tempPos.X + Globals.screenWidth *.6f
                    && offset.X > -floor.mapSize.X+ Globals.screenWidth)
                offset.X -= player.speed;
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
            if(testEnemy != null) testEnemy.Draw(offset);
            Globals.spriteBatch.DrawString(Globals.gameFont, offset.ToString(), new(), Color.White);
        }
    }
}
