using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
// Moneky shooter remasterd
namespace Objektorientering_Projekt;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D backgroundTexture;
    private Texture2D character;
    private Texture2D enemy;
    private Player player;
    private Enemy1 enemy1;
    private int SpawnTimer;

    private List<Enemy1> enemies = new List<Enemy1>();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        backgroundTexture = Content.Load<Texture2D>("GameBakgrund");
        character = Content.Load<Texture2D>("PlayerCharacter");
        enemy = Content.Load<Texture2D>("ApaFiende");
        Vector2 startPosition = new Vector2(100, 300);
        Vector2 EnemyStartPosition = new Vector2(620, 320);
        Point size = new Point(120, 150);
        Color color = Color.White;
        float speed = 5f;
        player = new Player(character, startPosition, size, color, speed);
        enemy1 = new Enemy1(enemy,EnemyStartPosition, size, color, speed);
        enemies.Add(enemy1);



        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        player.Update();
        foreach(Enemy1 enemy in enemies)
        {
            enemy.Update();    
        }
        SpawnEnemy();
        SpawnTimer ++;
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();

        // TODO: Add your drawing code here
        Rectangle bgRect = new(0, 0, 800, 480);
        _spriteBatch.Draw(backgroundTexture, bgRect, Color.White);
        player.Draw(_spriteBatch);
        foreach (Enemy1 a in enemies)
        {
            a.Draw(_spriteBatch);
        }

        _spriteBatch.End();
        base.Draw(gameTime);
    }

    private void SpawnEnemy()
    {
        Texture2D texture = enemy;
        Point size = new Point(120, 150);
        Color color = Color.White;
        Vector2 spawnPosition = new Vector2(850, 320);
        Random rand = new Random();
        int value = rand.Next(1, 101);
        int spawnChancePercent = (int)1f;
        if(value <= spawnChancePercent && SpawnTimer >= 15)
        {
    
            enemies.Add(new Enemy1(texture, spawnPosition, size, color, 2f));
            SpawnTimer = 0;
        }
    }
}
