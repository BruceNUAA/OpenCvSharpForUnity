﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace OpenCvSharp.DebuggerVisualizers
{
    /// <summary>
    /// IplImageを表示するビューア
    /// </summary>
    public partial class IplImageViewer : Form
    {
        private Bitmap _bitmap;

        /// <summary>
        /// 
        /// </summary>
        public IplImageViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy"></param>
        public IplImageViewer(IplImageProxy proxy)
            : this()
        {
            _bitmap = proxy.Bitmap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetClientSize(new Size(_bitmap.Width, _bitmap.Height));            
            pictureBox.Image = _bitmap;
        }

        /// <summary>
        /// ClientSizeを画面からはみ出ない大きさに調整して設定する.
        /// </summary>
        /// <param name="size"></param>
        private void SetClientSize(Size size)
        {
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            if (size.Width > screenSize.Width)
            {
                double ratio = (double)screenSize.Width / size.Width;
                size.Width = Convert.ToInt32(size.Width * ratio);
                size.Height = Convert.ToInt32(size.Height * ratio);
            }
            if (size.Height > screenSize.Height)
            {
                double ratio = (double)screenSize.Height / size.Height;
                size.Width = Convert.ToInt32(size.Width * ratio);
                size.Height = Convert.ToInt32(size.Height * ratio);
            }
            ClientSize = size;
        }
    }
}
