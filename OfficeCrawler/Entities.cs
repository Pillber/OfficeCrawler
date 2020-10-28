using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace OfficeCrawler {

    public class Entity : DrawableGameComponent {
        public Entity(Game game) : base(game) {

        }

        public override void Draw(GameTime gameTime) {
            Debug.WriteLine("Drawing");
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime) {
            Debug.WriteLine("Update");
            base.Update(gameTime);
        }
    }

    public class Player : Entity {

        public Player(Game game) : base(game) {

        }

        public override void Draw(GameTime gameTime) {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }
    }
}
