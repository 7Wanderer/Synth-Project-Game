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

        public World(Level level)
        {
            player = level.player;
            testEnemy = level.enemies[0];
            floor = level.floor;
            background = level.background;

            player.SetBounds(floor.mapSize, floor.tileSize, floor.position);
            testEnemy.SetBounds(floor.mapSize, floor.tileSize, floor.position);

            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.CheckScroll = CheckScroll; 
                        
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

        public virtual void Draw()
        {
            Vector2 OFFSET = offset + Globals.scriptManager.offset;
            background.Draw(OFFSET);
            floor.Draw(OFFSET);
            foreach (Projectile2D projectile in projectiles)
            {
                projectile.Draw(OFFSET);
            }
            player.Draw(OFFSET);
            if(testEnemy != null) testEnemy.Draw(OFFSET);
            Globals.spriteBatch.DrawString(Globals.gameFont, OFFSET.ToString(), new(), Color.White);
        }
    }
}
