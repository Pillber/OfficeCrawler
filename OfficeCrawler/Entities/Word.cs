using Microsoft.Xna.Framework;

namespace OfficeCrawler {
    public class Word : BaseEntity {
        public Word() {
            
        }

        // Sets up the position for the word
        public override void Initialize() {
            base.Initialize();
            Transform.Position = new Vector2(OfficeCrawler.Random.Next(GlobalGraphics.VirtualWidth), OfficeCrawler.Random.Next(GlobalGraphics.VirtualHeight));
        }

        // Draws a rectangle instead of a sprite
        public override void Draw(GameTime gameTime) {
            _spriteRenderer.DrawRect(GlobalGraphics.SpriteBatch, gameTime, 20, 10);
        }
    }


}
