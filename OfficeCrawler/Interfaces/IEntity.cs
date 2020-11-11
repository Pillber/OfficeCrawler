using Microsoft.Xna.Framework;

namespace OfficeCrawler {
    interface IEntity {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}