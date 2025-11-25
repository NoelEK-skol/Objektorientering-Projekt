using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Enemy1 : BaseClass
{
    private float speed;
    public float Speed
    {
        get{return speed;}
        set{speed = value;}
    }
    public Enemy1(Texture2D texture, Vector2 position, Point size, Color color, float speed) : base(texture, position, size, color)
    {
        this.speed = speed;
    }

    public override void Update()
    {
        position.X -= 2;
        hitbox.Location = position.ToPoint();
    }
}