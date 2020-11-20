using Microsoft.Xna.Framework;

namespace OfficeCrawler {

    public class Physics {

        private Collider _collider;
        private Transform _transform;

        public Transform Transform {
            get => _transform;
        }
        public Collider Collider {
            get => _collider;
        }


        public Physics(Collider collider, Transform transform) {
            _collider = collider;
            _transform = transform;
        }

        public void MoveX(float amount) {
            Transform.X += amount;
        }

        public void MoveY(float amount) {
            Transform.Y += amount;
        }

        public void ClampPosition() {
            //NEED to add player bounding box width and height adjustments!!!!!!

            //Screen edge X collision
            Transform.X = (Transform.X < 0) ? 0 : Transform.X;
            Transform.X = (Transform.X > GlobalGraphics.VirtualWidth) ? GlobalGraphics.VirtualWidth: Transform.X;

            //Screen edge y collision
            Transform.Y = (Transform.Y < 0) ? 0 : Transform.Y;
            Transform.Y = (Transform.Y > GlobalGraphics.VirtualHeight) ? GlobalGraphics.VirtualHeight : Transform.Y;
        }


    }
}


