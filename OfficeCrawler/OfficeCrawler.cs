using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OfficeCrawler {
    public class OfficeCrawler : Game {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;
        public const int Scale = 3;

        public OfficeCrawler() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            _player = new Player(null, Vector2.Zero);
            base.Initialize();
            this.Window.TextInput += _player.GetTyping;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            _player.GameWidth = _graphics.PreferredBackBufferWidth;
            _player.GameHeight = _graphics.PreferredBackBufferHeight;
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Texture2D playerTex = Content.Load<Texture2D>("office_crawler_proto_final");
            _player.SetTexture(playerTex);
            _player.AddFont(Content.Load<SpriteFont>("insult"));
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
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            _player.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

