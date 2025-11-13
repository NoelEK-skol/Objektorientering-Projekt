using System.Dynamic;
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
    private Player player;

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
        Vector2 startPosition = new Vector2(100, 300);
        Point size = new Point(120, 150);
        Color color = Color.White;
        float speed = 5f;
        player = new Player(character, startPosition, size, color, speed);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        player.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();

        // TODO: Add your drawing code here
        Rectangle bgRect = new(0, 0, 800, 480);
        _spriteBatch.Draw(backgroundTexture, bgRect, Color.White);
        player.Draw(_spriteBatch);

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
