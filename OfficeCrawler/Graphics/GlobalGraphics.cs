using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace OfficeCrawler {

    /*
     * RenderTarget2D at prefered scale of game (eg. 320, 180). When render to backbuffer, we just scale the rendertarget up to backbuffer size.
     *  - dependent on target resolution
     * Transform Matrix Camera
     *  - Sets moveable area of display, so we can display areas larger than the screen size
     *  - dependent on target resolution.
     *  - The camera is just a maxtrix transformation that we can use for the screen.
     * 
     * 
     * RenderTarget2D
     *  -Reference to it
     *      - GraphicsDevice
     *      - Size (width, height)
     * 
     */


    

    public static class GlobalGraphics {

        public const int VirtualWidth = 320;
        public const int VirtualHeight = 180;

        private static SpriteBatch _spriteBatch;
        private static GraphicsDeviceManager _graphicsManager;
        private static GraphicsDevice _graphicsDevice;
        private static int _screenWidth;
        private static int _screenHeight;

        private static Texture2D _pixelRectangle;

        public static SpriteBatch SpriteBatch {
            get => _spriteBatch;
            set {
                _spriteBatch = value;
            }
        }

        public static GraphicsDeviceManager GraphicsManager {
            get => _graphicsManager;
            set => _graphicsManager = value;
        }

        public static GraphicsDevice GraphicsDevice {
            get => _graphicsDevice;
            set {
                _graphicsDevice = value;
            }
        }

        public static Texture2D PixelRectangle {
            get {
                if (_pixelRectangle == null) {
                    InitializePixelRectangle();
                }
                return _pixelRectangle;
            }
        }

        public static void Begin() {
            _graphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        }

        public static void End() {
            _spriteBatch.End();
        }

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


        private static void InitializePixelRectangle() {
            _pixelRectangle = new Texture2D(_graphicsDevice, 1, 1);
            _pixelRectangle.SetData(new Color[] { Color.White });
        }

        public static void UnloadContent() {
            if (_pixelRectangle != null)
                _pixelRectangle.Dispose();
        }
        
    }
}
