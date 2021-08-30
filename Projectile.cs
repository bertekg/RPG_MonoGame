using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace rpg
{
    class Projectile
    {
        public static List<Projectile> projectiles = new List<Projectile>();

        private Vector2 position;
        private double speed = 1000;
        public int radius = 18;
        private Dir direction;

        public Projectile(Vector2 newPos, Dir newDir)
        {
            position = newPos;
            direction = newDir;
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public void Update(GameTime gameTime)
        {
            double realSpeed = speed * gameTime.ElapsedGameTime.TotalSeconds;

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
    }
}
