using Microsoft.Xna.Framework;

namespace OfficeCrawler {
    public class Word : BaseEntity {


        public Word() {
            
        }

        public override void Initialize() {
            base.Initialize();
            Transform.Position = new Vector2(OfficeCrawler.Random.Next(GraphicsContext.VirtualWidth), OfficeCrawler.Random.Next(GraphicsContext.VirtualHeight));
        }

        public override void Draw(GameTime gameTime) {
            OfficeCrawler.GraphicsContext.DrawRect(Transform.Position, 20, 10, Color.Black);
        }
    }


}
