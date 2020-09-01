using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;

namespace MoonShooter
{
    public class Defender : Sprite
    {
        static int m_Shots;
        public static int m_Lives;
        public override void Update()
        {
            #region Defender Movement
            int vx = 0;
            //our defender can only move along the bottom of the screen.
            if (Position.X > 30 && Keyboard.IsPressed(Key.LeftArrow))
                vx = -2;
            if (Position.X < 610 && Keyboard.IsPressed(Key.RightArrow))
                vx = 2;

            Velocity = new Vector2(vx, 0);
            #endregion

            #region Defender Attack
            if (Keyboard.IsTriggered(Key.Space))
            {
                Bullet bullet = (Bullet)MoonShooter.Bullet.Clone();
                bullet.Position = new PointF(Position.X, Position.Y - 35);
                bullet.Velocity = new Vector2(0, -4);
                Game.Add(bullet);

                MoonShooter.Shoot.Play();
                m_Shots++;
                MoonShooter.Shots.Text = "Shots: " + m_Shots.ToString();
            }
            #endregion
        }
    }

    public class Asteroid : Sprite
    {
        bool m_CollisionWithDefender = false;
        public int initialX;
        public static int m_Score;
        static int m_FallOutCount;

        public Asteroid()
        {
        }
        protected Asteroid(Asteroid asteroid)
            : base(asteroid)
        {
        }

        public override object Clone()
        {
            return new Asteroid(this);
        }

        public override void Update()
        {
            if (m_CollisionWithDefender)
            {
                CollisionWithDefender();
                return;
            }

            #region Movement
            if (AnimationIndex != 1)
            {
                float y = Position.Y;

                if (y > 640)
                {
                    m_FallOutCount++;
                    Game.Remove(this);
                    if (m_FallOutCount % 10 == 0)
                    {
                        m_Score--;
                        MoonShooter.Score.Text = "Score: " + m_Score.ToString();
                        m_FallOutCount = 0;
                    }
                }

                List<Sprite> collidedSprites = Game.GetCollidedSprites(this);
                if (collidedSprites != null)
                {
                    foreach (Sprite s in collidedSprites)
                    {
                        if (s is Bullet)
                        {
                            MoonShooter.Die.Play();
                            AnimationIndex = 1;
                            m_Score++;
                            MoonShooter.Score.Text = "Score: " + m_Score.ToString();
                            Game.Remove(s);
                            break;
                        }
                        else if (s is Defender)
                        {
                            m_CollisionWithDefender = true;
                            MoonShooter.Die.Play();
                            Animation.Stop();
                            m_Score--;
                            MoonShooter.Score.Text = "Score: " + m_Score.ToString();
                            Defender.m_Lives--;
                            MoonShooter.Lives.Text = "Lives: " + Defender.m_Lives.ToString();
                            break;
                        }
                    }
                }
            }
            else
            {
                if (Animation.PayingLastFrame)
                    Game.Remove(this);
            }
            #endregion
        }

        private void CollisionWithDefender()
        {
            Game.Remove(this);
        }
    }

    public class HomingMissile : Sprite
    {
        bool m_CollisionWithDefender = false;

        public HomingMissile()
        {
        }
        protected HomingMissile(HomingMissile homingMissle)
            : base(homingMissle)
        {
        }
        public override object Clone()
        {
            return new HomingMissile(this);
        }
        public override void Update()
        {
            if (m_CollisionWithDefender)
            {
                CollisionWithDefender();
                return;
            }

            #region Movement
            Defender d = MoonShooter.Defender;
            if (AnimationIndex != 1)
            {
                float x = d.Position.X - Position.X;
                float y = d.Position.Y - Position.Y;

                Vector2 v = new Vector2(x, y);
                v.Normalize();

                Velocity = v;


                if (Position.X >= 0)
                    ScaleX = 1;
                else
                    ScaleX = -1;

                if (this.Position.Y > 420)
                {
                    m_CollisionWithDefender = true;
                    MoonShooter.Explosion.Play();
                    AnimationIndex = 1;
                }

                List<Sprite> collidedSprites = Game.GetCollidedSprites(this);
                if (collidedSprites != null)
                {
                    foreach (Sprite s in collidedSprites)
                    {
                        if (s is Defender)
                        {
                            m_CollisionWithDefender = true;
                            MoonShooter.Explosion.Play();
                            Animation.Stop();
                            Asteroid.m_Score--;
                            MoonShooter.Score.Text = "Score: " + Asteroid.m_Score.ToString();
                            Defender.m_Lives--;
                            MoonShooter.Lives.Text = "Lives: " + Defender.m_Lives.ToString();
                            break;
                        }
                        if (s is Bullet)
                        {
                            m_CollisionWithDefender = true;
                            MoonShooter.Explosion.Play();
                            AnimationIndex = 1;
                            Asteroid.m_Score += 2;
                            MoonShooter.Score.Text = "Score: " + Asteroid.m_Score.ToString();
                            Game.Remove(s);
                        }
                    }
                }
            }
            else
            {
                if (Animation.PayingLastFrame)
                    Game.Remove(this);
            }
            #endregion
        }
        private void CollisionWithDefender()
        {
            Game.Remove(this);
        }
    }

    public class Bullet : Sprite
    {
        public Bullet()
        {
        }
        protected Bullet(Bullet bullet)
            : base(bullet)
        {
        }
        public override object Clone()
        {
            return new Bullet(this);
        }
        public override void Update()
        {
            float y = Position.Y;

            if (y < -100)
                Game.Remove(this);
        }
    }
}
