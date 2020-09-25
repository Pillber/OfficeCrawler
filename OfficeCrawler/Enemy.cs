﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace OfficeCrawler {
    class Enemy {
        //add childs classes for each different type of enemy

        private Texture2D sprite;
        private Vector2 position;
        private Color currentColor = Color.IndianRed;
        private Rectangle BoundingBox;
        private readonly float moveSpeed = 2;
        public bool Alive { get; set; }


        public Enemy(Texture2D sprite, Vector2 position) {
            this.sprite = sprite;
            this.position = position;
            BoundingBox = new Rectangle((int)position.X - sprite.Width * OfficeCrawler.Scale / 2, (int)position.Y - sprite.Width * OfficeCrawler.Scale / 2, sprite.Width * OfficeCrawler.Scale, sprite.Height * OfficeCrawler.Scale);
            Alive = true;
        }


        public void Update(GameTime gameTime, Player player) {
            if (position.X > player.pos.X) {
                position.X -= moveSpeed;
            } else if (position.X < player.pos.X) {
                position.X += moveSpeed;
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
                    currentColor = Color.DarkSlateGray;
                }
            } else {
                currentColor = Color.DarkSlateGray;
            }
            if (BoundingBox.Intersects(player.BoundingBox)) {
                player.TakeDamage();
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(sprite, position, null, currentColor, 0, new Vector2(sprite.Width / 2, sprite.Height / 2), OfficeCrawler.Scale, SpriteEffects.None, 1);
        }
    }
}