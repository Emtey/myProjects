using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;

namespace MoonShooter
{
    public class MoonShooter : Game
    {
        #region PrivateData
        Random m_Random = new Random();
        int m_GameLoops;
        #endregion

        #region Object Prototypes
        public static Defender Defender;
        public static Asteroid Asteroid;
        public static Bullet Bullet;
        public static HomingMissile HomingMissile;

        public static Sound Shoot;
        public static Sound Die;
        public static Sound Explosion;

        public static Text2D Shots;
        public static Text2D Score;
        public static Text2D Lives;

        public static Music Music;
        #endregion

        public MoonShooter()
        {
            FrameRate = 60;
            Resolution = new Size(640, 480);
            Title = "Moon Blaster";
            PicturesPath = Application.StartupPath + "\\Resources\\Pictures\\";
            MusicPath = Application.StartupPath + "\\Resources\\Music\\";
            SoundPath = Application.StartupPath + "\\Resources\\Sounds\\";
        }

        public override void InitializeResources()
        {
            #region Background
            Picture background = new Picture("Space.bmp", Color.FromArgb(0, 255, 0));
            Game.Add(background);

            Frame backGroundFrame = new Frame(background, 0);
            Animation backGroundAnimation = new Animation();
            backGroundAnimation.Add(backGroundFrame);
            Background bg = new Background();
            bg.Add(backGroundAnimation);
            bg.Position = new Point(320, 240);
            bg.ScaleX = 640.0f / background.Width;
            bg.ScaleY = 480.0f / background.Height;
            bg.ZOrder = 10;
            Game.Add(bg);
            #endregion

            #region Defender
            Picture defender01 = new Picture("MoonGun.bmp", Color.FromArgb(0, 255, 0));
            Game.Add(defender01);


            Frame afDefender01 = new Frame(defender01, 5);

            Animation defenderAnimation = new Animation();
            defenderAnimation.Add(afDefender01);
            defenderAnimation.Play();
            defenderAnimation.Loop = true;

            Defender defender = new Defender();
            defender.Add(defenderAnimation);
            defender.Position = new Point(320, 450);
            Defender.m_Lives = 3;
            Game.Add(defender);
            Defender = defender;

            #endregion

            #region Asteroid
            Picture asteroid01 = new Picture("asteroid01.bmp", Color.FromArgb(0, 255, 0));
            Game.Add(asteroid01);
            Picture asteroid02 = new Picture("asteroid02.bmp", Color.FromArgb(0, 255, 0));
            Game.Add(asteroid02);
            Picture asteroid03 = new Picture("asteroid03.bmp", Color.FromArgb(0, 255, 0));
            Game.Add(asteroid03);
            Picture asteroid04 = new Picture("asteroid04.bmp", Color.FromArgb(0, 255, 0));
            Game.Add(asteroid04);

            Frame afasteroid01 = new Frame(asteroid01, 8);
            Frame afasteroid02 = new Frame(asteroid02, 8);
            Frame afasteroid03 = new Frame(asteroid03, 8);
            Frame afasteroid04 = new Frame(asteroid04, 8);

            Animation asteroidAnimation = new Animation();
            asteroidAnimation.Add(afasteroid01);
            asteroidAnimation.Add(afasteroid02);
            asteroidAnimation.Add(afasteroid03);
            asteroidAnimation.Add(afasteroid04);
            asteroidAnimation.Play();
            asteroidAnimation.Loop = true;

            Picture condorExplosion01 = new Picture("condorExplosion01.bmp", Color.FromArgb(0, 255, 0));
            Game.Add(condorExplosion01);
            Picture condorExplosion02 = new Picture("condorExplosion02.bmp", Color.FromArgb(0, 255, 0));
            Game.Add(condorExplosion02);
            Picture condorExplosion03 = new Picture("condorExplosion03.bmp", Color.FromArgb(0, 255, 0));
            Game.Add(condorExplosion03);

            Frame afcondorExplosion01 = new Frame(condorExplosion01, 4);
            Frame afcondorExplosion02 = new Frame(condorExplosion02, 3);
            Frame afcondorExplosion03 = new Frame(condorExplosion03, 4);


            Animation condorExplosion = new Animation();
            condorExplosion.Add(afcondorExplosion01);
            condorExplosion.Add(afcondorExplosion02);
            condorExplosion.Add(afcondorExplosion03);
            condorExplosion.Play();

            Asteroid asteroid = new Asteroid();
            asteroid.Add(asteroidAnimation);
            asteroid.Add(condorExplosion);
            Asteroid = asteroid;
            #endregion

            #region HomingMissile
            Picture homing01 = new Picture("homing01.bmp", Color.FromArgb(0, 255, 0));
            Game.Add(homing01);

            Frame afHoming01 = new Frame(homing01, 5);

            Animation homingAnimation = new Animation();
            homingAnimation.Add(afHoming01);
            homingAnimation.Play();
            homingAnimation.Loop = true;

            HomingMissile homingMissile = new HomingMissile();
            homingMissile.Add(homingAnimation);
            homingMissile.Add(condorExplosion);
            HomingMissile = homingMissile;
            #endregion

            #region Bullet
            Picture bullet01 = new Picture("fire01.bmp", Color.FromArgb(0, 255, 0));
            Game.Add(bullet01);
            Picture bullet02 = new Picture("fire02.bmp", Color.FromArgb(0, 255, 0));
            Game.Add(bullet02);

            Frame afBullet01 = new Frame(bullet01, 5);
            Frame afBullet02 = new Frame(bullet02, 5);

            Animation bulletAnimation = new Animation();
            bulletAnimation.Add(afBullet01);
            bulletAnimation.Add(afBullet02);
            bulletAnimation.Play();
            bulletAnimation.Loop = true;

            Bullet bullet = new Bullet();
            bullet.ZOrder = -10;
            bullet.Add(bulletAnimation);
            Bullet = bullet;
            #endregion

            #region FontText
            Font font = new Font("Arial", 14.0f, FontStyle.Regular);
            Game.Add(font);

            Text2D FrameRate = new FrameRate(font);
            Game.Add(FrameRate);

            Text2D Shots = new Text2D(font);
            Shots.Text = "Shots: 0";
            Shots.Position = new Point(0, 0);
            Shots.Color = Color.Green;
            MoonShooter.Shots = Shots;
            Game.Add(Shots);

            Text2D Score = new Text2D(font);
            Score.Text = "Score: 0";
            Score.Position = new Point(150, 0);
            Score.Color = Color.Red;
            MoonShooter.Score = Score;
            Game.Add(Score);

            Text2D Lives = new Text2D(font);
            Lives.Text = "Lives: 3";
            Lives.Position = new Point(250, 0);
            Lives.Color = Color.Yellow;
            MoonShooter.Lives = Lives;
            Game.Add(Lives);

            #endregion

            #region Sounds
            Shoot = new Sound("Shoot.wav");
            Game.Add(Shoot);

            Die = new Sound("Die.wav");
            //Die = new Sound("pacman2.wav");
            Game.Add(Die);

            Explosion = new Sound("Explosion.wav");
            Game.Add(Explosion);

            Music = new Music("bandsong.wav");
            Game.Add(Music);
            Music.Play();
            #endregion
        }

        public override void Update()
        {
            m_GameLoops++;
            if (m_GameLoops % 75 == 0)
            {
                //spawn a new Asteriod
                Asteroid asteroid = (Asteroid)Asteroid.Clone();
                asteroid.Position = new Point(m_Random.Next(30, 610), -150);
                asteroid.Velocity = new Vector2(0, m_Random.Next(1, 5));
                Game.Add(asteroid);
            }
            if (m_GameLoops % 200 == 0)
            {
                //spawn a homing missile
                HomingMissile homingMissile = (HomingMissile)HomingMissile.Clone();
                homingMissile.Position = new Point(m_Random.Next(-50, 510) - 150);
                Game.Add(homingMissile);
            }

            if (Defender.m_Lives <= 0)
            {
                Game.Quit();
            }
            //make sure the music is playing
            if (!Music.IsPlaying)
                Music.Play();
        }
    }
}
