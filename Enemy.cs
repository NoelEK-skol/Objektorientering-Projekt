using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Enemy : BaseClass
{
    public float speed
    {
        get{return speed;}
        set{speed = 10;}
    }
    public Enemy(Texture2D texture, Vector2 position, Point size, Color color, float speed) : base(texture, position, size, color)
    {
        this.speed = speed;
    }
}