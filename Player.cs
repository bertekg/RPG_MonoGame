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

            if (isMoving)
            {
                switch (direction)
                {
                    case Dir.Down:
                        position.Y += (float)realSpeed;
                        break;
                    case Dir.Up:
                        position.Y -= (float)realSpeed;
                        break;
                    case Dir.Left:
                        position.X -= (float)realSpeed;
                        break;
                    case Dir.Right:
                        position.X += (float)realSpeed;
                        break;
                    default:
                        break;
                }
            }

            anim = animations[(int)direction];

            anim.Position = new Vector2(position.X - 48, position.Y - 48);
            
            if (isMoving)
            {
                anim.Update(gameTime);
            }
            else
            {
                anim.setFrame(1);
            }
        }
    }
}
