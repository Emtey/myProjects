using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.Direct3D;
using System.Drawing;

namespace MoonShooter
{
    public class Picture : IDisposable
    {
        #region PrivateData
        private Texture m_Texture;
        private int m_Width;
        private int m_Height;
        private bool m_Disposed = false;
        #endregion

        public Picture(string fileName, Color colorKey)
        {
            ImageInformation imageInformation = TextureLoader.ImageInformationFromFile(Game.PicturesPath + fileName);

            m_Width = imageInformation.Width;
            m_Height = imageInformation.Height;
            m_Texture = TextureLoader.FromFile(Game.Device, Game.PicturesPath + fileName, 0, 0, 1, Usage.None, Format.Unknown, Pool.Managed, Filter.None, Filter.None, colorKey.ToArgb());
        }

        #region IDisposable Members

        public virtual void Dispose()
        {
            m_Texture.Dispose();
            m_Texture = null;
            m_Disposed = true;
        }

        #endregion

        public bool Disposed
        {
            get { return m_Disposed; }
        }
        public Texture Texture
        {
            get { return m_Texture; }
        }
        public int Width
        {
            get { return m_Width; }
        }
        public int Height
        {
            get { return m_Height; }
        }

    }
}
