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
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;

        World world;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Globals.screenWidth = 1600;
            Globals.screenHeight = 900;
            // Note to self: When it comes to scaling, be ready to make a global scaleFactor float and multiply everything by it.
            // Alternatively, I could hang myself.
            graphics.PreferredBackBufferWidth = Globals.screenWidth;
            graphics.PreferredBackBufferHeight = Globals.screenHeight;
            graphics.ApplyChanges();

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.content = this.Content;
            Globals.inputManager = new();
            Globals.inputManager.keyboard = new();
            Globals.gameFont = Content.Load<SpriteFont>("Assets\\Fonts\\defaultFont");
            Globals.scriptManager = new(new TestScript1(),new List<Actor>()
            {
                new Actor(Content.Load<Texture2D>("Assets\\Portraits\\syn alpha"),null,"Syn")
            });
            

            world = new World();
            


            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Globals.gameTime = gameTime;

            Globals.inputManager.keyboard.Update();

            if (Globals.scriptManager == null)
                world.Update();
            else Globals.scriptManager.Update();

            Globals.inputManager.keyboard.UpdateOld();


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            world.Draw(Vector2.Zero);
            if (Globals.scriptManager != null) Globals.scriptManager.Draw();


            Globals.spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}