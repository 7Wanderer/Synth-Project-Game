using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_novel_alpha
{
    public class Textbox
    {
        Texture2D texture;
        SpriteFont gameFont;
        Vector2 position = new(540, 800);
        string text = "";

        bool hidden = false;

        public Textbox(Texture2D texture, SpriteFont font)
        {
            this.texture = texture;
            gameFont = font;
        }
        public void Talk(string text)
        {
            this.text = text;
            hidden = false;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!hidden) 
            {
                spriteBatch.Draw(texture, position, null, Color.White, 0, new Vector2(), new Vector2(0.5f,1), SpriteEffects.None, 0f); ;
                spriteBatch.DrawString(gameFont, text, new Vector2(position.X+80,position.Y+25), Color.Black);
            }
        }
    }
}
