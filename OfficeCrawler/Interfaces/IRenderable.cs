using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OfficeCrawler {
    interface IRenderable {
        /// <summary>
        /// A method to be overridden by the implementing class of this interface
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}