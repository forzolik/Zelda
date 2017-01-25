using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using Zelda.Components;
using Zelda.Components.Enemies;
using Zelda.Components.Movement;
using Zelda.Manager;

namespace Zelda
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private BaseObject _player;
        private BaseObject _testNPC;
        private BaseObject _testEnemy;
        private ManagerInput _managerInput;
        private ManagerMap _managerMap;
        private ManagerCamera _managerCamera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
            this.graphics.PreferredBackBufferHeight = 128;
            this.graphics.PreferredBackBufferWidth = 160;
            _player = new BaseObject();
            _testNPC = new BaseObject();
            _testEnemy = new BaseObject();
            _managerInput = new ManagerInput();
            _managerCamera = new ManagerCamera();
            _managerMap = new ManagerMap("test", _managerCamera);
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

           



        }

       

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _managerMap.LoadContent(Content);

            _player.AddComponent(new Sprite(Content.Load<Texture2D>("link_full"), 16,16,new Vector2(16,16)));
            _player.AddComponent(new PlayerInput());
            _player.AddComponent(new Animation(16, 16));
            _player.AddComponent(new Collision(_managerMap));
            _player.AddComponent(new Camera(_managerCamera));

            _testNPC.AddComponent(new Sprite(Content.Load<Texture2D>("Marin"), 16, 16, new Vector2(16*4, 16*2)));
            _testNPC.AddComponent(new AIMovementRandom(200));
            _testNPC.AddComponent(new Animation(16, 16));
            _testNPC.AddComponent(new Collision(_managerMap));
            _testNPC.AddComponent(new Camera(_managerCamera));

            _testEnemy.AddComponent(new Sprite(Content.Load<Texture2D>("Octorok"), 16, 16, new Vector2(16 * 1, 16 * 7)));
            _testEnemy.AddComponent(new AIMovementRandom(200));
            _testEnemy.AddComponent(new Animation(16, 16));
            _testEnemy.AddComponent(new Collision(_managerMap));
            _testEnemy.AddComponent(new Octorok(_player, Content.Load<Texture2D>("Octorok_bullet"), _managerMap));
            _testEnemy.AddComponent(new Camera(_managerCamera));

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

            _managerInput.Update(gameTime.ElapsedGameTime.Milliseconds);
            _player.Update(gameTime.ElapsedGameTime.Milliseconds);
            _testNPC.Update(gameTime.ElapsedGameTime.Milliseconds);
            _testEnemy.Update(gameTime.ElapsedGameTime.Milliseconds);
            _managerMap.Update(gameTime.ElapsedGameTime.Milliseconds);
            _managerCamera.Update(gameTime.ElapsedGameTime.Milliseconds);

			//some comment
			//second

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(196,207,161));

            spriteBatch.Begin();

            _managerMap.Draw(spriteBatch);
            _player.Draw(spriteBatch);
            _testNPC.Draw(spriteBatch);
            _testEnemy.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
