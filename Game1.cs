using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Comora;

namespace rpg
{
    enum Dir { Down, Up, Left, Right }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D playerSprite;
        Texture2D walkDownSprite;
        Texture2D walkUpSprite;
        Texture2D walkRightSprite;
        Texture2D walkLeftSprite;

        Texture2D backgroundSprite;
        Texture2D ballSprite;
        Texture2D skullSprite;

        Player player = new Player();

        Camera camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            this.camera = new Camera(_graphics.GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            playerSprite = Content.Load<Texture2D>("Player/player");
            walkDownSprite = Content.Load<Texture2D>("Player/walkDown");
            walkUpSprite = Content.Load<Texture2D>("Player/walkUp");
            walkRightSprite = Content.Load<Texture2D>("Player/walkRight");
            walkLeftSprite = Content.Load<Texture2D>("Player/walkLeft");

            backgroundSprite = Content.Load<Texture2D>("background");
            ballSprite = Content.Load<Texture2D>("ball");
            skullSprite = Content.Load<Texture2D>("skull");

            player.animations[(int)Dir.Down] = new SpriteAnimation(walkDownSprite, 4, 8);
            player.animations[(int)Dir.Up] = new SpriteAnimation(walkUpSprite, 4, 8);
            player.animations[(int)Dir.Left] = new SpriteAnimation(walkLeftSprite, 4, 8);
            player.animations[(int)Dir.Right] = new SpriteAnimation(walkRightSprite, 4, 8);

            player.anim = player.animations[0];
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            this.camera.Position = player.Position;
            this.camera.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(this.camera);

            _spriteBatch.Draw(backgroundSprite, new Vector2(-500, -500), Color.White);
            player.anim.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
