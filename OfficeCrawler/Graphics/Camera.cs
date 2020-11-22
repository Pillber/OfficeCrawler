using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OfficeCrawler {
    /*
     * World View -> Camera Translation -> RenderTarget2D -> Backbuffer
     * 
     * Camera Translates and renders to RenderTarget2D (without scale)
     * RenderTarget2D is of only virtual resolution size
     *  -Might have to cull things outside of RenderTarget
     * 
     * 
     */

    public class Camera {

        #region Private Variables
        /// <summary>
        /// A vector2 representation of the position (x and y) 
        /// </summary>
        private Vector2 _position;
        /// <summary>
        /// A integer representation of the scale (unused, scaled later elsewhere) 
        /// </summary>
        private int _scale;
        /// <summary>
        /// A reference to a Transform to follow 
        /// </summary>
        private Transform _transformToFollow;
        /// <summary>
        /// A bool whether or not to follow the transform 
        /// </summary>
        private bool _followTransform;
        /// <summary>
        /// A bool whether or not to center the camera (change the origin to the center) 
        /// </summary>
        private bool _centered;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the _position private variable 
        /// </summary>
        public Vector2 Position {
            get => _position;
            set => _position = value;
        }
        /// <summary>
        /// Gets the _scale private variable (unsused, scaled later elsewhere) 
        /// </summary>
        public int Scale {
            get => _scale;
            set => _scale = value;
        }
        /// <summary>
        /// Returns the matrix transformation used for translating sprites, based off of the _position 
        /// </summary>
        public Matrix TransformationMatrix {
            get {

                if(_centered) {
                    return Matrix.CreateTranslation(-_position.X, -_position.Y, 0) * Matrix.CreateTranslation(GlobalGraphics.VirtualWidth / 2, GlobalGraphics.VirtualHeight / 2, 0);
                }
                return Matrix.CreateTranslation(-_position.X, -_position.Y, 0);
            }
        }
        /// <summary>
        /// Gets and Sets the _transformFollow private variables 
        /// </summary>
        public Transform TransformToFollow {
            get => _transformToFollow;
            set => _transformToFollow = value;
        }
        /// <summary>
        /// Gets and Sets the bool to follow the transform 
        /// </summary>
        public bool FollowTransform {
            get => _followTransform;
            set => _followTransform = value;
        }
        /// <summary>
        /// Property to access the _centered private variable 
        /// </summary>
        public bool Centered {
            get => _centered;
            set => _centered = value;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Makes a camera, with starting position position 
        /// </summary>
        /// <param name="position"></param>
        public Camera(Vector2 position) {
            _position = position;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Updates the position of the camera (debug state right now) 
        /// </summary>
        public void Update() {
            if(_followTransform) {
                _position = _transformToFollow.Position;
            } else {
                KeyboardState keystate = Keyboard.GetState();
                if (keystate.IsKeyDown(Keys.Up)) {
                    _position.Y--;
                }
                if (keystate.IsKeyDown(Keys.Down)) {
                    _position.Y++;
                }
                if (keystate.IsKeyDown(Keys.Left)) {
                    _position.X--;
                }
                if (keystate.IsKeyDown(Keys.Right)) {
                    _position.X++;
                }
            }
        }
        #endregion
    }
}
