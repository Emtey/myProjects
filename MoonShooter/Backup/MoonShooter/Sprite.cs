using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace MoonShooter
{
    public class Sprite : ICloneable
    {
        #region PrivateData
        List<Animation> m_Animations = new List<Animation>();
        int m_CurrentAnimationIndex;
        string m_Name = "";
        Rectangle m_CollisionRectangle;
        Vector2 m_Velocity;
        PointF m_Position;
        Vector2 m_Scale = new Vector2(1, 1);
        float m_Rotation = 0;
        bool m_Visible = true;
        bool m_Active = true;
        bool m_ShowAllPixels = false;
        int m_Opacity = 100;
        int m_ZOrder = 0;
        Matrix m_LocalMatrix = Matrix.Identity;
        int m_Id;
        static int m_Counter;

        #endregion

        public Sprite()
        {
            m_Id = m_Counter++;
        }

        protected Sprite(Sprite sprite)
            : this()
        {
            foreach (Animation animation in sprite.m_Animations)
                m_Animations.Add((Animation)animation.Clone());

            m_CurrentAnimationIndex = sprite.m_CurrentAnimationIndex;
            m_Name = sprite.m_Name;

            m_CollisionRectangle = sprite.m_CollisionRectangle;

            m_Velocity = sprite.m_Velocity;
            m_Position = sprite.m_Position;
            m_Scale = sprite.m_Scale;
            m_Rotation = sprite.m_Rotation;
            m_Visible = sprite.m_Visible;
            m_Active = sprite.m_Active;
            m_ShowAllPixels = sprite.m_ShowAllPixels;
            m_Opacity = sprite.m_Opacity;
            m_ZOrder = sprite.m_ZOrder;
            m_LocalMatrix = sprite.m_LocalMatrix;
        }
        public void Add(Animation animation)
        {
            m_Animations.Add(animation);
        }
        public int Count
        {
            get { return m_Animations.Count; }
        }
        public int AnimationIndex
        {
            get { return m_CurrentAnimationIndex; }
            set
            {
                if (value >= m_Animations.Count)
                    value = m_Animations.Count - 1;
                else if (AnimationIndex < 0)
                    value = 0;

                m_CurrentAnimationIndex = value;
            }
        }
        public Animation Animation
        {
            get { return m_Animations[m_CurrentAnimationIndex]; }
        }
        public bool Visible
        {
            get { return m_Visible; }
            set { m_Visible = value; }
        }
        public bool Active
        {
            get { return m_Active; }
            set { m_Active = value; }
        }
        public PointF Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }
        public Vector2 Velocity
        {
            get { return m_Velocity; }
            set { m_Velocity = value; }
        }
        public float ScaleX
        {
            get { return m_Scale.X; }
            set { m_Scale.X = value; }
        }
        public float ScaleY
        {
            get { return m_Scale.Y; }
            set { m_Scale.Y = value; }
        }
        public float Rotation
        {
            get { return m_Rotation; }
            set { m_Rotation = value; }
        }
        public void InternalUpdate()
        {
            if (!m_Active)
                return;

            if (m_Animations.Count != 0)
                m_Animations[m_CurrentAnimationIndex].Update();

            m_Position.X += m_Velocity.X;
            m_Position.Y += m_Velocity.Y;

            Matrix trans = Matrix.Translation(m_Position.X, m_Position.Y, 0);
            Matrix rot = Matrix.RotationZ(m_Rotation);
            Matrix scaling = Matrix.Scaling(m_Scale.X, m_Scale.Y, 0);

            int pictureWidth = m_Animations[m_CurrentAnimationIndex].CurrentPicture.Width;
            int pictureHeight = m_Animations[m_CurrentAnimationIndex].CurrentPicture.Height;

            float newPicWidth = Math.Abs(scaling.M11 * pictureWidth);
            float newPicHeight = Math.Abs(scaling.M22 * pictureHeight);

            float ltx = scaling.M11 < 0 ? newPicWidth : 0;
            float lty = scaling.M22 < 0 ? newPicHeight : 0;

            ltx -= newPicWidth / 2;
            lty -= newPicHeight / 2;


            Matrix locTrans = Matrix.Translation(ltx, lty, 0);

            m_LocalMatrix = scaling * locTrans * rot * trans;

            UpdateCollisionRectangle();

        }

        private void UpdateCollisionRectangle()
        {
            int pictureWidth = m_Animations[m_CurrentAnimationIndex].CurrentPicture.Width;
            int pictureHeight = m_Animations[m_CurrentAnimationIndex].CurrentPicture.Height;
            m_CollisionRectangle.X = 0;
            m_CollisionRectangle.Y = 0;
            m_CollisionRectangle.Width = pictureWidth;
            m_CollisionRectangle.Height = pictureHeight;
            m_CollisionRectangle.Offset((int)(-pictureWidth / 2 + m_Position.X), (int)(-pictureHeight / 2 + m_Position.Y));
        }
        public virtual void Update()
        {
        }
        public void Render()
        {
            if (!m_Visible || !m_Active || m_Opacity < 0)
                return;
            if (m_ShowAllPixels)
                Game.Device.RenderState.AlphaTestEnable = false;
            else
                Game.Device.RenderState.AlphaTestEnable = true;

            if (m_Opacity >= 100)
                Game.D3DSprite.Begin(SpriteFlags.None);
            else
                Game.D3DSprite.Begin(SpriteFlags.AlphaBlend);

            int alpha = (m_Opacity * 255) / 100;

            Game.D3DSprite.Draw2D(m_Animations[m_CurrentAnimationIndex].CurrentPicture.Texture, new Point(0, 0), 0, new Point(0, 0), Color.FromArgb(alpha, 255, 255, 255));
            Game.Device.Transform.World = m_LocalMatrix;
            Game.D3DSprite.End();
        }
        public int ZOrder
        {
            get { return m_ZOrder; }
            set { m_ZOrder = value; }
        }
        public int Opacity
        {
            get { return m_Opacity; }
            set { m_Opacity = value; }
        }
        public bool ShowAllPixels
        {
            get { return m_ShowAllPixels; }
            set { m_ShowAllPixels = value; }
        }
        public bool CollidesWith(Sprite sprite)
        {
            return m_CollisionRectangle.IntersectsWith(sprite.m_CollisionRectangle);
        }
        public static int ComparisonZOrder(Sprite sprite1, Sprite sprite2)
        {
            int r = sprite2.m_ZOrder - sprite1.m_ZOrder;
            if (r == 0)
                return sprite2.m_Id = sprite1.m_Id;
            else
                return r;
        }

        #region ICloneable Members

        public virtual Object Clone()
        {
            return new Sprite(this);
        }

        #endregion
    }
}
