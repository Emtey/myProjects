using System;
using System.Collections.Generic;
using System.Text;

namespace MoonShooter
{
    #region Animation
    public class Animation : ICloneable
    {
        #region PrivateData
        List<Frame> m_Frames = new List<Frame>();
        int m_CurrentFrame;
        int m_CurrentDelay;
        int m_StartingFrame;
        int m_EndingFrame;
        bool m_Loop;
        bool m_Playing;
        bool m_Paused;
        #endregion

        public Animation()
        {
        }

        protected Animation(Animation animation)
        {
            m_CurrentFrame = animation.m_CurrentFrame;
            m_CurrentDelay = animation.m_CurrentDelay;
            m_StartingFrame = animation.m_StartingFrame;
            m_EndingFrame = animation.m_EndingFrame;
            m_Loop = animation.m_Loop;
            m_Playing = animation.m_Playing;
            m_Paused = animation.m_Paused;
            foreach (Frame animationFrame in animation.m_Frames)
                m_Frames.Add(animationFrame);
        }

        public bool PlayingFirstFrame
        {
            get { return m_Frames[m_StartingFrame].Delay == m_CurrentDelay && m_StartingFrame == m_CurrentFrame; }
        }
        public bool PayingLastFrame
        {
            get { return m_CurrentDelay == 0 && m_CurrentFrame == m_EndingFrame; }
        }
        public void Play()
        {
            if (!m_Playing && !m_Paused)
            {
                m_CurrentFrame = m_StartingFrame;
                m_CurrentDelay = m_Frames[m_StartingFrame].Delay;
            }
            m_Playing = true;
        }
        public void Stop()
        {
            m_Playing = false;
            m_Paused = false;
        }
        public bool Playing
        {
            get { return m_Playing; }
        }
        public bool Paused
        {
            get { return m_Paused; }
        }
        public void Pause()
        {
            m_Paused = true;
        }
        public bool Loop
        {
            get { return m_Loop; }
            set { m_Loop = value; }
        }
        public int FirstFrame
        {
            get { return m_StartingFrame; }
            set
            {
                if (value > m_EndingFrame)
                    value = m_EndingFrame;
                else if (value < 0)
                    value = 0;
                m_StartingFrame = value;
            }
        }

        public int LastFrame
        {
            get { return m_EndingFrame; }
            set
            {
                if (value < m_StartingFrame)
                    value = m_StartingFrame;
                else if (value >= m_Frames.Count)
                    value = m_Frames.Count - 1;
                m_EndingFrame = value;
            }
        }
        public int RemainingFrameDelay
        {
            get { return m_Frames[m_CurrentFrame].Delay - m_CurrentDelay; }
        }
        public int CurrentFrameIndex
        {
            get { return m_CurrentFrame; }
            set
            {
                if (value < m_StartingFrame)
                    value = m_StartingFrame;
                else if (value > m_EndingFrame)
                    value = m_EndingFrame;
                m_CurrentFrame = value;
            }
        }
        public void Update()
        {
            if (m_Frames.Count == 0 || !m_Playing || m_Paused)
                return;

            m_CurrentDelay--;
            if (m_CurrentDelay < 0)
            {
                m_CurrentFrame++;
                if (m_CurrentFrame > m_EndingFrame)
                {
                    if (m_Loop)
                        m_CurrentFrame = m_StartingFrame;
                    else
                        m_CurrentFrame = m_EndingFrame;
                }
                m_CurrentDelay = m_Frames[m_CurrentFrame].Delay;
            }
        }

        public void Add(Frame frame)
        {
            m_Frames.Add(frame);
            m_EndingFrame = m_Frames.Count - 1;
        }
        public Picture CurrentPicture
        {
            get { return m_Frames[m_CurrentFrame].Picture; }
        }
        public int Count
        {
            get { return m_Frames.Count; }
        }
        public virtual Object Clone()
        {
            return new Animation(this);
        }
    }
    #endregion

    #region Frame struct
    public struct Frame
    {
        #region PrivateData
        Picture m_Picture;
        int m_Delay;
        #endregion

        public Frame(Picture picture, int delay)
        {
            m_Picture = picture;
            m_Delay = delay;
        }

        public Picture Picture
        {
            get { return m_Picture; }
        }
        public int Delay
        {
            get { return m_Delay; }
        }
    }
    #endregion
}

