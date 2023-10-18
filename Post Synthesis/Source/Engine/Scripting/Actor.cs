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

namespace Post_Synthesis
{
    public enum Portraits
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
        // constants (had to define with readonly because i'm a bitch)

        readonly int WIDTH = 480, HEIGHT = 960;
        readonly float SCALE = 1;

        readonly Vector2 DEFAULT;
        readonly Vector2 DEFAULT_REVERSE;

        Portraits portrait = Portraits.Normal;

        Texture2D portraitTextureSheet;
        Texture2D nameBox;

        public string name;

        Vector2 portraitPosition;

        SpriteEffects portraitReversed = SpriteEffects.None;

        public bool portraitHidden = true;

        public Actor(Texture2D portraitTextureSheet, Texture2D nameBox, string name)
        {
            DEFAULT = new(0, 0);
            DEFAULT_REVERSE = new(Globals.screenWidth - WIDTH, 0);
            this.portraitTextureSheet = portraitTextureSheet;
            portraitPosition = DEFAULT;
            this.name = name;
            // this.nameBox = nameBox;
        }

        public void SetFace(Portraits portrait, bool Reversed)
        {
            portraitHidden = false;
            this.portrait = portrait;
            if (Reversed)
            {
                portraitReversed = SpriteEffects.None;
                portraitPosition = DEFAULT_REVERSE;
            }
            else
            {
                portraitReversed = SpriteEffects.FlipHorizontally;
                portraitPosition = DEFAULT;
            }
        }
        /*
        public void Update()
        {

        }
        */

        Rectangle getRectFromPortrait()
        {
            return new Rectangle((int)portrait * WIDTH, 0,
                                WIDTH, HEIGHT);
        }
        Vector2 getPositionFromReverse()
        {
            if (portraitReversed == SpriteEffects.None) return DEFAULT_REVERSE;
            else return DEFAULT;
        }
        public void Draw()
        {
            if (!portraitHidden)
            {
                Globals.spriteBatch.Draw(portraitTextureSheet, portraitPosition,
                    getRectFromPortrait(),
                    Color.White, 0, Vector2.Zero, SCALE, portraitReversed, 0);

                // Globals.spriteBatch.Draw(nameBox, new Vector2(getPositionFromReverse().X, getPositionFromReverse().Y + 100), Color.White);
                Globals.spriteBatch.DrawString(Globals.gameFont, name, 
                                    new Vector2(getPositionFromReverse().X, getPositionFromReverse().Y + 300), Color.Black);
            }

        }
    }
}
