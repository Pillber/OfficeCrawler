using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OfficeCrawler {

    public class Sprite {

        #region Private Variables
        // A reference to the texture to be displayed
        private Texture2D _texture;
        // A representation of the color the sprite will be tinted with
        private Color _tint;
        // A representation of the layer depth (??)
        private int _layerDepth;
        // A boolean representation of whether or not the sprite is flipped vertically
        private bool _flipped;
        // An integer representation of the width of the sprite
        private int _width;
        // An integer representation of the height of the sprite
        private int _height;
        #endregion

        # region Properties
        // Gets the _texture private variable
        public Texture2D Texture {
            get => _texture;
            set {
                _texture = value;
                _width = value.Width;
                _height = value.Height;
            }
        }
        // Gets the _color private variable
        public Color Tint {
            get => _tint;
            set => _tint = value;
        }
        // Gets the _layerDepth private variable
        public int LayerDepth {
            get => _layerDepth;
            set => _layerDepth = value;
        }
        // Gets the _flipped private variable
        public bool Flipped {
            get => _flipped;
            set => _flipped = value;
        }
        // Returns SpriteEffects.FlipVertically if the sprite is flipped, and SpriteEffects.None if not
        public SpriteEffects Effects {
            get {
                return _flipped ? SpriteEffects.FlipVertically : SpriteEffects.None;
            }
        }
        // Returns the _width variable
        public int Width {
            get;
        }
        // Returns the _height variable
        public int Height {
            get;
        }
        #endregion

        #region Constructor
        public Sprite(Texture2D texture, Color tint, int layerDepth, bool flipped) {
            _texture = texture;
            _tint = tint;
            _layerDepth = layerDepth;
            _flipped = flipped;
            if (texture != null) {
                _width = texture.Width;
                _height = texture.Height;
            } else {
                _width = _height = 0;
            }

        }
        #endregion
    }
}