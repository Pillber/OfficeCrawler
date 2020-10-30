using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OfficeCrawler {

    interface IEntity {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }

    public class BaseEntity : IEntity {
        protected SpriteRenderer _spriteRenderer;
        protected Transform _transform;

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            _spriteRenderer.Draw(spriteBatch, gameTime);
        }

        public virtual void Update(GameTime gameTime) {
            throw new System.NotImplementedException();
        }
    }

    public class Player : BaseEntity {

    }


}
