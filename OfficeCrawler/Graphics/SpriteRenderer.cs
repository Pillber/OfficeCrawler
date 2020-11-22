using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OfficeCrawler {

    public class SpriteRenderer : IRenderable {

        #region Private Variables
        /// <summary>
        /// A reference to the sprite that the renderer will, well, render 
        /// </summary>
        private Sprite _sprite;
        /// <summary>
        /// A reference to the transform to position the sprite for rendering 
        /// </summary>
        private Transform _transform;
        #endregion

        #region Properites
        /// <summary>
        /// Gets the _sprite private variable 
        /// </summary>
        public Sprite Sprite {
            get => _sprite;
            set {
                _sprite = value;
            }
        }
        /// <summary>
        /// Gets the _transform private variable 
        /// </summary>
        public Transform Transform {
            get => _transform;
            set {
                _transform = value;
            }
        }
        #endregion

        #region IRenderable Abstract Methods
        /// <summary>
        /// Draws the sprite, using the _sprite and _transform to draw and position correctly 
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            spriteBatch.Draw(_sprite.Texture, _transform.Position, null, _sprite.Tint, _transform.Rotation, Vector2.Zero, _transform.Scale, _sprite.Effects, _sprite.LayerDepth);
        }
        /// <summary>
        /// Draws a rectangle, with width and height, and tint 
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRect(SpriteBatch spriteBatch, GameTime gameTime, int width, int height) {
            spriteBatch.Draw(GlobalGraphics.PixelRectangle, new Rectangle((int)_transform.X, (int)_transform.Y, width, height), _sprite.Tint);
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes all variables to the specified value passed in to the constructor
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="transform"></param>
        public SpriteRenderer(Sprite sprite, Transform transform) {
            _sprite = sprite;
            _transform = transform;
        }
        #endregion
    }
}