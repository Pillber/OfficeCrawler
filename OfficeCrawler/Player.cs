﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace OfficeCrawler {
    class Player {

        private Texture2D sprite;
        public Vector2 pos;
        private readonly float moveSpeed = 5;
        public bool moving;
        public string currentInsult;
        private SpriteFont insultFont;
        private KeyboardState previousKeyState;
        public Insult insult;
        private readonly string correctInsult = "no u";
        public int GameWidth { get;  set; }
        public int GameHeight { get; set; }
        public Rectangle BoundingBox;
        public int health;
        public bool Alive { get; set; }
        private float invincibleTime = -1f;
        private int scoreInt;


        public Player(Texture2D sprite, Vector2 pos) {
            this.sprite = sprite;
            this.pos = pos;
            moving = true;
            currentInsult = "no u";
            health = 5;
            Alive = true;
            scoreInt = 0;
        }

        public void SetTexture(Texture2D newTex) {
            this.sprite = newTex;
            BoundingBox = new Rectangle((int)pos.X - sprite.Width * OfficeCrawler.Scale / 2, (int)pos.Y - sprite.Width * OfficeCrawler.Scale / 2, sprite.Width * OfficeCrawler.Scale, sprite.Height * OfficeCrawler.Scale);
        }

        public Texture2D GetTexture() {
            return sprite;
        }

        public void AddFont(SpriteFont font) {
            this.insultFont = font;
        }

        public SpriteFont GetFont() {
            return insultFont;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            Vector2 insultSize = insultFont.MeasureString(currentInsult);
            if (invincibleTime > 0) {
                spriteBatch.Draw(sprite, pos, null, Color.Red, 0, new Vector2(sprite.Width / 2, sprite.Height / 2), OfficeCrawler.Scale, SpriteEffects.None, 1);
            } else {
                spriteBatch.Draw(sprite, pos, null, Color.White, 0, new Vector2(sprite.Width / 2, sprite.Height / 2), OfficeCrawler.Scale, SpriteEffects.None, 1);
            }
            if (currentInsult == correctInsult) {
                spriteBatch.DrawString(insultFont, currentInsult, new Vector2(GameWidth / 2 - insultSize.X / 2, GameHeight - insultSize.Y), Color.LawnGreen);
            } else {
                spriteBatch.DrawString(insultFont, currentInsult, new Vector2(GameWidth / 2 - insultSize.X / 2, GameHeight - insultSize.Y), Color.Black);
            }

            for (int i = 0; i < health; i++) {
                spriteBatch.Draw(sprite, new Vector2(sprite.Width * 2 * i + 5, 0), null, Color.Red, 0, Vector2.Zero, 2, SpriteEffects.None, 1);
            }
            
            if (insult != null) {
                insult.Draw(spriteBatch);
            }
            string score = "Score: " + scoreInt;
            Vector2 scoreSize = insultFont.MeasureString(score);
            spriteBatch.DrawString(insultFont, score, new Vector2(GameWidth / 2 - scoreSize.X / 2, 0), Color.Black);
        }

        public void Update(GameTime gameTime) {
            GetKeyBoardInput(gameTime);
            BoundingBox.X = (int)pos.X - sprite.Width * OfficeCrawler.Scale / 2;
            BoundingBox.Y = (int)pos.Y - sprite.Width * OfficeCrawler.Scale / 2;
            if (insult != null)
                insult.Update(this);
            if (health <= 0)
                Alive = false;

            if(invincibleTime != -1) {
                float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                invincibleTime -= elapsedTime;
                if(invincibleTime <= 0) {
                    invincibleTime = -1;
                }
            }
        }

        private void GetKeyBoardInput(GameTime gameTime) {
            KeyboardState keyState = Keyboard.GetState();
            if (moving) {
                if (keyState.IsKeyDown(Keys.W)) {
                    pos.Y -= moveSpeed;
                }
                if (keyState.IsKeyDown(Keys.A)) {
                    pos.X -= moveSpeed;
                }
                if (keyState.IsKeyDown(Keys.S)) {
                    pos.Y += moveSpeed;
                }
                if (keyState.IsKeyDown(Keys.D)) {
                    pos.X += moveSpeed;
                }
                if (insult == null && currentInsult == correctInsult) {
                    if (keyState.IsKeyDown(Keys.I)) {
                        insult = new Insult(pos, sprite, 5, 0, 1);
                        currentInsult = string.Empty;
                    } else if (keyState.IsKeyDown(Keys.J)) {
                        insult = new Insult(pos, sprite, 5, 1, 0);
                        currentInsult = string.Empty;
                    } else if (keyState.IsKeyDown(Keys.K)) {
                        insult = new Insult(pos, sprite, 5, 0, -1);
                        currentInsult = string.Empty;
                    } else if (keyState.IsKeyDown(Keys.L)) {
                        insult = new Insult(pos, sprite, 5, -1, 0);
                        currentInsult = string.Empty;
                    }
                    /*
                    else if(keyState.IsKeyDown(Keys.U)) {
                        insult = new Insult(pos, sprite, 5, 1, 1);
                        currentInsult = string.Empty;
                    } else if (keyState.IsKeyDown(Keys.O)) {
                        insult = new Insult(pos, sprite, 5, -1, 1);
                        currentInsult = string.Empty;
                    } else if (keyState.IsKeyDown(Keys.N)) {
                        insult = new Insult(pos, sprite, 5, 1, -1);
                        currentInsult = string.Empty;
                    } else if (keyState.IsKeyDown(Keys.OemPeriod)) {
                        insult = new Insult(pos, sprite, 5, -1, -1);
                        currentInsult = string.Empty;
                    }
                    */
                }
            }
            if(keyState.IsKeyDown(Keys.Enter) && previousKeyState.IsKeyUp(Keys.Enter)) {
                moving = !moving;
            }
            previousKeyState = keyState;
        }

        public void GetTyping(object sender, TextInputEventArgs e) {
            if(!moving) {
                char c = e.Character;
                switch(c) {
                    case '\b':
                        if (currentInsult.Length > 0)
                            currentInsult = currentInsult.Substring(0, currentInsult.Length - 1);
                        break;
                    case '\r':
                    case '\n':
                        //skip so enter doesn't cause truble.
                        break;
                    default:
                        currentInsult += c;
                        break;
                }
                
            }
        }

        public void TakeDamage() {
            if(invincibleTime == -1f) {
                invincibleTime = 1f;
                health--;
            }

        }

        public void PromptReset(SpriteBatch spriteBatch) {
            string message = "Press Space to restart";
            Vector2 stringSize = insultFont.MeasureString(message);
            spriteBatch.DrawString(insultFont, message, new Vector2((GameWidth + stringSize.X) / 2, (GameHeight + stringSize.Y) / 2), Color.Black);

        }

        public void Score() {
            this.scoreInt++;
        }
    }

    class Insult {
        public Vector2 position;
        private Texture2D texture;
        private float speed;
        private float xMovement;
        private float yMovement;
        public Rectangle BoundingBox;

        public Insult(Vector2 position, Texture2D texture, float speed, float xMovement, float yMovement) {
            this.position = position;
            this.speed = speed;
            this.texture = texture;
            this.xMovement = xMovement;
            this.yMovement = yMovement;
            BoundingBox = new Rectangle((int) position.X, (int) position.Y, texture.Width, texture.Height);
        }


        public void Update(Player player) {
            BoundingBox.X = (int) position.X;
            BoundingBox.Y = (int) position.Y;
            if (position.X < 0 || position.Y < 0 || position.X > player.GameWidth || position.Y > player.GameHeight) {
                player.insult = null;
            }

            position.X -= xMovement * speed;
            position.Y -= yMovement * speed;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
