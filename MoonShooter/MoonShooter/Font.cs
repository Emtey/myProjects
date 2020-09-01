using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using D3DFont = Microsoft.DirectX.Direct3D.Font;
using GDIFont = System.Drawing.Font;

namespace MoonShooter
{
    public class Font : IDisposable
    {
        #region PrivateData
        private D3DFont m_Font;
        private bool m_Disposed = false;
        #endregion

        #region IDisposable Members
        public virtual void Dispose()
        {
            m_Font.Dispose();
            m_Font = null;
            m_Disposed = true;
        }
        #endregion

        public Font(string typeFace, float size, FontStyle fontStyle)
        {
            using (GDIFont gdiFont = new GDIFont(typeFace, size, fontStyle))
            {
                m_Font = new D3DFont(Game.DGDevice, gdiFont);
            }
        }

        public bool Disposed
        {
            get { return m_Disposed; }
        }

        public void Draw(string text, int x, int y, Color color)
        {
            m_Font.DrawText(null, text, x, y, color);
        }
    }
}

