using Microsoft.Xna.Framework;

namespace OfficeCrawler {

    public class Physics {

        #region Private Variables
        private Collider _collider;
        private Transform _transform;
        #endregion

        #region Properties
        /// <summary>
        /// A reference to the _transform
        /// </summary>
        public Transform Transform {
            get => _transform;
        }
        /// <summary>
        /// A reference to the _collider
        /// </summary>
        public Collider Collider {
            get => _collider;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructs physics based on a Collider and Transform
        /// </summary>
        /// <param name="collider"></param>
        /// <param name="transform"></param>
        public Physics(Collider collider, Transform transform) {
            _collider = collider;
            _transform = transform;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Move the entity in the x direction
        /// </summary>
        /// <param name="amount">Float amount to move</param>
        public void MoveX(float amount) {
            Transform.X += amount;
        }

        /// <summary>
        /// Move the entity in the y direction
        /// </summary>
        /// <param name="amount">Float amount to move</param>
        public void MoveY(float amount) {
            Transform.Y += amount;
        }

        /// <summary>
        /// Clamps position based on the GlobalGraphics.VirtualWidth & GlobalGraphics.VirtualHeight
        /// </summary>
        public void ClampPosition() {
            //NEED to add player bounding box width and height adjustments!!!!!!

            //Screen edge X collision
            Transform.X = (Transform.X < 0) ? 0 : Transform.X;
            Transform.X = (Transform.X > GlobalGraphics.VirtualWidth) ? GlobalGraphics.VirtualWidth: Transform.X;

            //Screen edge y collision
            Transform.Y = (Transform.Y < 0) ? 0 : Transform.Y;
            Transform.Y = (Transform.Y > GlobalGraphics.VirtualHeight) ? GlobalGraphics.VirtualHeight : Transform.Y;
        }
        #endregion

    }
}


