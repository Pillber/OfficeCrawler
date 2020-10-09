using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using System.Diagnostics;

namespace OfficeCrawler {
    class Player {

        #region Private Variables
        //PRIVATE VARIABLES
        private Texture2D sprite;
        private readonly float moveSpeed = 10;
        private SpriteFont insultFont;
        private KeyboardState previousKeyState;
        private readonly InsultString[] correctInsults = new InsultString[3];
        private float invincibleTime = -1f;
        private int scoreInt;
        private bool FacingRight;
        private Obstacle[] obstacles = new Obstacle[1];
        #endregion

        #region Public Variables
        //PUBLIC VARIABLES
        public Vector2 pos;
        public bool moving;
        public string currentInsult;
        public Insult insult;
        public int GameWidth { get; set; }
        public int GameHeight { get; set; }
        public Rectangle BoundingBox;
        public int health;
        public bool Alive { get; set; }
        #endregion

        #region Initialization
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
            obstacles[0] = new Obstacle(sprite, new Vector2(200, 200));
        }

        //Returns the texture of the player
        public Texture2D GetTexture() {
            return sprite;
        }
        //Adds a font to the insult  
        public void AddFont(SpriteFont font) {
            this.insultFont = font;
        }
        //Retruns the font of the insult
        public SpriteFont GetFont() {
            return insultFont;
        }
        #endregion


        #region Update and Draw
        //Drawing player, enemies, health bar, current insult, available insults, and score every frame
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            foreach (Obstacle ob in obstacles) {
                if (ob != null) {
                    ob.Draw(spriteBatch);
                }
            }
            Vector2 insultSize = insultFont.MeasureString(currentInsult);
            if (invincibleTime > 0) {
                spriteBatch.Draw(sprite, pos, null, Color.Red, 0, new Vector2(sprite.Width / 2, sprite.Height / 2), OfficeCrawler.Scale, (FacingRight) ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 1);
            } else {
                spriteBatch.Draw(sprite, pos, null, Color.White, 0, new Vector2(sprite.Width / 2, sprite.Height / 2), OfficeCrawler.Scale, (FacingRight) ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 1);
            }

            //Loop through correctInsults - first one with currentInsult as prefix is shadowed
            foreach (InsultString insult in correctInsults) {
                if (insult.Name.StartsWith(currentInsult)) {
                    spriteBatch.DrawString(insultFont, insult.Name, new Vector2(GameWidth / 2 - insultSize.X / 2, GameHeight - insultSize.Y), Color.Gray);
                    break;
                }
            }

            //Draw insult at the bottom of the screen
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
                spriteBatch.DrawString(insultFont, correctInsults[i].Name, new Vector2(GameWidth - stringSize.X - 10, i * stringSize.Y), (correctInsults[i].Name.StartsWith(currentInsult) && currentInsult != string.Empty) ? Color.LawnGreen : Color.DimGray);
            }
            
            if (insult != null) {
                insult.Draw(spriteBatch);
            }
            string score = "Score: " + scoreInt;
            Vector2 scoreSize = insultFont.MeasureString(score);
            spriteBatch.DrawString(insultFont, score, new Vector2(GameWidth / 2 - scoreSize.X / 2, 0), Color.Black);
        }

        //Called every frame. Gets keyboard input, sets player bounding box, updates insult, and invincibility frames
        public void Update(GameTime gameTime) {
            GetKeyBoardInput(gameTime);
            BoundingBox.X = (int)pos.X - sprite.Width * OfficeCrawler.Scale / 2;
            BoundingBox.Y = (int)pos.Y - sprite.Width * OfficeCrawler.Scale / 2;



            /*
            foreach(Obstacle ob in obstacles) { 
                //if the right side of the player is in the left side of the box regardless of y pos
                if(BoundingBox.X + BoundingBox.Width > ob.BoundingBox.X) {
                    if(!((BoundingBox.Y < ob.BoundingBox.Y + ob.BoundingBox.Height && BoundingBox.Y + BoundingBox.Height > ob.BoundingBox.Y + ob.BoundingBox.Height) || 
                        (BoundingBox.Y + BoundingBox.Height > ob.BoundingBox.Y && BoundingBox.Y > ob.BoundingBox.Y))) {
                       
                    } else {
                        pos.X = ob.BoundingBox.X - BoundingBox.Width;
                    }
                    
                }
                else if(BoundingBox.X < ob.BoundingBox.X + ob.BoundingBox.Width) {
                    if (BoundingBox.Y < ob.BoundingBox.Y + ob.BoundingBox.Height) {

                    } else if (BoundingBox.Y + BoundingBox.Height > ob.BoundingBox.Y) {

                    } else {
                        pos.X = ob.BoundingBox.X + ob.BoundingBox.Width;
                    }
                    
                }
                
            }
            */
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

        //Gets keyboard input for movement and firing the insult
        private void GetKeyBoardInput(GameTime gameTime) {
            KeyboardState keyState = Keyboard.GetState();
            if (moving) {

                /*  After receaving player movement input - Checks if they would move outside screen
                 *      Check if future position of player is clipping with obstacle
                 *      if yes - only move player the distance between the player and the obstcale
                 *      if not - move the player the full movement speed
                 * 
                 * 
                 */

                if (keyState.IsKeyDown(Keys.E) && BoundingBox.Y-1 > 0) {
                    foreach (Obstacle ob in obstacles) {
                        if ((pos.Y - moveSpeed < ob.BoundingBox.Y + ob.BoundingBox.Height && pos.Y - moveSpeed - sprite.Height < ob.BoundingBox.Y) && (pos.X < ob.BoundingBox.X + ob.BoundingBox.Width && pos.X > ob.BoundingBox.X)) {
                            Debug.WriteLine("Reached E");
                            pos.Y += ob.BoundingBox.Y - pos.Y;
                        }
                        else {
                            pos.Y -= moveSpeed;
                        }
                    }
                        
                }
                if (keyState.IsKeyDown(Keys.S) && BoundingBox.X-1 > 0) {
                    pos.X -= moveSpeed;
                    FacingRight = false;
                }
                if (keyState.IsKeyDown(Keys.D) && BoundingBox.Y+1+(sprite.Width * OfficeCrawler.Scale) < GameHeight) {
                    pos.Y += moveSpeed;
                }
                if (keyState.IsKeyDown(Keys.F) && BoundingBox.X+1+(sprite.Height * OfficeCrawler.Scale) < GameWidth) {
                    /*
                     * if pos.X+movespeed is in an obstacle --> pos.X += obstacle.X - pos.X
                     * if not --> move normally
                     */
                    foreach(Obstacle ob in obstacles) {
                        float futurePos = pos.X + moveSpeed;
                        if((futurePos + (OfficeCrawler.Scale * sprite.Width/2.0) > ob.BoundingBox.X && futurePos - (OfficeCrawler.Scale * sprite.Width / 2.0) < ob.BoundingBox.X + ob.BoundingBox.Width) && (pos.Y - (OfficeCrawler.Scale * sprite.Height/2.0) < ob.BoundingBox.Y + ob.BoundingBox.Height && pos.Y + (OfficeCrawler.Scale * sprite.Height/2.0) > ob.BoundingBox.Y)) {
                            pos.X += ob.BoundingBox.X - pos.X;
                        } else {
                            pos.X += moveSpeed;
                            FacingRight = true;
                        }
                    }
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
                        insult = new Insult(pos, sprite, speed, 0, 1, damage);
                        currentInsult = string.Empty;
                    } else if (keyState.IsKeyDown(Keys.J)) {
                        insult = new Insult(pos, sprite, speed, 1, 0, damage);
                        currentInsult = string.Empty;
                    } else if (keyState.IsKeyDown(Keys.K)) {
                        insult = new Insult(pos, sprite, speed, 0, -1, damage) ;
                        currentInsult = string.Empty;
                    } else if (keyState.IsKeyDown(Keys.L)) {
                        insult = new Insult(pos, sprite, speed, -1, 0, damage);
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

        //Gets the keys being pressed to type out the insult
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
        #endregion

        #region Misc
        //Check if the insult typed is a valid insult
        private bool InsultIsCorrect() {
            foreach (InsultString insult in correctInsults) {
                if (currentInsult == insult.Name)
                    return true;
            }
            return false;
        }

        //If the player does not have IFrames then take damage
        public void TakeDamage() {
            if(invincibleTime == -1f) {
                invincibleTime = 1f;
                health--;
            }

        }

        //Called after player health falls below 0, prompts player for reset
        public void PromptReset(SpriteBatch spriteBatch) {
            string message = "Press Space to restart";
            Vector2 stringSize = insultFont.MeasureString(message);
            spriteBatch.DrawString(insultFont, message, new Vector2((GameWidth + stringSize.X) / 2, (GameHeight + stringSize.Y) / 2), Color.Black);

        }

        //Increase the score by one
        public void Score() {
            this.scoreInt++;
        }
        #endregion
    }

    #region InsultString
    //STRUCTURE OF THE INSULT STRING
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
    #endregion

    #region Insult Class
    //INSULT CLASS
    class Insult {
        //PRIVATE VARIABLES 
        private Texture2D texture;
        private float speed;
        private float xMovement;
        private float yMovement;

        //PUBLIC VARIABLES
        public Vector2 position;
        public Rectangle BoundingBox;
        public float Damage;

        //CONSTRUCTOR
        public Insult(Vector2 position, Texture2D texture, float speed, float xMovement, float yMovement, float Damage) {
            this.position = position;
            this.speed = speed;
            this.texture = texture;
            this.xMovement = xMovement;
            this.yMovement = yMovement;
            BoundingBox = new Rectangle((int) position.X, (int) position.Y, texture.Width, texture.Height);
            this.Damage = Damage;
        }

        //Called every frame, sets bounding box, checks for player collision, moves insult
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
    #endregion
}
