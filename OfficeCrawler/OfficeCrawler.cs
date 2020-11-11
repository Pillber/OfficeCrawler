using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace OfficeCrawler {
    public class OfficeCrawler : Game {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static GraphicsContext GraphicsContext;
        public static Random Random = new Random();


        private Player _player = new Player();
        private Word _word = new Word();
        private Song _song;

        public OfficeCrawler() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            GraphicsContext = new GraphicsContext(_graphics);
        }


        protected override void Initialize() {
            // TODO: Add your initialization logic here
            GraphicsContext.GraphicsDevice = GraphicsDevice;
            _player.Initialize();
            _word.Initialize();
            base.Initialize();
        }


        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GraphicsContext.SpriteBatch = _spriteBatch;
            // TODO: use this.Content to load your game content here
            _player.LoadContent(Content.Load<Texture2D>("office_crawler_player"));
            _song = Content.Load<Song>("OfficeCrawlerMusic");
            //MediaPlayer.Play(_song);
        }

        Vector2 cameraPosition = new Vector2();
        float zoom = 1;

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            _player.Update(gameTime);
            KeyboardState keyState = Keyboard.GetState();
            if(keyState.IsKeyDown(Keys.Left)) {
                cameraPosition.X -= 1;
            }
            if(keyState.IsKeyDown(Keys.Right)) {
                cameraPosition.X += 1;
            }
            if (keyState.IsKeyDown(Keys.Up)) {
                cameraPosition.Y -= 1;
            }
            if (keyState.IsKeyDown(Keys.Down)) {
                cameraPosition.Y += 1;
            }

            if(keyState.IsKeyDown(Keys.OemComma) && zoom > 1) {
                zoom -= .5f;
            }
            if(keyState.IsKeyDown(Keys.OemPeriod) && zoom < 5) {
                zoom += .5f;
            }
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing logic here
            GraphicsContext.Begin();
            _player.Draw(gameTime);
            _word.Draw(gameTime);
            GraphicsContext.End();
            
            base.Draw(gameTime);
        }

        protected override void UnloadContent() {
            GraphicsContext.UnloadContent();
            base.UnloadContent();

        }
    }
}

