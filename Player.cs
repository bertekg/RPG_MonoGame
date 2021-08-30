using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace rpg
{
    class Player
    {
        private Vector2 position = new Vector2(500, 300);
        private double speed = 300;
        private Dir direction = Dir.Down;
        private bool isMoving = false;
        private KeyboardState keyboardStateOld = Keyboard.GetState();
        public bool dead = false;

        public SpriteAnimation anim;

        public SpriteAnimation[] animations = new SpriteAnimation[4];

        public Vector2 Position
        {
            get { return position; }
        }

        public void setX(float newX)
        {
            position.X = newX;
        }
        public void setY(float newY)
        {
            position.Y = newY;
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            double realSpeed = speed * gameTime.ElapsedGameTime.TotalSeconds;

            isMoving = false;

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                direction = Dir.Right;
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                direction = Dir.Left;
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                direction = Dir.Up;
                isMoving = true;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                direction = Dir.Down;
                isMoving = true;
            }

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                isMoving = false;
            }

            if (dead)
            {
                isMoving = false;
            }
            
            if (isMoving)
            {
                switch (direction)
                {
                    case Dir.Down:
                        if (position.Y < 1250)
                        {
                            position.Y += (float)realSpeed;
                        }
                        break;
                    case Dir.Up:
                        if (position.Y > 200)
                        {
                            position.Y -= (float)realSpeed;
                        }
                        break;
                    case Dir.Left:
                        if (position.X > 225)
                        {
                            position.X -= (float)realSpeed;
                        }
                        break;
                    case Dir.Right:
                        if (position.X < 1275)
                        {
                            position.X += (float)realSpeed;
                        }
                        break;
                    default:
                        break;
                }
            }

            anim = animations[(int)direction];

            anim.Position = new Vector2(position.X - 48, position.Y - 48);
            
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                anim.setFrame(0);
            }
            else if (isMoving)
            {
                anim.Update(gameTime);
            }
            else
            {
                anim.setFrame(1);
            }

            if (keyboardState.IsKeyDown(Keys.Space) && keyboardStateOld.IsKeyUp(Keys.Space))
            {
                Projectile.projectiles.Add(new Projectile(position, direction));
                MySounds.projectileSound.Play(1f, 0.5f, 0f);
            }

            keyboardStateOld = keyboardState;
        }
    }
}
