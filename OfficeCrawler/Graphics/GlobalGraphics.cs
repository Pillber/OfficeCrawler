using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace OfficeCrawler {


    public static class GlobalGraphics {

        #region Constants
        // Constant for the Virtual Width of the game (in pixels)
        public const int VirtualWidth = 320;
        // Constant for the Virtual Height of the game (in pixels)
        public const int VirtualHeight = 180;
        #endregion

        #region Private Variables
        // private reference to the SpriteBatch
        private static SpriteBatch _spriteBatch;
        // private reference to the GraphicsDeviceManager
        private static GraphicsDeviceManager _graphicsManager;
        // private reference to the GraphicsDevice
        private static GraphicsDevice _graphicsDevice;
        // private representation of the current width of the backbuffer
        private static int _screenWidth;
        // private representation of the current height of the backbuffer
        private static int _screenHeight;
        // private reference to a white 1x1 pixel Texture2D
        private static Texture2D _pixelRectangle;
        private static RenderTarget2D _areaRenderTarget;

        
        #endregion

        #region Properties
        // Property to access the spritebatch
        public static SpriteBatch SpriteBatch {
            get => _spriteBatch;
            set {
                _spriteBatch = value;
            }
        }

        // Property to access the GraphicsDeviceManager
        public static GraphicsDeviceManager GraphicsManager {
            get => _graphicsManager;
            set {
                _graphicsManager = value;
                _graphicsManager.IsFullScreen = true;
                _graphicsManager.PreferredBackBufferWidth = VirtualWidth * 6;
                _graphicsManager.PreferredBackBufferHeight = VirtualHeight * 6;
                _graphicsManager.ApplyChanges();
            }
        }

        // Property to access the GraphicsDevice
        public static GraphicsDevice GraphicsDevice {
            get => _graphicsDevice;
            set {
                _graphicsDevice = value;
                _areaRenderTarget = new RenderTarget2D(value, VirtualWidth, VirtualHeight);
            }
        }

        // Property to get the 1x1 pixel Texture2D
        public static Texture2D PixelRectangle {
            get {
                if (_pixelRectangle == null) {
                    InitializePixelRectangle();
                }
                return _pixelRectangle;
            }
        }
        #endregion

        #region Methods
        // Begins drawing for the scene (pixel art)
        public static void BeginArea(Matrix transformMatrix) {
            _graphicsDevice.SetRenderTarget(_areaRenderTarget);
            _graphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: transformMatrix);
        }

        public static void BeginBackbuffer() {
            // Work with GraphicsDevice.Viewport.Width/Height to do Resolution Independence Math if fullscreen
            // If not fullscreen, we're f*****
            _graphicsDevice.SetRenderTarget(null);
            _graphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_areaRenderTarget, new Rectangle(0, 0, GraphicsManager.PreferredBackBufferWidth, GraphicsManager.PreferredBackBufferHeight), Color.White);
        }

        // Ends the current spritebatch
        public static void End() {
            _spriteBatch.End();
            _graphicsDevice.SetRenderTarget(null);
        }

        // Sets up the 1x1 pixel Texture2D
        private static void InitializePixelRectangle() {
            _pixelRectangle = new Texture2D(_graphicsDevice, 1, 1);
            _pixelRectangle.SetData(new Color[] { Color.White });
        }

        // Deletes the 1x1 pixel Texture2D from video memory
        public static void UnloadContent() {
            if (_pixelRectangle != null)
                _pixelRectangle.Dispose();
            if (_areaRenderTarget != null)
                _areaRenderTarget.Dispose();
        }
        #endregion

        #region Deprecated Methods
        /*
        public void DrawRect(Vector2 position, int width, int height, Color color) {
            if(_pixelRectangle == null) {
                InitializePixelRectangle();
            }
            _spriteBatch.Draw(_pixelRectangle, new Rectangle((int) Math.Round(position.X), (int) Math.Round(position.Y), width, height), color);
        }
        

        private static void SetupFullViewport() {
            GraphicsDevice.Viewport = new Viewport {
                X = 0,
                Y = 0,
                Width = _screenWidth,
                Height = _screenHeight
            };
        }

        private static void SetupVirtualViewport() {
            float aspectRatio = VirtualWidth / (float) VirtualHeight;
            int width = _screenWidth;
            int height = (int)(_screenWidth / aspectRatio + 0.5f);

            if(height > _screenHeight) {
                height = _screenHeight;
                width = (int)(height * aspectRatio + 0.5f);
            }
            GraphicsDevice.Viewport = new Viewport {
                X = (_screenWidth / 2) - (width / 2),
                Y = (_screenHeight / 2) - (height / 2),
                Width = width,
                Height = height
            };
        }
        */
        #endregion
    }
}
