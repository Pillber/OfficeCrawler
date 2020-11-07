﻿using Microsoft.Xna.Framework;
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


    

    public class GraphicsContext {

        public const int VirtualWidth = 320;
        public const int VirtualHeight = 180;
        private SpriteBatch _spriteBatch;
        private GraphicsDeviceManager _graphicsManager;
        private GraphicsDevice _graphicsDevice;

        private Texture2D _pixelRectangle;

        public SpriteBatch SpriteBatch {
            get => _spriteBatch;
            set {
                _spriteBatch = value;
            }
        }

        public GraphicsDeviceManager GraphicsManager {
            get => _graphicsManager;
        }

        public GraphicsDevice GraphicsDevice {
            get => _graphicsDevice;
            set {
                _graphicsDevice = value;
            }
        }

        public GraphicsContext(GraphicsDeviceManager graphicsManager) {
            _graphicsManager = graphicsManager;
        }

        public void Begin(Matrix matrix) {
            _graphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: matrix);
        }

        public void End() {
            _spriteBatch.End();
        }

        public void DrawRect(Vector2 position, int width, int height, Color color) {
            if(_pixelRectangle == null) {
                InitializePixelRectangle();
            }
            _spriteBatch.Draw(_pixelRectangle, new Rectangle((int) Math.Round(position.X), (int) Math.Round(position.Y), width, height), color);
        }

        private void InitializePixelRectangle() {
            _pixelRectangle = new Texture2D(_graphicsDevice, 1, 1);
            _pixelRectangle.SetData(new Color[] { Color.White });
        }

        public void DrawSprite(SpriteRenderer spriteRenderer, GameTime gameTime) {
            spriteRenderer.Draw(_spriteBatch, gameTime);
        }

        public void UnloadContent() {
            if (_pixelRectangle != null)
                _pixelRectangle.Dispose();
        }
        
    }
}
