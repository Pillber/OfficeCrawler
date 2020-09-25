using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

/*TODO
 *
 *
 *
 *
 *
 */


namespace OfficeCrawler {
    public class OfficeCrawler : Game {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;
        private static Random Rand = new Random();
        public const int Scale = 4;

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
            Window.AllowAltF4 = true;
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Texture2D playerTex = Content.Load<Texture2D>("office_crawler_proto_final");
            _player.SetTexture(playerTex);
            _player.AddFont(Content.Load<SpriteFont>("insult"));
        }

        private List<Enemy> _enemies = new List<Enemy>();
        private float _respawnSpeed = 3f;
        protected override void Update(GameTime gameTime) {
            if (!_player.Alive) {
                if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
                    Reset();
                }
            }
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _respawnSpeed -= elapsedTime;
            if(_respawnSpeed <= 0) {
                _enemies.Add(new Enemy(_player.GetTexture(), new Vector2(Rand.Next(0, _graphics.PreferredBackBufferWidth), Rand.Next(0, _graphics.PreferredBackBufferHeight))));
                _respawnSpeed = 3f;
            }
               
            if(_enemies.Count > 0) {
                for (int index = 0; index < _enemies.Count; index++) {
                    _enemies[index].Update(gameTime, _player);
                    if (!_enemies[index].Alive)
                        _enemies.RemoveAt(index);
                }
                
            }
            // TODO: Add your update logic here
            _player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            if(_player.Alive) {
                if (_player.moving)
                    GraphicsDevice.Clear(Color.CornflowerBlue);
                else
                    GraphicsDevice.Clear(Color.PaleVioletRed);
                _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
                // TODO: Add your drawing code here
                _player.Draw(gameTime, _spriteBatch);
                if (_enemies.Count > 0) {
                    foreach (Enemy enemy in _enemies) {
                        enemy.Draw(gameTime, _spriteBatch);
                    }
                }
                _spriteBatch.End();
            } else {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                _spriteBatch.Begin();
                _player.PromptReset(_spriteBatch);
                _spriteBatch.End();
            }
            
            base.Draw(gameTime);
        }

        private void Reset() {
            SpriteFont font = _player.GetFont();
            _player = new Player(_player.GetTexture(), Vector2.Zero);
            _player.AddFont(font);
            _player.GameWidth = _graphics.PreferredBackBufferWidth;
            _player.GameHeight = _graphics.PreferredBackBufferHeight;
            ResetElapsedTime();
            Window.TextInput += _player.GetTyping;
            _enemies = new List<Enemy>();
        }
    }
}

