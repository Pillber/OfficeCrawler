using Microsoft.Xna.Framework;

namespace OfficeCrawler {
    interface IEntity {

        /// <summary>
        /// A method to be overridden by the implementing class of this interface
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime);

        /// <summary>
        /// A method to be overridden by the implementing class of this interface
        /// </summary>
        /// <param name="gameTime"></param>
        void Draw(GameTime gameTime);
    }
}