using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace OfficeCrawler {
    public class OfficeCrawler : Game {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static GraphicsContext GraphicsContext;


        private Player _player = new Player();
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
            base.Initialize();
        }


        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GraphicsContext.SpriteBatch = _spriteBatch;
            // TODO: use this.Content to load your game content here
            _player.LoadContent(Content.Load<Texture2D>("office_crawler_player"));
            _song = Content.Load<Song>("OfficeCrawlerMusic");
            MediaPlayer.Play(_song);
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            _player.Update(gameTime);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing logic here
            GraphicsContext.Begin();
            _player.Draw(gameTime);
            GraphicsContext.DrawRect(new Vector2(100, 100), 10, 20, Color.Red);
            GraphicsContext.End();

            
            _spriteBatch.Begin();
            _spriteBatch.Draw(GraphicsContext._renderTarget2D, Vector2.Zero, Color.White);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }

        protected override void UnloadContent() {
            base.UnloadContent();

        }
    }
}

