using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.Direct3D;
using System.Drawing;

namespace MoonShooter
{
    public class Text2D
    {
        #region PrivateData
        string m_Text = "";
        Color m_Color = Color.Black;
        Point m_Position;
        bool m_Visible = true;
        bool m_Active = true;
        Font m_Font;
        #endregion

        public Text2D(Font font)
        {
            m_Font = font;
        }

        public Point Position
        {
            set { m_Position = value; }
            get { return m_Position; }
        }
        public Color Color
        {
            set { m_Color = value; }
            get { return m_Color; }
        }
        public string Text
        {
            set { m_Text = value; }
            get { return m_Text; }
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

        public void Render()
        {
            if (m_Visible)
                m_Font.Draw(m_Text, m_Position.X, m_Position.Y, m_Color);
        }

        public void InternalUpdate()
        {
            if (!m_Active)
                return;
            Update();
        }

        public virtual void Update()
        {
        }
    }
}
