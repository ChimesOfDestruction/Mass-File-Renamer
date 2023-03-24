using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ambiance
{
	internal static class RoundRectangle
	{
		public static GraphicsPath RoundedTopRect(System.Drawing.Rectangle Rectangle, int Curve)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int curve = Curve * 2;
			graphicsPath.AddArc(new System.Drawing.Rectangle(Rectangle.X, Rectangle.Y, curve, curve), -180f, 90f);
			graphicsPath.AddArc(new System.Drawing.Rectangle(Rectangle.Width - curve + Rectangle.X, Rectangle.Y, curve, curve), -90f, 90f);
			graphicsPath.AddLine(new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + curve), new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height - 1));
			graphicsPath.AddLine(new Point(Rectangle.X, Rectangle.Height - 1 + Rectangle.Y), new Point(Rectangle.X, Rectangle.Y + Curve));
			return graphicsPath;
		}

		public static GraphicsPath RoundRect(System.Drawing.Rectangle Rectangle, int Curve)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int curve = Curve * 2;
			graphicsPath.AddArc(new System.Drawing.Rectangle(Rectangle.X, Rectangle.Y, curve, curve), -180f, 90f);
			graphicsPath.AddArc(new System.Drawing.Rectangle(Rectangle.Width - curve + Rectangle.X, Rectangle.Y, curve, curve), -90f, 90f);
			graphicsPath.AddArc(new System.Drawing.Rectangle(Rectangle.Width - curve + Rectangle.X, Rectangle.Height - curve + Rectangle.Y, curve, curve), 0f, 90f);
			graphicsPath.AddArc(new System.Drawing.Rectangle(Rectangle.X, Rectangle.Height - curve + Rectangle.Y, curve, curve), 90f, 90f);
			graphicsPath.AddLine(new Point(Rectangle.X, Rectangle.Height - curve + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
			return graphicsPath;
		}

		public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
		{
			Rectangle rectangle = new Rectangle(X, Y, Width, Height);
			GraphicsPath graphicsPath = new GraphicsPath();
			int curve = Curve * 2;
			graphicsPath.AddArc(new Rectangle(rectangle.X, rectangle.Y, curve, curve), -180f, 90f);
			graphicsPath.AddArc(new Rectangle(rectangle.Width - curve + rectangle.X, rectangle.Y, curve, curve), -90f, 90f);
			graphicsPath.AddArc(new Rectangle(rectangle.Width - curve + rectangle.X, rectangle.Height - curve + rectangle.Y, curve, curve), 0f, 90f);
			graphicsPath.AddArc(new Rectangle(rectangle.X, rectangle.Height - curve + rectangle.Y, curve, curve), 90f, 90f);
			graphicsPath.AddLine(new Point(rectangle.X, rectangle.Height - curve + rectangle.Y), new Point(rectangle.X, Curve + rectangle.Y));
			return graphicsPath;
		}
	}
}