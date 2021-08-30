using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace rpg
{
    class Enemy
    {
        public static List<Enemy> enemies = new List<Enemy>();

        private Vector2 postion = new Vector2(0, 0);
        private double speed = 150;
        public SpriteAnimation anim;

        public Enemy(Vector2 newPos, Texture2D spriteSheet)
        {
            postion = newPos;
            anim = new SpriteAnimation(spriteSheet, 10, 6);
        }

        public Vector2 Postion
        {
            get { return postion; }
        }

        public void Update(GameTime gameTime, Vector2 playerPosition)
        {
            anim.Position = new Vector2(postion.X - 48, postion.Y - 66);
            anim.Update(gameTime);

            Vector2 moveDirection = playerPosition - postion;
            moveDirection.Normalize();
            postion += moveDirection *(float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
