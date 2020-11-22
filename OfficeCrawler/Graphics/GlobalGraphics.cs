using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OfficeCrawler {


    // This might change from static implementation to singleton implementation. CAREFUL!

    public static class GlobalGraphics {

        #region Constants
        /// <summary>
        /// Constant for the Virtual Width of the game (in pixels) 
        /// </summary>
        public const int VirtualWidth = 320;
        /// <summary>
        /// Constant for the Virtual Height of the game (in pixels) 
        /// </summary>
        public const int VirtualHeight = 180;
        #endregion

        #region Private Variables
        /// <summary>
        ///  private reference to the SpriteBatch
        /// </summary>
        private static SpriteBatch _spriteBatch;
        /// <summary>
        /// private reference to the GraphicsDeviceManager
        /// </summary>
        private static GraphicsDeviceManager _graphicsManager;
        /// <summary>
        /// private reference to the GraphicsDevice
        /// </summary>
        private static GraphicsDevice _graphicsDevice;
        /// <summary>
        /// private representation of the current width of the backbuffer
        /// </summary>
        public static int _windowWidth;
        /// <summary>
        /// private representation of the current height of the backbuffer
        /// </summary>
        public static int _windowHeight;
        /// <summary>
        /// private reference to a white 1x1 pixel Texture2D
        /// </summary>
        private static Texture2D _pixelRectangle;
        /// <summary>
        ///  private reference to a rendertarget that the Area will be drawn to
        /// </summary>
        private static RenderTarget2D _areaRenderTarget;


        #endregion

        #region Properties
        /// <summary>
        /// Property to access the spritebatch
        /// </summary>
        public static SpriteBatch SpriteBatch {
            get => _spriteBatch;
            set {
                _spriteBatch = value;
            }
        }
        /// <summary>
        /// Property to access the GraphicsDeviceManager
        /// </summary>
        public static GraphicsDeviceManager GraphicsManager {
            get => _graphicsManager;
            set {
                _graphicsManager = value;
            }
        }
        /// <summary>
        /// Property to access the GraphicsDevice.
        /// Creates a rendertarget for the area, and sets the _windowWidth and _windowHeight to the Viewport values
        /// </summary>
        public static GraphicsDevice GraphicsDevice {
            get => _graphicsDevice;
            set {
                _graphicsDevice = value;
                _areaRenderTarget = new RenderTarget2D(value, VirtualWidth, VirtualHeight);
                _windowWidth = value.Viewport.Width;
                _windowHeight = value.Viewport.Height;
            }
        }

        /// <summary>
        /// Property to get the 1x1 pixel Texture2D.
        /// If the PixelRectangle is not set, it will make a new pixel rectangle
        /// </summary>
        public static Texture2D PixelRectangle {
            get {
                if (_pixelRectangle == null) {
                    InitializePixelRectangle();
                }
                return _pixelRectangle;
            }
        }

        /// <summary>
        /// Property to access the _windowWidth
        /// </summary>

        public static int WindowWidth {
            get => _windowWidth;
            set => _windowWidth = value;
        }

        /// <summary>
        /// Property to access the _windowHeight
        /// </summary>
        public static int WindowHeight {
            get => _windowHeight;
            set => _windowHeight = value;
        }


        #endregion

        #region Methods
        /// <summary>
        /// Begins drawing for the scene (pixel art)
        /// </summary>
        /// <param name="transformMatrix"></param>
        public static void BeginArea(Matrix transformMatrix) {
            _graphicsDevice.SetRenderTarget(_areaRenderTarget);
            _graphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: transformMatrix);
        }
        /// <summary>
        /// Sets the _graphicsDevice Viewport to a full window viewport
        /// </summary>
        private static void SetupFullViewport() {
            _graphicsDevice.Viewport = new Viewport() {
                X = 0,
                Y = 0,
                Width = _windowWidth,
                Height = _windowHeight
            };
        }
        /// <summary>
        /// Sets the _graphicsDevice Viewport to a viewport that scales the virtual resolution as much as possible and pillar/letterboxes
        /// </summary>
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
        /// <summary>
        /// Draws to the backbuffer
        /// </summary>
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
        /// <summary>
        /// Ends the current spritebatch
        /// </summary>
        public static void End() {
            _spriteBatch.End();
            _graphicsDevice.SetRenderTarget(null);
        }
        /// <summary>
        /// Sets up the 1x1 pixel Texture2D
        /// </summary>
        private static void InitializePixelRectangle() {
            _pixelRectangle = new Texture2D(_graphicsDevice, 1, 1);
            _pixelRectangle.SetData(new Color[] { Color.White });
        }
        /// <summary>
        /// Deletes the 1x1 pixel Texture2D from video memory, as well as the areaRenderTarget
        /// </summary>
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
