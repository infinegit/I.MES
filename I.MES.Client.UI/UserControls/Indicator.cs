using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace I.MES.Client.UI.UserControls
{
    public partial class Indicator : UserControl
    {
        private int _CircleWidth = 5;
        private float _Value = 30;
        private float _MaxValue = 100;
        private bool _IsShowLine = true;
        private int _LineCount = 12;
        public Indicator()
        {
            InitializeComponent();
            Draw();
        }
        /// <summary>
        /// 圆环的宽度
        /// </summary>
        public int CircleWidth
        {
            get
            {
                return _CircleWidth;
            }
            set
            {
                _CircleWidth = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 当前值
        /// </summary>
        public float Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    this.Invalidate();
                }
            }
        }
        /// <summary>
        /// 最大值
        /// </summary>
        public float MaxValue
        {
            get
            {
                return _MaxValue;
            }
            set
            {
                _MaxValue = value;
                this.Invalidate();
            }
        }
        public bool IsShowLine
        {
            get
            {
                return _IsShowLine;
            }
            set
            {
                _IsShowLine = value;
                this.Invalidate();
            }

        }
        public int LineCount
        {
            get
            {
                return _LineCount;
            }
            set
            {
                if (value < 0)
                {
                    _LineCount = 0;
                }
                else
                {
                    _LineCount = value;
                }
                this.Invalidate();
            }
        }
        private void Draw()
        {
            Graphics ghs = this.CreateGraphics();
            Pen mypen = new Pen(Color.Blue, 3);
            ghs.DrawPie(mypen, 20, 10, 120, 100, 210, 120);
            mypen = new Pen(Color.Black, 3);
            Point p1 = new Point(10, 50);
            Point p2 = new Point(100, 50);
            ghs.DrawLine(mypen, p1, p2);
        }

        private void Indicator_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Bitmap localBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
                Graphics bitmapGraphics = Graphics.FromImage(localBitmap);
                bitmapGraphics.Clear(BackColor);
                bitmapGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                PaintImage(bitmapGraphics);
                Graphics g = e.Graphics;
                g.DrawImage(localBitmap, 0, 0);
                bitmapGraphics.Dispose();
                localBitmap.Dispose();
                g.Dispose();
            }
            catch (Exception ex)
            {
            }
        }
        private void PaintImage(Graphics g)
        {
            try
            {
                int size = this.Size.Width > this.Size.Height ? this.Size.Height : this.Size.Width;
                size -= _CircleWidth * 2;
                Point startPosition = new Point((this.Size.Width - size) / 2, (this.Size.Height - size) / 2);
                if (size <= 0)
                {
                    return;
                }
                g.DrawArc(new Pen(new SolidBrush(Color.LightGray), _CircleWidth), new Rectangle(startPosition, new Size(size, size)), -90, 360);
                g.DrawArc(new Pen(new SolidBrush(Color.FromArgb(51, 153, 255)), _CircleWidth), new Rectangle(startPosition, new Size(size, size)), -90, Angel());
                if (_IsShowLine && _LineCount > 0)
                {
                    PointF[] pList = GetPointList(startPosition, size / 2f, _LineCount);
                    for (int i = 0; i < pList.Length / 2; i++)
                    {
                        g.DrawLine(new Pen(new SolidBrush(Color.Gray), 1), pList[i * 2], pList[i * 2 + 1]);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private PointF[] GetPointList(PointF startPosition, float radius, int count)
        {
            PointF[] pList = new PointF[count * 2];
            float deg = (float)(360 / count * Math.PI / 180);
            for (int i = 0; i < pList.Length / 2; i++)
            {
                pList[i * 2].X = startPosition.X + radius + (radius - _CircleWidth) * (float)Math.Cos(deg * i);
                pList[i * 2].Y = startPosition.Y + radius - (radius - _CircleWidth) * (float)Math.Sin(deg * i);
                pList[i * 2 + 1].X = startPosition.X + radius + (radius - _CircleWidth / 2) * (float)Math.Cos(deg * i);
                pList[i * 2 + 1].Y = startPosition.Y + radius - (radius - CircleWidth / 2) * (float)Math.Sin(deg * i);
            }
            return pList;
        }
        private int Angel()
        {
            if (_MaxValue == 0)
            {
                return 0;
            }
            else
            {
                return (int)(_Value / _MaxValue * 360);
            }
        }
    }
}
