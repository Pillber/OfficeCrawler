using Microsoft.Xna.Framework;

namespace OfficeCrawler {

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
}