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
            var viewportCenter = new Vector2(GraphicsContext.GraphicsDevice.Viewport.Width / 2, GraphicsContext.GraphicsDevice.Viewport.Height / 2);
            var matrix = Matrix.CreateTranslation(-cameraPosition.X, -cameraPosition.Y, 0) *
                Matrix.CreateRotationZ(0) *
                Matrix.CreateScale(zoom, zoom, 0); //* 

                //This line would center the camera around the player's origin (0, 0)
                //Matrix.CreateTranslation(new Vector3(viewportCenter, 0));



            GraphicsContext.Begin(matrix);
            _player.Draw(gameTime);
            GraphicsContext.DrawRect(new Vector2(100, 100), 10, 20, Color.Red);
            GraphicsContext.End();
            
            base.Draw(gameTime);
        }

        protected override void UnloadContent() {
            GraphicsContext.UnloadContent();
            base.UnloadContent();

        }
    }
}

