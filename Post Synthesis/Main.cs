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

            List<Texture2D> t = new()
            {
                Content.Load<Texture2D>("Assets\\World\\Backgrounds\\Alpha Level\\far"),
                Content.Load<Texture2D>("Assets\\World\\Backgrounds\\Alpha Level\\mid"),
                Content.Load<Texture2D>("Assets\\World\\Backgrounds\\Alpha Level\\near")
            };
            Enemy[] enemies = { new Enemy("Assets\\Sprites\\test enemy s", new Vector2(1200, 550), new Vector2(128, 216)) };
            Level level1 = new Level(new Player("Assets\\Sprites\\Syn\\walk cycle template", new(100,500), new(128,216)),
                                    enemies,
                                    new(Globals.screenHeight - 350, ""),
                                    new("Assets\\World\\Backgrounds\\Alpha Level\\Background1", new(0, 0), new(1600, 900), t));
            world = new World(level1);

            Globals.scriptManager = new(new TestScript1(), new List<Actor>()
            {
                new Actor(Globals.content.Load<Texture2D>("Assets\\Portraits\\syn alpha"),null,"Syn"),
                new Actor(Globals.content.Load<Texture2D>("Assets\\Portraits\\flint alpha"),null,"Flint"),
                new Actor(Globals.content.Load<Texture2D>("Assets\\Portraits\\sasha alpha"),null,"Sasha")
            });

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

            if (Globals.scriptManager.inactive)
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

            world.Draw();
            if (!Globals.scriptManager.inactive) Globals.scriptManager.Draw();

            Globals.spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}