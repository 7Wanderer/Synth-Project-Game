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
    public struct Sprite
    {
        public Texture2D texture;
        public Vector2 Position;
        public Color Colour = Color.White;
        public SpriteEffects spriteEffects = SpriteEffects.None;
        public Vector2 Origin
        {
            get
            {
                return new Vector2(texture.Width/2, texture.Height/2);
            }
        }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X + (int)Globals.offset.X, (int)Position.Y + (int)Globals.offset.Y, texture.Width, texture.Height);
            }
        }

        public Sprite(Texture2D texture, Vector2 Position) 
        {
            this.texture = texture;
            this.Position = Position;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, null, Colour, 0, Origin, spriteEffects, 0);
        }

        public bool IsTouching(Player player)
        {
            if(spriteEffects == SpriteEffects.None)
                return Math.Abs(Rectangle.Y - player.sprite.Position.Y) < (texture.Height*0.3) 
                    && Math.Abs(player.sprite.Position.X + texture.Width * 0.35 - Rectangle.X) < texture.Width * 0.4
                    && spriteEffects == player.sprite.spriteEffects;
            else
                return Math.Abs(Rectangle.Y - player.sprite.Position.Y) < (texture.Height * 0.3) 
                    && Math.Abs(Rectangle.X + texture.Width * 0.35 - player.sprite.Position.X) < texture.Width * 0.4
                    && spriteEffects == player.sprite.spriteEffects;
        }
    }
}
