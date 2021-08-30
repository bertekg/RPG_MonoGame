﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace rpg
{
    class Controller
    {
        public static double timer = 2D;
        public static double maxTime = 2D;
        static Random random = new Random();

        public static void Update(GameTime gameTime, Texture2D spriteSheet)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                int side = random.Next(4);

                switch(side)
                {
                    case 0:
                        Enemy.enemies.Add(new Enemy(new Vector2(-500, random.Next(-500, 2000)), spriteSheet));
                        break;
                    case 1:
                        Enemy.enemies.Add(new Enemy(new Vector2(2000, random.Next(-500, 2000)), spriteSheet));
                        break;
                    case 2:
                        Enemy.enemies.Add(new Enemy(new Vector2(random.Next(-500, 2000), -500), spriteSheet));
                        break;
                    case 3:
                        Enemy.enemies.Add(new Enemy(new Vector2(random.Next(-500, 2000), 2000), spriteSheet));
                        break;
                }

                timer += maxTime;
                if (maxTime > 0.5D)
                {
                    maxTime -= 0.05D;
                }
            }
        }
    }
}
