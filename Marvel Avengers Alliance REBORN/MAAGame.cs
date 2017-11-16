using Marvel_Avengers_Alliance_REBORN.Models;
using Marvel_Avengers_Alliance_REBORN.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Marvel_Avengers_Alliance_REBORN
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MAAGame : Game
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        
        public const int SCREEN_WIDTH = 760;
        public const int SCREEN_HEIGHT = 630;
        
        public MAAGame()
        {
            //graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            /*graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            graphics.ApplyChanges();*/
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
                        
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        } 
    }
}
