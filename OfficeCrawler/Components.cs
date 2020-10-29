using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace OfficeCrawler {
    
    /*
     * Sprite Renderer
     *  -Implement IRenderer
     *  -Sprite
     *      -Texture
     *      -Tint
     *      -Animation and Animation state
     *  -Draw
     *  -Transform
     *      -Reference to transform on entity, (0, 0) if null
     * Renderer Interface
     *  -virtual (abstract) Draw();
     * UI Renderer
     *  -Implements IRenderer
     *  -Blah, Blah, Blah
     * Transform (has to be object)
     *  -Position
     *  -Rotation
     *  -Scale
     * Physics
     *  -Collider
     *  -Update
     *  -Calculate collisions
     * InputListener - Interface/Abstract Class?
     *  -Switch inputlisteners depending on game state?
     *  -Listen for changes in the InputManager
     *  -Delegate methods for keydown, keyup, keyheld, ect.
     *  -Entity Inplements InputListener
     *      -InputLIstner.Silence to turn off input listener.
     * InputManager
     *  -Wrappings for Keyboard and possibly controller inputs
     *  -Event-Based
     *  
     * 
     * Entities will have references to each of them. access with "Player.SpriteRender.Draw();", "Enemy.Physics.DisableCollider = true;", "Player.SpriteRenderer.Sprite.Tint = Color.Red;"
     * 
     * public class BaseEntity {
     *  public SpriteRenderer SpriteRenderer;
     *  ...
     * }
     * 
     * 
     * 
     */


}
