using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	public class Ambiance_Panel : ContainerControl
	{
		public Ambiance_Panel()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.Opaque, false);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			this.Font = new System.Drawing.Font("Tahoma", 9f);
			this.BackColor = Color.White;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, base.Width, base.Height));
			graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, base.Width - 1, base.Height - 1));
			graphics.DrawRectangle(new Pen(Color.FromArgb(211, 208, 205)), 0, 0, base.Width - 1, base.Height - 1);
		}
	}
}