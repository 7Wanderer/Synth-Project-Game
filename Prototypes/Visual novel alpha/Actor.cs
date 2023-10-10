using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Visual_novel_alpha
{
    enum TextureSheet
    {
        IdleAnim,
        RunningAnim
    }
    enum Portraits
    {
        Normal,
        Happy,
        Joyous,
        Curious,
        Confident,
        Distressed,
        Shocked,
        Sad,
        Crying,
        Angry,
        Grimacing,
        Thinking,
        Custom1,
        Custom2
    }
    public class Actor
    {
        //constants (had to define with readonly because i'm a bitch)
        readonly int SPRITE_WIDTH = 480, SPRITE_HEIGHT=960;
        readonly float SPRITE_SCALE = 1;
        readonly int PORTRAIT_WIDTH = 0, PORTRAIT_HEIGHT;
        readonly float PORTRAIT_SCALE = 1;

        readonly Vector2 DEFAULT = new(80,80);
        readonly Vector2 DEFAULT_REVERSE = new(1360,80);

        TextureSheet animation = TextureSheet.IdleAnim;

        Portraits portrait = Portraits.Normal;

        Texture2D[] spriteTextureSheets;
        Texture2D portraitTextureSheet;

        Vector2 spritePosition;
        Vector2 portraitPosition;

        SpriteEffects isReversed;
        SpriteEffects portraitReversed;

        bool portraitHidden = true;

        public Actor(Texture2D portraitTextureSheet) 
        { 
            // this.spritePosition = spritePosition;
            // this.spriteTextureSheets = spriteTextureSheets;
            this.portraitTextureSheet = portraitTextureSheet;
            portraitPosition = DEFAULT;
        }

        public void Update()
        {

        }
        Rectangle getRectFromTexture()
        {
            return new Rectangle((int)portrait * PORTRAIT_WIDTH, 0,
                                PORTRAIT_WIDTH, PORTRAIT_HEIGHT);
        }
        Rectangle getRectFromPortrait()
        {
            return new Rectangle((int)portrait * PORTRAIT_WIDTH,0,
                                PORTRAIT_WIDTH,PORTRAIT_HEIGHT);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            /*
            spriteBatch.Draw(spriteTextureSheets[((int)animation)],
                spritePosition,
                getRectFromTexture(),
                Color.White, 0, new Vector2(), SPRITE_SCALE, isReversed, 0);
            */
            if(!portraitHidden)
                spriteBatch.Draw(portraitTextureSheet,
                    portraitPosition,
                    getRectFromPortrait(),
                    Color.White, 0, new Vector2(), SPRITE_SCALE, isReversed, 0);
        }
    }
}
