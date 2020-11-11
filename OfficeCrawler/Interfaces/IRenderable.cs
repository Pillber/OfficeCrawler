using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OfficeCrawler {
    interface IRenderable {
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}