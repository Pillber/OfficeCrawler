using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace OfficeCrawler {
    class Enemy {
        //add childs classes for each different type of enemy

        //PRIVATE VARIABLES
        private Texture2D sprite;
        private Vector2 position;
        private Color currentColor = Color.IndianRed;
        private Rectangle BoundingBox;
        private readonly float moveSpeed = 3;
        private bool FacingRight;

        //PUBLIC VARIABLES
        private float MaxHealth { get; set; }
        public float DamageRecieved { get; set; }
        public bool Alive { get; set; }
        

        //CONSTRUCTOR
        public Enemy(Texture2D sprite, Vector2 position, float MaxHealth = 2) {
            this.sprite = sprite;
            this.position = position;
            BoundingBox = new Rectangle((int)position.X - sprite.Width * OfficeCrawler.Scale / 2, (int)position.Y - sprite.Width * OfficeCrawler.Scale / 2, sprite.Width * OfficeCrawler.Scale, sprite.Height * OfficeCrawler.Scale);
            this.DamageRecieved = 0;
            this.MaxHealth = MaxHealth;
            Alive = true;
        }

        //public Enemy(Texture2D sprite, Vector2 position, float MaxHealth) {
        //    this.sprite = sprite;
        //    this.position = position;
        //    BoundingBox = new Rectangle((int)position.X - sprite.Width * OfficeCrawler.Scale / 2, (int)position.Y - sprite.Width * OfficeCrawler.Scale / 2, sprite.Width * OfficeCrawler.Scale, sprite.Height * OfficeCrawler.Scale);
        //    this.DamageRecieved = 0;
        //    this.MaxHealth = MaxHealth;
        //    Alive = true;
        //}

        //Updates the enemy
        public void Update(GameTime gameTime, Player player) {
            //enemy movement 
            position += Vector2.Normalize(player.pos - this.position) * moveSpeed;
            //Defining a player box
            BoundingBox.X = (int)position.X - sprite.Width * OfficeCrawler.Scale / 2;
            BoundingBox.Y = (int)position.Y - sprite.Width * OfficeCrawler.Scale / 2;
            if (player.insult != null) {
                if (BoundingBox.Intersects(player.insult.BoundingBox)) {
                    //currentColor = Color.Black;
                    DamageRecieved += player.insult.Damage;
                    if(DamageRecieved >= MaxHealth) {
                        Alive = false;
                        player.Score();
                    }
                    player.insult = null;
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
