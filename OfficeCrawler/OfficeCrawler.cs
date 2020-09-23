using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

/*TODO:
 * Basic Enemy AI
 * Timers for enemy spawning
 * Enemy List for more than one enemy on screen.
 * Enemy damage to player (lose state)
 */


namespace OfficeCrawler {
    public class OfficeCrawler : Game {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;
        private static Random Rand = new Random();
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

        private Enemy _enemy;
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(_player.moving && Keyboard.GetState().IsKeyDown(Keys.Space)) {
                _enemy = new Enemy(_player.GetTexture(), new Vector2(Rand.Next(0, _graphics.PreferredBackBufferWidth), Rand.Next(0, _graphics.PreferredBackBufferHeight)));
            }
            if(_enemy != null) {
                _enemy.Update(gameTime, _player);
                if(!_enemy.Alive )
                    _enemy = null;
            }
            // TODO: Add your update logic here
            _player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            if (_player.moving)
                GraphicsDevice.Clear(Color.CornflowerBlue);
            else
                GraphicsDevice.Clear(Color.PaleVioletRed);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            // TODO: Add your drawing code here
            _player.Draw(gameTime, _spriteBatch);
            if(_enemy != null)
                _enemy.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

