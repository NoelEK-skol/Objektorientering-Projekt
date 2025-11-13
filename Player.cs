
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player : BaseClass
{
    private KeyboardState newkState;
    private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = 10; }
    }

    public Player(Texture2D texture, Vector2 position, Point size, Color color, float speed) : base(texture, position, size, color)
    {
        this.speed = speed;
    }

    public override void Update()
    {
        newkState = Keyboard.GetState();
        if (position.Y >= 0 && newkState.IsKeyDown(Keys.W)) position.Y -= speed;
        if (newkState.IsKeyDown(Keys.S)) position.Y += speed;
        if (position.X >= 0 && newkState.IsKeyDown(Keys.A)) position.X -= speed;
        if (position.X <= 680 && newkState.IsKeyDown(Keys.D)) position.X += speed;

        hitbox.Location = position.ToPoint();

        if(position.Y >= 300)
        {
            position.Y = 300;
        }
    }
}