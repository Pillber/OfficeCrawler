using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OfficeCrawler {

    public class SpriteRenderer : IRenderable {

        #region Private Variables
        // A reference to the sprite that the renderer will, well, render
        private Sprite _sprite;
        // A reference to the transform to position the sprite for rendering
        private Transform _transform;
        #endregion

        #region Properites
        // Gets the _sprite private variable
        public Sprite Sprite {
            get => _sprite;
            set {
                _sprite = value;
            }
        }
        // Gets the _transform private variable
        public Transform Transform {
            get => _transform;
            set {
                _transform = value;
            }
        }
        #endregion

        #region IRenderable Abstract Methods
        // Draws the sprite, using the _sprite and _transform to draw and position correctly
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            spriteBatch.Draw(_sprite.Texture, _transform.Position, null, _sprite.Tint, _transform.Rotation, Vector2.Zero, _transform.Scale, _sprite.Effects, _sprite.LayerDepth);
        }
        #endregion

        #region Constructor
        // Initializes all variables to the specified value passed in to the constructor
        public SpriteRenderer(Sprite sprite, Transform transform) {
            _sprite = sprite;
            _transform = transform;
        }
        #endregion
    }
}