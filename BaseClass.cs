
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BaseClass
{
    protected Vector2 position;
    protected Texture2D texture;
    protected Rectangle hitbox;
    protected Color color;

    public Vector2 Position
    {
        get { return position; }
        set { position = value; }
    }
    public Rectangle Hitbox
    {
        get { return hitbox; }
    }
    public Color Color
    {
        get { return color; }
        set { color = value; }
    }

    public BaseClass(Texture2D texture, Vector2 position, Point size, Color color)
    {
        this.position = position;
        this.texture = texture;
        this.color = color;
        hitbox = new Rectangle((int)position.X, (int)position.Y, size.X, size.Y);
    }

    public virtual void Update()
    {

    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, hitbox, color);
    }
}