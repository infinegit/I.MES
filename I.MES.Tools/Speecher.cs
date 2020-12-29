using System;
using System.Collections.Generic;
using System.Text;
using System.Speech.Synthesis;

namespace I.MES.Tools
{
    /// <summary>
    /// 语音处理类
    /// 用法：Speecher.GetInstance().SpeakContent(String content);
    /// </summary>
    public class Speecher
    {
        /// <summary>
        /// 静态对象
        /// </summary>
        private static Speecher speecher = new Speecher();
        /// <summary>
        /// 语音合成器
        /// </summary>
        private SpeechSynthesizer speaker = new SpeechSynthesizer();
        /// <summary>
        /// 建构方法
        /// </summary>
        private Speecher()
        {
        }
        /// <summary>
        /// 播放成功音
        /// </summary>
        public void SpeakSuccess()
        {
            try
            {
                speaker.SpeakAsync("成功");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SpeakSerNum(string sernum)
        {
            try
            {
                speaker.SpeakAsync(sernum);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 播放失败音
        /// </summary>
        public void SpeakFailure()
        {
            try
            {
                speaker.SpeakAsync("失败");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 播放警告音
        /// </summary>
        public void SpeakAlert()
        {
            try
            {
                speaker.SpeakAsync("警告");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 播放指定内容，并清空上次内容
        /// </summary>
        /// <param name="content">需播报的内容</param>
        public void SpeakContent(object content)
        {
            try
            {
                speaker.SpeakAsyncCancelAll();
                speaker.SpeakAsync(content.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 播放指定内容,不清空上次播报内容
        /// </summary>
        /// <param name="content">需播报的内容</param>
        public void SpeakContentNoClear(object content)
        {
            try
            {
                speaker.SpeakAsync(content.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 取当前类实例
        /// </summary>
        /// <returns>Speecker实例</returns>
        public static Speecher GetInstance()
        {
            try
            {
                //if (speecher == null)
                //{
                //    speecher = new Speecher();
                //}
                return speecher;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


}
