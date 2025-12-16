using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class EnemySpawner
{
    private Texture2D texture;
    private Random rand = new();
    private int Spawntimer;

    public EnemySpawner(Texture2D texture)
    {
        this.texture = texture;
    }

    public void Update(List<Enemy1> enemies)
    {
        Spawntimer++;
        if(Spawntimer > 15 && rand.Next(100) < 1)
        {
            enemies.Add(new Enemy1(texture, new Vector2(850, 320), new Point (120, 150), Color.White, 2f));
        }
    }
}