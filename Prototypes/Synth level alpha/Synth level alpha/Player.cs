using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synth_level_alpha
{

    public class Player
    {
        public Sprite sprite;
        public bool once = false;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)sprite.Position.X, (int)sprite.Position.Y, sprite.texture.Width, sprite.texture.Height);
            }
        }
        public Player(Texture2D texture, Vector2 Position)
        {
            sprite = new Sprite(texture, Position);
        }
        
        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.W) && !once)
            {
                sprite.Position.Y -= 5;
            }
            if (keyboardState.IsKeyDown(Keys.S) && !once)
            {
                sprite.Position.Y += 5;
            }
            if (keyboardState.IsKeyDown(Keys.A) && !once)
            {
                if(!Globals.isScrolling)
                    sprite.Position.X -= 5;
                else
                    Globals.offset.X += 5;
                sprite.spriteEffects = SpriteEffects.FlipHorizontally;
            }
            if (keyboardState.IsKeyDown(Keys.D) && !once)
            {
                if (!Globals.isScrolling)
                    sprite.Position.X += 5;
                else
                    Globals.offset.X -= 5;
                sprite.spriteEffects = SpriteEffects.None;
            }
            if (keyboardState.IsKeyDown(Keys.LeftShift) && !once)
            {
                once = true;
                if (sprite.spriteEffects == SpriteEffects.None)
                {
                    if(Globals.isScrolling)
                    {
                        Globals.offset.X -= 200;
                    }
                    else sprite.Position.X += 200;
                    sprite.spriteEffects = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    if (Globals.isScrolling)
                    {
                        Globals.offset.X += 200;
                    }
                    else sprite.Position.X -= 200;
                    sprite.spriteEffects = SpriteEffects.None;
                }
            }
            if (keyboardState.IsKeyUp(Keys.LeftShift))
            {
                once = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite.texture, Rectangle, null, sprite.Colour, 0, sprite.Origin, sprite.spriteEffects, 0);
        }
    }
}
