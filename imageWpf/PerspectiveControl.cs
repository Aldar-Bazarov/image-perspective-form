using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImagePerspective
{
    public class PerspectiveControl
    {
        private bool mouseIsClick;

        private int prevX;
        private int prevY;

        public Point topLeft;
        public Point topRight;
        public Point bottomLeft;
        public Point bottomRight;

        public Control parentControl;

        private CornerRectangles currentCorner;

        public PerspectiveControl(Control control)
        {
            mouseIsClick = false;
            parentControl = control;

            topLeft = new Point(10, 10);
            topRight = new Point(control.Width - 10, 10);
            bottomLeft = new Point(10, control.Height - 10);
            bottomRight = new Point(control.Width - 10, control.Height - 10);
        }

        private enum CornerRectangles
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            None
        };

        public void SetControl(Control parrent)
        {
            this.parentControl = parrent;
            parentControl.Paint += new PaintEventHandler(Control_Paint);
            parentControl.SizeChanged += new EventHandler(SizeChanged_Changed);
            parentControl.MouseDown += new MouseEventHandler(Control_MouseDown);
            parentControl.MouseUp += new MouseEventHandler(Control_MouseUp);
            parentControl.MouseMove += new MouseEventHandler(Control_MouseMove);
        }

        private void Control_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black), topLeft, topRight);
            e.Graphics.DrawLine(new Pen(Color.Black), topRight, bottomRight);
            e.Graphics.DrawLine(new Pen(Color.Black), bottomRight, bottomLeft);
            e.Graphics.DrawLine(new Pen(Color.Black), bottomLeft, topLeft);

            foreach (CornerRectangles pos in Enum.GetValues(typeof(CornerRectangles)))
            {
                e.Graphics.DrawRectangle(new Pen(Color.Black), GetCornerRect(pos));
            }
        }

        private void SizeChanged_Changed(object sender, EventArgs e)
        {
            topLeft = new Point(10, 10);
            topRight = new Point(parentControl.Width - 10, 10);
            bottomLeft = new Point(10, parentControl.Height - 10);
            bottomRight = new Point(parentControl.Width - 10, parentControl.Height - 8);
        }

        /// <summary>
        /// Обработка событий мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsClick = true;

            currentCorner = GetCurrentCorner(e.Location);
            
            prevX = e.X;
            prevY = e.Y;
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsClick = false;
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            ChangeCursor(e.Location);

            if (mouseIsClick == false)
            {
                return;
            }

            switch (currentCorner)
            {
                case CornerRectangles.TopLeft:
                    topLeft.X += e.X - prevX;
                    topLeft.Y += e.Y - prevY;
                    break;

                case CornerRectangles.TopRight:
                    topRight.X += e.X - prevX;
                    topRight.Y += e.Y - prevY;
                    break;

                case CornerRectangles.BottomLeft:
                    bottomLeft.X += e.X - prevX;
                    bottomLeft.Y += e.Y - prevY;
                    break;

                case CornerRectangles.BottomRight:
                    bottomRight.X += e.X - prevX;
                    bottomRight.Y += e.Y - prevY;
                    break;

                default:
                    break;
            }

            topLeft = InsideParentArea(topLeft, e.X, e.Y);
            topRight = InsideParentArea(topRight, e.X, e.Y);
            bottomLeft = InsideParentArea(bottomLeft, e.X, e.Y);
            bottomRight = InsideParentArea(bottomRight, e.X, e.Y);

            prevX = e.X;
            prevY = e.Y;

            parentControl.Invalidate();
        }

        private Point InsideParentArea(Point cornerLocation, int X, int Y)
        {
            if (cornerLocation.X < 0
                || cornerLocation.Y < 0
                || cornerLocation.X > parentControl.Width
                || cornerLocation.Y > parentControl.Height)
            {
                return new Point(cornerLocation.X - (X - prevX), cornerLocation.Y - (Y - prevY));
            }
            return cornerLocation;
        }

        /// <summary>
        /// Получить угловой прямоугольник
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <returns>Прямоугольник</returns>
        private Rectangle GetCornerRect(CornerRectangles cornerRectangle)
        {
            switch (cornerRectangle)
            {
                case CornerRectangles.TopLeft:
                    return new Rectangle(topLeft.X - 5, topLeft.Y - 5, 10, 10);

                case CornerRectangles.TopRight:
                    return new Rectangle(topRight.X - 5, topRight.Y - 5, 10, 10);

                case CornerRectangles.BottomLeft:
                    return new Rectangle(bottomLeft.X - 5, bottomLeft.Y - 5, 10, 10);

                case CornerRectangles.BottomRight:
                    return new Rectangle(bottomRight.X - 5, bottomRight.Y - 5, 10, 10);

                default:
                    return new Rectangle();
            }
        }

        private CornerRectangles GetCurrentCorner(Point position)
        {
            foreach (CornerRectangles cornerRectangle in Enum.GetValues(typeof(CornerRectangles)))
            {
                if (GetCornerRect(cornerRectangle).Contains(position))
                {
                    return cornerRectangle;
                }
            }
            return CornerRectangles.None;
        }

        private void ChangeCursor(Point point)
        {
            var position = GetCurrentCorner(point);

            switch (position)
            {
                case CornerRectangles.TopLeft:
                    parentControl.Cursor = Cursors.SizeNWSE;
                    break;

                case CornerRectangles.TopRight:
                    parentControl.Cursor = Cursors.SizeNESW;
                    break;

                case CornerRectangles.BottomLeft:
                    parentControl.Cursor = Cursors.SizeNESW;
                    break;

                case CornerRectangles.BottomRight:
                    parentControl.Cursor = Cursors.SizeNWSE;
                    break;

                default:
                    parentControl.Cursor = Cursors.Default;
                    break;
            }
        }
    }
}