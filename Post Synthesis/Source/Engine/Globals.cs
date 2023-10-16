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

    public delegate void PassObject(object i);
    public delegate void PassObjectAndReturn(object i);

    class Globals
    {
        public static int screenWidth, screenHeight;

        public static SpriteFont gameFont;

        public static ContentManager content;
        public static SpriteBatch spriteBatch;

        public static InputManager inputManager;

        public static GameTime gameTime;

    }
}
