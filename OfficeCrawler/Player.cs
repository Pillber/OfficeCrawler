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
        private KeyboardState previousKeyboardState;

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
            if(!moving) {
                spriteBatch.DrawString(insultFont, currentInsult, Vector2.Zero, Color.Black);
            }
        }

        public void Update(GameTime gameTime) {
            GetKeyBoardInput(gameTime);
            GetMouseInput();
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
            } else {
                Keys[] enteredKeys = keyState.GetPressedKeys();
                if(enteredKeys.Length > 0) {
                    Keys enteredKey = keyState.GetPressedKeys()[0];
                    if (enteredKey == Keys.Back) {
                        if(currentInsult.Length > 1) {
                            currentInsult = currentInsult.Substring(0, currentInsult.Length - 2);
                        }
                    } else if (enteredKey == Keys.Space) {
                        currentInsult += " ";
                    } else {
                        currentInsult += enteredKey.ToString().ToLower();
                    }
                }
            }
            previousKeyboardState = keyState;
        }

        private void GetMouseInput() {
            MouseState mouseState = Mouse.GetState();
            if(mouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton != ButtonState.Pressed) {
                moving = !moving;
            }
            previousMouseState = mouseState;
        }

        public void GetTyping(object sender, TextInputEventArgs e) {
            //Nvorbis
            var pressedKey = e.Key;
            Debug.Print(pressedKey.ToString());
        }

    }
}
