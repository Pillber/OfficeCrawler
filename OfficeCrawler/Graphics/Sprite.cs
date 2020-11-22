using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OfficeCrawler {

    public class Sprite {

        #region Private Variables
        /// <summary>
        /// A reference to the texture to be displayed 
        /// </summary>
        private Texture2D _texture;
        /// <summary>
        /// A representation of the color the sprite will be tinted with 
        /// </summary>
        private Color _tint;
        /// <summary>
        /// A representation of the layer depth (??)
        /// </summary>
        private int _layerDepth;
        /// <summary>
        /// A boolean representation of whether or not the sprite is flipped vertically 
        /// </summary>
        private bool _flipped;
        /// <summary>
        /// An integer representation of the width of the sprite 
        /// </summary>
        private int _width;
        /// <summary>
        /// An integer representation of the height of the sprite 
        /// </summary>
        private int _height;
        #endregion

        # region Properties
        /// <summary>
        /// Gets the _texture private variable 
        /// </summary>
        public Texture2D Texture {
            get => _texture;
            set {
                _texture = value;
                _width = value.Width;
                _height = value.Height;
            }
        }
        /// <summary>
        /// Gets the _color private variable 
        /// </summary>
        public Color Tint {
            get => _tint;
            set => _tint = value;
        }
        /// <summary>
        /// Gets the _layerDepth private variable 
        /// </summary>
        public int LayerDepth {
            get => _layerDepth;
            set => _layerDepth = value;
        }
        /// <summary>
        /// Gets the _flipped private variable 
        /// </summary>
        public bool Flipped {
            get => _flipped;
            set => _flipped = value;
        }
        /// <summary>
        /// Returns SpriteEffects.FlipVertically if the sprite is flipped, and SpriteEffects.None if not 
        /// </summary>
        public SpriteEffects Effects {
            get {
                return _flipped ? SpriteEffects.FlipVertically : SpriteEffects.None;
            }
        }
        /// <summary>
        /// Returns the _width variable 
        /// </summary>
        public int Width {
            get;
        }
        /// <summary>
        /// Returns the _height variable 
        /// </summary>
        public int Height {
            get;
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a sprite with the specified texture, color, layerDepth, and flipped.
        /// If the texture is null then the _width and _height of the sprite are set to 0.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="tint"></param>
        /// <param name="layerDepth"></param>
        /// <param name="flipped"></param>
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