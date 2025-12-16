
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player : BaseClass
{
    private KeyboardState newkState;
    private KeyboardState oldkState;
    private Texture2D bulletTexture;
    const float gravity = 30f;
    Vector2 velocity;
    private bool canJump = true;
    private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = 10; }
    }

    private List<Bullet> bullets = new List<Bullet>();
    public List<Bullet> Bullets
    {
        get{return bullets;}
    }

    public Player(Texture2D texture, Texture2D bulletTexture, Vector2 position, Point size, Color color, float speed) : base(texture, position, size, color)
    {
        this.speed = speed;
        this.bulletTexture = bulletTexture;
    }

    private void jump()
    {
        if (canJump) // canJump //true
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
        if(position.Y <= -10) position.Y = -10;
        if (newkState.IsKeyDown(Keys.Space))
        {
            jump();
        }
        position.Y += velocity.Y;
        velocity.Y += gravity * 1f/60f;
        if(position.X >= 300 && position.X <= 360 && position.Y >= 250)
        {
            speed = 1f;
            canJump = false;
            velocity.Y = 1;
        }
        else
        {
            speed = 5f;
        }

        if(position.X >= 360 && position.X <= 410)
        {
            canJump = true;
        }
    }
    
    public override void Update()
    {
        base.Update();
        newkState = Keyboard.GetState();
        Shoot();
        oldkState = newkState;

        if(position.Y >= 300)
        {
            velocity.Y = 0;
            position.Y = 300;
            canJump = true;
        }

        if(position.X >= 120 && position.X <= 380 && Math.Abs(position.Y - 75)< 5 && velocity.Y > 0) ///
        {
            velocity.Y = 0;
            position.Y = 75;
            canJump = true;
        }
       

        foreach(Bullet b in bullets)
        {
            b.Update();
        }

    }

    private void Shoot()
    {
        if(newkState.IsKeyDown(Keys.E) && oldkState.IsKeyUp(Keys.E))
        {
            bullets.Add(new(bulletTexture, position + new Vector2(90,25)));
        }
    }
}