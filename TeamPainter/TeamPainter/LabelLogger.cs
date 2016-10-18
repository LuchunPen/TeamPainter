/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 07.07.2016 15:54:52
*/

using System;
using System.Windows.Forms;

using Nano3;

namespace TeamPainter
{
    public class TextLogger : ILogger
    {
        private RichTextBox _rText;
        public TextLogger(RichTextBox txt)
        {
            _rText = txt;
        }

        public void Log(object message, LogType logType)
        {
            Log(message.ToString(), logType);
        }

        public void Log(string message, LogType logType)
        {
            if (_rText != null)
            {
                _rText.Invoke((MethodInvoker)delegate
                {
                    if (_rText.Text.Length > 5000)
                    {
                        _rText.Text = _rText.Text.Substring(2500);
                    }

                    _rText.Text += Environment.NewLine + message;
                    _rText.SelectionStart = _rText.Text.Length;
                    _rText.ScrollToCaret();
                });
            }
        }
    }

    public class LabelLogger : ILogger
    {
        private Label _rText;
        public LabelLogger(Label txt)
        {
            _rText = txt;
        }

        public void Log(object message, LogType logType)
        {
            Log(message.ToString(), logType);
        }

        public void Log(string message, LogType logType)
        {
            if (_rText != null)
            {
                _rText.Invoke((MethodInvoker)delegate
                {
                    _rText.Text = message;
                });
            }
        }
    }
}
