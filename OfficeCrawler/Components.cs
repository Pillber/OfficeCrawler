using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;



namespace OfficeCrawler {
    
    /*
     * Drawing
     *  -Texture, positioning
     * positioning
     *  -x and y, depth/layer?
     * movement
     *  -velocity handling, positioning
     */

    public class TransformComponent {
        Vector2 position;
        int layer;


    }
   

    public class MovementComponent {
        Vector2 velocity;
        Vector2 position;
    }

    public class DrawingComponent {
        TransformComponent transform;
        Texture2D texture;

        public void Draw(SpriteBatch spriteBatch) {

        }
    }
}
