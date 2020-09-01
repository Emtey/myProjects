using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.DirectSound;
namespace MoonShooter
{
    public class Sound : IDisposable
    {
        #region PrivateData
        private SecondaryBuffer m_SecondaryBuffer;
        private bool m_Disposed = false;
        #endregion

        public Sound(string fileName)
        {
            BufferDescription desc = new BufferDescription();
            desc.StaticBuffer = true;
            m_SecondaryBuffer = new SecondaryBuffer(Game.SoundPath + fileName, desc, Game.DSDevice);
        }

        public virtual void Dispose()
        {
            m_SecondaryBuffer.Dispose();
            m_SecondaryBuffer = null;
            m_Disposed = true;
        }

        public bool Disposed
        {
            get { return m_Disposed; }
        }

        public void Play()
        {
            m_SecondaryBuffer.Play(0, BufferPlayFlags.Default);
        }
        public void Stop()
        {
            m_SecondaryBuffer.Stop();
        }
        public bool IsPlaying
        {
            get { return m_SecondaryBuffer.Status.Playing; }
        }
    }
}
