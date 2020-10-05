using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace OfficeCrawler {
    class Enemy {
        //add childs classes for each different type of enemy

        //PRIVATE VARIABLES
        private Texture2D sprite;
        private Vector2 position;
        private Color currentColor = Color.IndianRed;
        private Rectangle BoundingBox;
        private readonly float moveSpeed = 2;
        private bool FacingRight;

        //PUBLIC VARIABLES
        public int DamageRecieved { get; set; }
        public bool Alive { get; set; }

        //CONSTRUCTOR
        public Enemy(Texture2D sprite, Vector2 position) {
            this.sprite = sprite;
            this.position = position;
            BoundingBox = new Rectangle((int)position.X - sprite.Width * OfficeCrawler.Scale / 2, (int)position.Y - sprite.Width * OfficeCrawler.Scale / 2, sprite.Width * OfficeCrawler.Scale, sprite.Height * OfficeCrawler.Scale);
            this.DamageRecieved = 0;
            Alive = true;

        }
        //Updates the enemy
        public void Update(GameTime gameTime, Player player) {
            if (position.X > player.pos.X) {
                position.X -= moveSpeed;
                FacingRight = false;
            } else if (position.X < player.pos.X) {
                position.X += moveSpeed;
                FacingRight = true;
            }
            if (position.Y > player.pos.Y) {
                position.Y -= moveSpeed;
            } else if (position.Y < player.pos.Y) {
                position.Y += moveSpeed;
            }
            BoundingBox.X = (int)position.X - sprite.Width * OfficeCrawler.Scale / 2;
            BoundingBox.Y = (int)position.Y - sprite.Width * OfficeCrawler.Scale / 2;
            if (player.insult != null) {
                if (BoundingBox.Intersects(player.insult.BoundingBox)) {
                    currentColor = Color.Black;
                    Alive = false;
                    player.insult = null;
                    player.Score();
                } else {
                    currentColor = Color.LightGray;
                }
            } else {
                currentColor = Color.LightGray;
            }
            if (BoundingBox.Intersects(player.BoundingBox)) {
                player.TakeDamage();
            }
        }

        //Draws the enemy on the screen
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(sprite, position, null, currentColor, 0, new Vector2(sprite.Width / 2, sprite.Height / 2), OfficeCrawler.Scale, (FacingRight) ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 1);
        }
    }
}
