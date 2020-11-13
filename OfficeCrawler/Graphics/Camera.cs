using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OfficeCrawler.Graphics {
    public class Camera {

        private Vector2 _position;
        private int _scale;
        private Matrix _transformMatrix;
        private Viewport _viewport;

        public Vector2 Position {
            get => _position;
            set => _position = value;
        }

        public int Scale {
            get => _scale;
            set => _scale = value;
        }

        public Matrix TransformationMatrix {
            get => _transformMatrix;
        }

        public Camera(Viewport viewport) {
            _viewport = viewport;
        }





    }
}
