
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player : BaseClass
{
    private KeyboardState newkState;
    private KeyboardState oldkState;
    const float gravity = 30f;
    Vector2 velocity;
    private bool canJump = true;
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

    private void jump()
    {
        if (canJump)
        {
            velocity.Y = -10;
            canJump = false;
        }
    }

    protected override void Move()
    {
        if (newkState.IsKeyDown(Keys.S)) position.Y += speed;
        if (position.X >= 0 && newkState.IsKeyDown(Keys.A)) position.X -= speed;
        if (position.X <= 680 && newkState.IsKeyDown(Keys.D)) position.X += speed;
        if (newkState.IsKeyDown(Keys.Space))
        {
            jump();
        }
        position.Y += velocity.Y;
        velocity.Y += gravity * 1f/60f;
    }
    
    public override void Update()
    {
        base.Update();
        newkState = Keyboard.GetState();
        
        oldkState = newkState;

        if(position.Y >= 300)
        {
            velocity.Y = 0;
            position.Y = 300;
            canJump = true;
        }
    }
}