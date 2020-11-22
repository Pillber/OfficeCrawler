using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OfficeCrawler {
    /// <summary>
    /// This class contains the basics for having an entity on the screen
    /// </summary>
    public class BaseEntity : IEntity {

        #region Private Variables
        /// <summary>
        /// A reference to the sprite renderer for this entity
        /// </summary>
        protected SpriteRenderer _spriteRenderer;
        /// <summary>
        /// A reference to the transform of this entity
        /// </summary>
        protected Transform _transform;
        /// <summary>
        /// A reference to the physics
        /// </summary>
        protected Physics _physics;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the _spriteRenderer private variable 
        /// </summary> 
        public SpriteRenderer SpriteRenderer {
            get => _spriteRenderer;
        }
        /// <summary>
        /// Gets the _transform of the entity 
        /// </summary>
        public Transform Transform {
            get => _transform;
        }
        /// <summary>
        /// Gets the Physics of the entity 
        /// </summary>
        public Physics Physics {
            get => _physics;
        }
        #endregion

        #region Constructor & Initializing
        public BaseEntity() { }

        /// <summary>
        /// Initializes the entity with a default Transform, a default SpriteRenderer, and default Physics
        /// </summary>
        public virtual void Initialize() {
            _transform = new Transform();
            _spriteRenderer = new SpriteRenderer(new Sprite(null, Color.White, 0, false), _transform);
            _physics = new Physics(null, _transform);
        }
        /// <summary>
        /// Loads the texture on to the sprite
        /// </summary>
        /// <param name="texture"></param>
        public virtual void LoadContent(Texture2D texture) {
            _spriteRenderer.Sprite.Texture = texture;
        }
        #endregion

        #region Drawing And Updating
        /// <summary>
        /// Draws entity using sprite renderer and gametime 
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Draw(GameTime gameTime) {
            _spriteRenderer.Draw(GlobalGraphics.SpriteBatch, gameTime);
        }
        /// <summary>
        /// Called every frame, updates entity 
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime) {
            //throw new System.NotImplementedException();
        }
        #endregion
    }
}