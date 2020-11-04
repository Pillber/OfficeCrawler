using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace OfficeCrawler {
    
    /*
     * Sprite Renderer
     *  -Implement IRenderer
     *  -Sprite
     *      -Texture
     *      -Tint
     *      -Animation and Animation state
     *  -Draw
     *  -Transform
     *      -Reference to transform on entity, (0, 0) if null
     * Renderer Interface
     *  -virtual (abstract) Draw();
     * UI Renderer
     *  -Implements IRenderer
     *  -Blah, Blah, Blah
     * Transform (has to be object)
     *  -Position
     *  -Rotation
     *  -Scale
     * Physics
     *  -Collider
     *  -Update
     *  -Calculate collisions
     * InputListener - Interface/Abstract Class?
     *  -Switch inputlisteners depending on game state?
     *  -Listen for changes in the InputManager
     *  -Delegate methods for keydown, keyup, keyheld, ect.
     *  -Entity Inplements InputListener
     *      -InputLIstner.Silence to turn off input listener.
     * InputManager
     *  -Wrappings for Keyboard and possibly controller inputs
     *  -Event-Based
     *  
     * 
     * Entities will have references to each of them. access with "Player.SpriteRender.Draw();", "Enemy.Physics.DisableCollider = true;", "Player.SpriteRenderer.Sprite.Tint = Color.Red;"
     * 
     * public class BaseEntity {
     *  public SpriteRenderer SpriteRenderer;
     *  ...
     * }
     * 
     * 
     * 
     */

    interface IRenderable {
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }

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
            get =>  _sprite;
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

    public class Transform {
        #region Private Variables
        // A Vector2 representation of the x and y of this transform
        private Vector2 _position;
        // A float representation of the x value of this transform. Linked to the X value of _position.
        private float _x;
        // A float representation of the y value of this transform. Linked to the Y value of _position.
        private float _y;
        // A float representation of the rotation of this transform
        private float _rotation;
        // A float representation of the scale of this transform
        private int _scale;
        #endregion

        #region Properties
        // Gets the _position private variable. Setting will also set the _x and _y variables.
        public Vector2 Position {
            get => _position;
            set {
                _position = value;
                _x = value.X;
                _y = value.Y;
            }
        }
        // Gets the _x private variable. Setting will also set the _position.X variable
        public float X { 
            get => _x; 
            set {
                _x = value;
                _position.X = value;
            } 
        }
        // Gets the _y private variable. Setting will also set the _position.Y variable
        public float Y {
            get => _y; 
            set {
                _y = value;
                _position.Y = value;
            } 
        }
        // Gets the _roation private variable
        public float Rotation { 
            get => _rotation;
            set => _rotation = value; 
        }
        // Gets the _scale private variable
        public int Scale { 
            get => _scale; 
            set => _scale = value; 
        }
        #endregion

        #region Constructors
        // Initializes all variables in the transform to be 0, except for scale, which is default 1
        public Transform() {
            _position = Vector2.Zero;
            _x = 0f;
            _y = 0f;
            _rotation = 0f;
            _scale = 1;
        }

        // Initializes all variables to the specified value passed in to the constructor
        public Transform(Vector2 position, float rotation, int scale) {
            _position = position;
            _x = _position.X;
            _y = _position.Y;
            _rotation = rotation;
            _scale = scale;
        }

        // Initializes all variables to the other transform's variables
        public Transform(Transform other) {
            _position = other.Position;
            _x = other.X;
            _y = other.Y;
            _rotation = other.Rotation;
            _scale = other.Scale;
        }
        #endregion
    }

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
            if(texture != null) {
                _width = texture.Width;
                _height = texture.Height;
            } else {
                _width = _height = 0;
            }

        }
        #endregion
    }
        
}
