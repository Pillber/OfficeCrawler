using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace OfficeCrawler {
    class Player {

        private Texture2D sprite;
        private Vector2 pos;
        private readonly float moveSpeed = 5;
        public bool moving;
        public string currentInsult;
        private SpriteFont insultFont;
        private KeyboardState previousKeyState;
        public Insult insult;
        private readonly string correctInsult = "no u";
        public int GameWidth { get;  set; }
        public int GameHeight { get; set; }
        

        public Player(Texture2D sprite, Vector2 pos) {
            this.sprite = sprite;
            this.pos = pos;
            moving = true;
            currentInsult = "no u";
        }

        public void SetTexture(Texture2D newTex) {
            this.sprite = newTex;
        }

        public Texture2D GetTexture() {
            return sprite;
        }

        public void AddFont(SpriteFont font) {
            this.insultFont = font;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            Vector2 insultSize = insultFont.MeasureString(currentInsult);
            spriteBatch.Draw(sprite, pos, null, Color.White, 0, new Vector2(sprite.Width / 2, sprite.Height / 2), OfficeCrawler.Scale, SpriteEffects.None, 1);
            spriteBatch.DrawString(insultFont, currentInsult, new Vector2(GameWidth / 2 - insultSize.X / 2, GameHeight - insultSize.Y), Color.Black);
            if(insult != null) {
                insult.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime) {
            GetKeyBoardInput(gameTime);
            if (insult != null)
                insult.Update(this);
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
                if (insult == null) {
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
                    } else if(keyState.IsKeyDown(Keys.U)) {
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
                    default:
                        currentInsult += c;
                        break;
                }
                
            }
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
