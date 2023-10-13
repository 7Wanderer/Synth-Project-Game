#region
using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Synth_Project.Source.Engine.Input;
#endregion

namespace Synth_Project
{

    public delegate void PassObject(object i);
    public delegate void PassObjectAndReturn(object i);

    class Globals
    {
        public static int screenWidth, screenHeight;



        public static ContentManager content;
        public static SpriteBatch spriteBatch;

        public static InputManager inputManager;

        public static GameTime gameTime;

    }
}
