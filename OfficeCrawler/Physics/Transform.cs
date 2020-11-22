using Microsoft.Xna.Framework;

namespace OfficeCrawler {

    public class Transform {
        #region Private Variables
        /// <summary>
        /// A Vector2 representation of the x and y of this transform 
        /// </summary>
        private Vector2 _position;
        /// <summary>
        /// A float representation of the x value of this transform. Linked to the X value of _position. 
        /// </summary>
        private float _x;
        /// <summary>
        /// A float representation of the y value of this transform. Linked to the Y value of _position. 
        /// </summary>
        private float _y;
        /// <summary>
        /// A float representation of the rotation of this transform 
        /// </summary>
        private float _rotation;
        /// <summary>
        /// A float representation of the scale of this transformc
        /// </summary>
        private int _scale;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the _position private variable. Setting will also set the _x and _y variables. 
        /// </summary>
        public Vector2 Position {
            get => _position;
            set {
                _position = value;
                _x = value.X;
                _y = value.Y;
            }
        }
        /// <summary>
        /// Gets the _x private variable. Setting will also set the _position.X variable 
        /// </summary>
        public float X {
            get => _x;
            set {
                _x = value;
                _position.X = value;
            }
        }
        /// <summary>
        /// Gets the _y private variable. Setting will also set the _position.Y variable 
        /// </summary>
        public float Y {
            get => _y;
            set {
                _y = value;
                _position.Y = value;
            }
        }
        /// <summary>
        /// Gets the _roation private variable 
        /// </summary>
        public float Rotation {
            get => _rotation;
            set => _rotation = value;
        }
        /// <summary>
        /// Gets the _scale private variable 
        /// </summary>
        public int Scale {
            get => _scale;
            set => _scale = value;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a default Transform with all variables in the transform to be 0, except for scale, which is default 1
        /// </summary>
        public Transform() {
            _position = Vector2.Zero;
            _x = 0f;
            _y = 0f;
            _rotation = 0f;
            _scale = 1;
        }

        /// <summary>
        /// Initializes a Transform with specified values
        /// </summary>
        /// <param name="position">A Vector2 value representing the position</param>
        /// <param name="rotation">A float value representing the rotation</param>
        /// <param name="scale">An int value representing the scale</param>
        public Transform(Vector2 position, float rotation, int scale) {
            _position = position;
            _x = _position.X;
            _y = _position.Y;
            _rotation = rotation;
            _scale = scale;
        }

        /// <summary>
        /// Constructs a new Transform based on the values of another Transform
        /// </summary>
        /// <param name="other">Another Transform</param>
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