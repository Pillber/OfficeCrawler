using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace OfficeCrawler {
    public class Player : BaseEntity {

        #region Constructor & Initializing
        /// <summary>
        /// Empty constructor for now; Constructs a player with the base of BaseEntity
        /// </summary>
        public Player() : base() {

        }
        #endregion

        #region Override Update & Physics
        /// <summary>
        /// Overrides the normal update method for entities to make it specific to the player 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime) {

            //Uses keyboard state and Physics move methods to move player
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.W)) {
                Physics.MoveY(-1);
            }
            if (keyState.IsKeyDown(Keys.D)) {
                Physics.MoveX(1);
            }
            if (keyState.IsKeyDown(Keys.A)) {
                Physics.MoveX(-1);
            }
            if (keyState.IsKeyDown(Keys.S)) {
                Physics.MoveY(1);
            }
            // Update Input
            // Update Physics
            // Update Position
            // Misc Updates

            Physics.ClampPosition();

            //Debug.WriteLine($"{_transform.X}, {_transform.Y}");
            base.Update(gameTime);
        }
        #endregion
    }
}