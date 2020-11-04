using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OfficeCrawler {

    interface IEntity {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }

    public class BaseEntity : IEntity {

        #region Private Variables
        // A reference to the sprite renderer for this entity
        protected SpriteRenderer _spriteRenderer;
        // A reference to the transform of this entity
        protected Transform _transform;
        // A reference to the physics
        protected Physics _physics;
        #endregion

        #region Properties
        // Gets the _spriteRenderer private variable
        public SpriteRenderer SpriteRenderer {
            get => _spriteRenderer;
        }
        // Gets the _transform of the entity
        public Transform Transform {
            get => _transform;
        }
        //Gets the Physics of the entity
        public Physics Physics {
            get => _physics;
        }
        #endregion

        #region Constructor & Initializing
        public BaseEntity() {}

        public virtual void Initialize() {
            _transform = new Transform();
            _spriteRenderer = new SpriteRenderer(new Sprite(null, Color.White, 0, false), _transform);
            _physics = new Physics(null, _transform);
        }

        public virtual void LoadContent(Texture2D texture) {
            _spriteRenderer.Sprite.Texture = texture;
        }
        #endregion

        #region Drawing And Updating
        // Draws entity using sprite renderer and gametime
        public virtual void Draw(GameTime gameTime) {
            OfficeCrawler.GraphicsContext.DrawSprite(_spriteRenderer, gameTime);
        }

        // Called every frame, updates entity
        public virtual void Update(GameTime gameTime) {
            //throw new System.NotImplementedException();
        }
        #endregion
    }

    public class Player : BaseEntity {

        #region Constructor & Initializing
        public Player() : base() {

        }
        #endregion

        #region Override Update & Physics
        public override void Update(GameTime gameTime) {

            //Uses keyboard state and Physics move methods to move player
            KeyboardState keyState = Keyboard.GetState();
            if(keyState.IsKeyDown(Keys.W)) {
                Physics.MoveY(-5);
            }
            if (keyState.IsKeyDown(Keys.D)) {
                Physics.MoveX(5);
            }
            if (keyState.IsKeyDown(Keys.A)) {
                Physics.MoveX(-5);
            }
            if(keyState.IsKeyDown(Keys.S)) {
                Physics.MoveY(5);
            }

            Physics.ClampPosition();

            // Update Input
            // Update Physics
            // Update Position
            // Misc Updates


            base.Update(gameTime);
        }
        #endregion
    }


}
