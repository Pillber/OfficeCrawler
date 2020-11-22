using Microsoft.Xna.Framework;

namespace OfficeCrawler {

    public class Word : BaseEntity {
        /// <summary>
        /// Empty constructor; Constructs a word 
        /// </summary>
        public Word() {
            
        }
        /// <summary>
        /// Initializes the sprite of the word and sets up the position for the word 
        /// </summary>
        public override void Initialize() {
            base.Initialize();
            Transform.Position = new Vector2(OfficeCrawler.Random.Next(GlobalGraphics.VirtualWidth), OfficeCrawler.Random.Next(GlobalGraphics.VirtualHeight));
        }
        /// <summary>
        /// Draws a rectangle instead of a sprite 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime) {
            _spriteRenderer.DrawRect(GlobalGraphics.SpriteBatch, gameTime, 20, 10);
        }
    }


}
