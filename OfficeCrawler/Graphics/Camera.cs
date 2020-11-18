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
            get => Matrix.CreateTranslation(-_position.X, -_position.Y, 0);
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
        #endregion
    }
}
