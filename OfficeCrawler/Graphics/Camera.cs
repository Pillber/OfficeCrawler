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

        private Vector2 _position;
        private int _scale;
        private Matrix _transformMatrix;

        public Vector2 Position {
            get => _position;
            set => _position = value;
        }

        public int Scale {
            get => _scale;
            set => _scale = value;
        }

        public Matrix TransformationMatrix {
            get => Matrix.CreateTranslation(-_position.X, -_position.Y, 0);
        }

        public Camera(Vector2 position) {
            _position = position;
            _scale = 2;
        }

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
    }
}
