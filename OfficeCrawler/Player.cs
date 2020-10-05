using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace OfficeCrawler {
    class Player {

        //PRIVATE VARIABLES
        private Texture2D sprite;
        private readonly float moveSpeed = 5;
        private SpriteFont insultFont;
        private KeyboardState previousKeyState;
        private readonly InsultString[] correctInsults = new InsultString[3];
        private float invincibleTime = -1f;
        private int scoreInt;
        private bool FacingRight;

        //PUBLIC VAIRABLES
        public Vector2 pos;
        public bool moving;
        public string currentInsult;
        public Insult insult;
        public int GameWidth { get; set; }
        public int GameHeight { get; set; }
        public Rectangle BoundingBox;
        public int health;
        public bool Alive { get; set; }

        //CONSTRUCTOR
        public Player(Texture2D sprite, Vector2 pos) {
            this.sprite = sprite;
            this.pos = pos;
            moving = true;
            currentInsult = "no u";
            health = 5;
            Alive = true;
            scoreInt = 0;
            correctInsults[0] = new InsultString("no u", 1f, 6);
            correctInsults[1] = new InsultString("your stupid lol", 5f, 6);
            correctInsults[2] = new InsultString("your mom you're dad", 10f, 15);
        }

        //Sets the texture of the player
        public void SetTexture(Texture2D newTex) {
            this.sprite = newTex;
            BoundingBox = new Rectangle((int)pos.X - sprite.Width * OfficeCrawler.Scale / 2, (int)pos.Y - sprite.Width * OfficeCrawler.Scale / 2, sprite.Width * OfficeCrawler.Scale, sprite.Height * OfficeCrawler.Scale);
        }

        //Returns the texture of the player
        public Texture2D GetTexture() {
            return sprite;
        }

        //Adds a font to the insult
        public void AddFont(SpriteFont font) {
            this.insultFont = font;
        }

        //Returns the font of the insult
        public SpriteFont GetFont() {
            return insultFont;
        }

        //Displays everything on the screen for the player
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            Vector2 insultSize = insultFont.MeasureString(currentInsult);
            if (invincibleTime > 0) {
                spriteBatch.Draw(sprite, pos, null, Color.Red, 0, new Vector2(sprite.Width / 2, sprite.Height / 2), OfficeCrawler.Scale, (FacingRight) ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 1);
            } else {
                spriteBatch.Draw(sprite, pos, null, Color.White, 0, new Vector2(sprite.Width / 2, sprite.Height / 2), OfficeCrawler.Scale, (FacingRight) ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 1);
            }
            if (InsultIsCorrect()){
                spriteBatch.DrawString(insultFont, currentInsult, new Vector2(GameWidth / 2 - insultSize.X / 2, GameHeight - insultSize.Y), Color.LawnGreen);
            } else {
                spriteBatch.DrawString(insultFont, currentInsult, new Vector2(GameWidth / 2 - insultSize.X / 2, GameHeight - insultSize.Y), Color.Black);
            }

            for (int i = 0; i < health; i++) {
                spriteBatch.Draw(sprite, new Vector2(sprite.Width * 2 * i + 5, 0), null, Color.Red, 0, Vector2.Zero, 2, SpriteEffects.None, 1);
            }

            for(int i = 0; i < correctInsults.Length; i++) {
                Vector2 stringSize = insultFont.MeasureString(correctInsults[i].Name);
                spriteBatch.DrawString(insultFont, correctInsults[i].Name, new Vector2(GameWidth - stringSize.X - 10, i * stringSize.Y), (correctInsults[i].Name.Contains(currentInsult) && currentInsult != string.Empty) ? Color.LawnGreen : Color.DimGray);
            }
            
            if (insult != null) {
                insult.Draw(spriteBatch);
            }
            string score = "Score: " + scoreInt;
            Vector2 scoreSize = insultFont.MeasureString(score);
            spriteBatch.DrawString(insultFont, score, new Vector2(GameWidth / 2 - scoreSize.X / 2, 0), Color.Black);
        }

        //Check if the insult typed is a valid insult
        private bool InsultIsCorrect() {
            foreach(InsultString insult in correctInsults) {
                if (currentInsult == insult.Name)
                    return true;
            }
            return false;
        }

        //Updates the player 
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

        //Gets keyboard input for the typed insult
        private void GetKeyBoardInput(GameTime gameTime) {
            KeyboardState keyState = Keyboard.GetState();
            if (moving) {
                if (keyState.IsKeyDown(Keys.W)) {
                    pos.Y -= moveSpeed;
                }
                if (keyState.IsKeyDown(Keys.A)) {
                    pos.X -= moveSpeed;
                    FacingRight = false;
                }
                if (keyState.IsKeyDown(Keys.S)) {
                    pos.Y += moveSpeed;
                }
                if (keyState.IsKeyDown(Keys.D)) {
                    pos.X += moveSpeed;
                    FacingRight = true;
                }
                if (insult == null && InsultIsCorrect()) {
                    int speed = 5;
                    float damage = 1;
                    foreach(InsultString insult in correctInsults) {
                        if (currentInsult == insult.Name) {
                            speed = insult.Speed;
                            damage = insult.Damage;
                            break;
                        }
                    }

                    if (keyState.IsKeyDown(Keys.I)) {
                        insult = new Insult(pos, sprite, speed, 0, 1);
                        currentInsult = string.Empty;
                    } else if (keyState.IsKeyDown(Keys.J)) {
                        insult = new Insult(pos, sprite, speed, 1, 0);
                        currentInsult = string.Empty;
                    } else if (keyState.IsKeyDown(Keys.K)) {
                        insult = new Insult(pos, sprite, speed, 0, -1) ;
                        currentInsult = string.Empty;
                    } else if (keyState.IsKeyDown(Keys.L)) {
                        insult = new Insult(pos, sprite, speed, -1, 0);
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

        //Gets the keys being pressed
        public void GetTyping(object sender, TextInputEventArgs e) {
            if(!moving) {
                char c = e.Character;
                if (e.Key == Keys.Escape)
                    return;
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

        //Allows player to take damage
        public void TakeDamage() {
            if(invincibleTime == -1f) {
                invincibleTime = 1f;
                health--;
            }

        }

        //Asks the user if they want to reset
        public void PromptReset(SpriteBatch spriteBatch) {
            string message = "Press Space to restart";
            Vector2 stringSize = insultFont.MeasureString(message);
            spriteBatch.DrawString(insultFont, message, new Vector2((GameWidth + stringSize.X) / 2, (GameHeight + stringSize.Y) / 2), Color.Black);

        }

        //Increases the score by one
        public void Score() {
            this.scoreInt++;
        }
    }

    //STRUCTURE OF INSULT STRING
    struct InsultString {

        //PUBLIC VARIABLES
        public string Name;
        public float Damage;
        public int Speed;

        //CONSTRUCTOR
        public InsultString(string name, float damage, int speed) {
            Name = name;
            Damage = damage;
            Speed = speed;
        }
    }

    //CLASS OF THE INSULT
    class Insult {

        //PRIVATE VARIABLES
        private Texture2D texture;
        private float speed;
        private float xMovement;
        private float yMovement;

        //PUBLIC VARIABLES
        public Vector2 position;
        public Rectangle BoundingBox;

        //CONSTRUCTOR
        public Insult(Vector2 position, Texture2D texture, float speed, float xMovement, float yMovement) {
            this.position = position;
            this.speed = speed;
            this.texture = texture;
            this.xMovement = xMovement;
            this.yMovement = yMovement;
            BoundingBox = new Rectangle((int) position.X, (int) position.Y, texture.Width, texture.Height);
        }

        //Updates the insult
        public void Update(Player player) {
            BoundingBox.X = (int) position.X;
            BoundingBox.Y = (int) position.Y;
            if (position.X < 0 || position.Y < 0 || position.X > player.GameWidth || position.Y > player.GameHeight) {
                player.insult = null;
            }

            position.X -= xMovement * speed;
            position.Y -= yMovement * speed;
        }

        //Draws the insult on the screen
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
