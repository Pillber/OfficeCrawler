using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace OfficeCrawler {
    class Player {

        private Texture2D sprite;
        private Vector2 pos;
        private readonly float moveSpeed = 5;
        public bool moving;
        public string currentInsult;
        private SpriteFont insultFont;
        private MouseState previousMouseState;
        public Insult insult;
        private string correctInsult = "your stupid lol";

        public Player(Texture2D sprite, Vector2 pos) {
            this.sprite = sprite;
            this.pos = pos;
            moving = true;
            currentInsult = "no u";
        }

        public void SetTexture(Texture2D newTex) {
            this.sprite = newTex;
        }

        public void AddFont(SpriteFont font) {
            this.insultFont = font;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(sprite, pos, Color.White);
            spriteBatch.DrawString(insultFont, currentInsult, Vector2.Zero, Color.Black);
            if(insult != null) {
                insult.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime) {
            GetKeyBoardInput(gameTime);
            GetMouseInput();
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
            }
        }

        private void GetMouseInput() {
            MouseState mouseState = Mouse.GetState();
            if(mouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton != ButtonState.Pressed) {
                moving = !moving;
            }
            if(moving && currentInsult == correctInsult) {
                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton != ButtonState.Pressed) {
                    insult = new Insult(pos, sprite, 2, new Vector2(mouseState.X, mouseState.Y));
                    correctInsult = string.Empty;
                }
                    
            }
            previousMouseState = mouseState;
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
        private Vector2 position;
        private Texture2D texture;
        private float speed;
        private float xMovement;
        private float yMovement;

        public Insult(Vector2 position, Texture2D texture, float speed, Vector2 mousePos) {
            this.position = position;
            this.speed = speed;
            this.texture = texture;

            xMovement = (position.X > mousePos.X) ? 1 : -1;
            yMovement = (position.Y > mousePos.Y) ? 1 : -1;



        }


        public void Update(Player player) {
            if(position.X < 0 || position.Y < 0) {
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
