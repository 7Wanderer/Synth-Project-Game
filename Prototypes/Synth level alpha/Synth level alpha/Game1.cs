using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Synth_level_alpha
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Player player;
        public Sprite enemy;
        Background background;
        Terrain terrain;
        SpriteFont gameFont;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D test = Content.Load<Texture2D>("1-2 stickfigure");
            Texture2D BGtexture = Content.Load<Texture2D>("Background1");
            Texture2D terraintexture = Content.Load<Texture2D>("terrain2");
            List<Texture2D> list = new List<Texture2D>();
            list.Add(Content.Load<Texture2D>("far"));
            list.Add(Content.Load<Texture2D>("mid"));
            list.Add(Content.Load<Texture2D>("near"));
            player = new Player(test, new Vector2(graphics.PreferredBackBufferWidth / 2, (int)(graphics.PreferredBackBufferHeight * 0.75)));
            player.sprite.Colour = Color.White;
            enemy = new Sprite(test, new Vector2(700, 800));
            enemy.Colour = Color.Red;
            enemy.spriteEffects = SpriteEffects.FlipHorizontally;
            background = new Background(BGtexture, list.ToArray());
            terrain = new Terrain(terraintexture);
            gameFont = Content.Load<SpriteFont>("File");


            // TODO: use this.Content to load your game content here
        }
        void checkScroll()
        {
            if(-Globals.offset.X == terrain.Position.X)
            {
                if (player.sprite.Position.X <= graphics.PreferredBackBufferWidth/2)
                {
                    Globals.isScrolling = false;
                }
                else Globals.isScrolling = true;
            }
            if (-Globals.offset.X + graphics.PreferredBackBufferWidth == terrain.texture.Width)
            {
                if (player.sprite.Position.X >= graphics.PreferredBackBufferWidth/2)
                {
                    Globals.isScrolling = false;
                }
                else Globals.isScrolling = true;
            }
        }
        protected override void Update(GameTime gameTime)
        {
            checkScroll();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update();
            if (player.sprite.Position.Y < graphics.PreferredBackBufferHeight/2 + player.sprite.texture.Height/2) 
                player.sprite.Position.Y = graphics.PreferredBackBufferHeight / 2 + player.sprite.texture.Height/2;
            else if (player.sprite.Position.Y > graphics.PreferredBackBufferHeight - player.sprite.texture.Height/2) 
                player.sprite.Position.Y = graphics.PreferredBackBufferHeight - player.sprite.texture.Height/2;

            enemy.Update();

            if(enemy.IsTouching(player)) enemy.Colour = Color.Green;
            else enemy.Colour = Color.Red;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            background.Draw(spriteBatch);
            terrain.Draw(spriteBatch);
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
            spriteBatch.DrawString(gameFont, Convert.ToString(Globals.offset.X), new Vector2(), Color.White);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}