using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

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

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            _player.Update(gameTime);
            _camera.Update();
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime) {
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
    }
}

