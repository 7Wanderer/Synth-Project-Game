#region
using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace Synth_Project
{
    class Globals
    {
        public static int screenWidth, screenHeight;

        public static ContentManager content;
        public static SpriteBatch spriteBatch;

        public static baseKeyboard keyboard;

        public static GameTime gameTime;

    }
}
