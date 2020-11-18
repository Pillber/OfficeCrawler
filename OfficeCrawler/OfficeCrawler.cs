using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Diagnostics;

namespace OfficeCrawler {
    public class OfficeCrawler : Game {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static Random Random = new Random();


        private Player _player = new Player();
        private Camera _camera = new Camera(Vector2.Zero);
        private Word _word = new Word();
        private Song _song;

        public OfficeCrawler() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += WindowSizeChanged;
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }


        protected override void Initialize() {
            // TODO: Add your initialization logic here
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GlobalGraphics.GraphicsManager = _graphics;
            GlobalGraphics.GraphicsDevice = GraphicsDevice;
            GlobalGraphics.SpriteBatch = _spriteBatch;
            _player.Initialize();
            _word.Initialize();
            base.Initialize();
        }


        protected override void LoadContent() {
            // TODO: use this.Content to load your game content here
            _player.LoadContent(Content.Load<Texture2D>("office_crawler_player"));
            _song = Content.Load<Song>("OfficeCrawlerMusic");
            //MediaPlayer.Play(_song);
        }

        private KeyboardState previousKeyState;

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            _player.Update(gameTime);
            _camera.Update();


            KeyboardState keyState = Keyboard.GetState();

            if(keyState.IsKeyDown(Keys.Space) && !previousKeyState.IsKeyDown(Keys.Space)) {
                GlobalGraphics.GraphicsManager.IsFullScreen = !GlobalGraphics.GraphicsManager.IsFullScreen;
                GlobalGraphics.GraphicsManager.ApplyChanges();
            }
            previousKeyState = keyState;
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime) {

            //Debug.WriteLine("Viewport Size, Width: " + GlobalGraphics.GraphicsDevice.Viewport.Width + ", Height: " + GlobalGraphics.GraphicsDevice.Viewport.Height);

            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing logic here
            GlobalGraphics.BeginArea(_camera.TransformationMatrix);
            _player.Draw(gameTime);
            _word.Draw(gameTime);
            GlobalGraphics.End();

            GlobalGraphics.BeginBackbuffer();
            GlobalGraphics.End();
            
            base.Draw(gameTime);
        }

        protected override void UnloadContent() {
            GlobalGraphics.UnloadContent();
            base.UnloadContent();

        }

        private void WindowSizeChanged(object sender, EventArgs eventArgs) {
            if(GlobalGraphics.GraphicsManager != null) {
                Debug.WriteLine("Backbuffer Width: " + GlobalGraphics.GraphicsManager.PreferredBackBufferWidth + ", Height: " + GlobalGraphics.GraphicsManager.PreferredBackBufferHeight);

                int width = Window.ClientBounds.Width;
                int height = Window.ClientBounds.Height;
                GlobalGraphics.ScreenWidth = width;
                GlobalGraphics.ScreenHeight = height;
                GlobalGraphics.GraphicsDevice.Viewport = new Viewport() {
                    X = 0,
                    Y = 0,
                    Width = width,
                    Height = height
                };
            }
        }
    }
}

