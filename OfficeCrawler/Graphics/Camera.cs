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
        // A vector2 representation of the position (x and y)
        private Vector2 _position;
        // A integer representation of the scale (unused, scaled later elsewhere)
        private int _scale;
        // A reference to a Transform to follow
        private Transform _transformToFollow;
        // A bool whether or not to follow the transform
        private bool _followTransform;
        // A bool whether or not to center the camera (change the origin to the center)
        private bool _centered;
        #endregion

        #region Properties
        // Gets the _position private variable
        public Vector2 Position {
            get => _position;
            set => _position = value;
        }

        // Gets the _scale private variable (unsused, scaled later elsewhere)
        public int Scale {
            get => _scale;
            set => _scale = value;
        }

        // Returns the matrix transformation used for translating sprites, based off of the _position
        public Matrix TransformationMatrix {
            get {

                if(_centered) {
                    return Matrix.CreateTranslation(-_position.X, -_position.Y, 0) * Matrix.CreateTranslation(GlobalGraphics.VirtualWidth / 2, GlobalGraphics.VirtualHeight / 2, 0);
                }
                return Matrix.CreateTranslation(-_position.X, -_position.Y, 0);
            }
        }

        // Gets and Sets the _transformFollow private variables
        public Transform TransformToFollow {
            get => _transformToFollow;
            set => _transformToFollow = value;
        }

        // Gets and Sets the bool to follow the transform
        public bool FollowTransform {
            get => _followTransform;
            set => _followTransform = value;
        }

        // Property to access the _centered private variable
        public bool Centered {
            get => _centered;
            set => _centered = value;
        }
        #endregion

        #region Constructor
        // Makes a camera, with starting position position
        public Camera(Vector2 position) {
            _position = position;
        }
        #endregion

        #region Methods
        //Updates the position of the camera (debug state right now)
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
