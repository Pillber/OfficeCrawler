using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OfficeCrawler {


    // This might change from static implementation to singleton implementation. CAREFUL!

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
        public static int _windowWidth;
        // private representation of the current height of the backbuffer
        public static int _windowHeight;
        // private reference to a white 1x1 pixel Texture2D
        private static Texture2D _pixelRectangle;
        // private reference to a rendertarget that the Area will be drawn to
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
            }
        }

        // Property to access the GraphicsDevice
        // Creates a rendertarget for the area, and sets the _windowWidth and _windowHeight to the Viewport values
        public static GraphicsDevice GraphicsDevice {
            get => _graphicsDevice;
            set {
                _graphicsDevice = value;
                _areaRenderTarget = new RenderTarget2D(value, VirtualWidth, VirtualHeight);
                _windowWidth = value.Viewport.Width;
                _windowHeight = value.Viewport.Height;
            }
        }

        // Property to get the 1x1 pixel Texture2D
        // If the PixelRectangle is not set, it will make a new pixel rectangle
        public static Texture2D PixelRectangle {
            get {
                if (_pixelRectangle == null) {
                    InitializePixelRectangle();
                }
                return _pixelRectangle;
            }
        }

        // Property to access the _windowWidth
        public static int WindowWidth {
            get => _windowWidth;
            set => _windowWidth = value;
        }

        // Property to access the _windowHeight
        public static int WindowHeight {
            get => _windowHeight;
            set => _windowHeight = value;
        }


        #endregion

        #region Methods
        // Begins drawing for the scene (pixel art)
        public static void BeginArea(Matrix transformMatrix) {
            _graphicsDevice.SetRenderTarget(_areaRenderTarget);
            _graphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: transformMatrix);
        }

        // Sets the _graphicsDevice Viewport to a full window viewport
        private static void SetupFullViewport() {
            _graphicsDevice.Viewport = new Viewport() {
                X = 0,
                Y = 0,
                Width = _windowWidth,
                Height = _windowHeight
            };
        }

        // Sets the _graphicsDevice Viewport to a viewport that scales the virtual resolution as much as possible and pillar/letterboxes
        private static void SetupVirtualViewport() {
            int scale = MathHelper.Min(_windowWidth / VirtualWidth, _windowHeight / VirtualHeight);
            // Take remainder of screen real estate, if any, and place the upscaled rendertarget at the new position
            int startingX = (_windowWidth % (VirtualWidth * scale)) / 2;
            int startingY = (_windowHeight % (VirtualHeight * scale)) / 2;

            _graphicsDevice.Viewport = new Viewport() {
                X = startingX,
                Y = startingY,
                Width = VirtualWidth * scale,
                Height = VirtualHeight * scale
            };
        }

        // Draws to the backbuffer
        public static void BeginBackbuffer() {
            //make sure we are rendering to the backbuffer
            _graphicsDevice.SetRenderTarget(null);
            //set viewport to full window
            SetupFullViewport();
            _graphicsDevice.Clear(Color.Black);
            //set viewport to virtual viewport
            SetupVirtualViewport();
            //draw rendertarget (debug)
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_areaRenderTarget, new Rectangle(0, 0, _graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height), Color.White);
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

        // Deletes the 1x1 pixel Texture2D from video memory, as well as the areaRenderTarget
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
        */
        #endregion
    }
}
