using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ambiance
{
	public class Ambiance_Separator : Control
	{
		public Ambiance_Separator()
		{
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.Size = new System.Drawing.Size(120, 10);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.DrawLine(new Pen(Color.FromArgb(224, 222, 220)), 0, 5, base.Width, 5);
			e.Graphics.DrawLine(new Pen(Color.FromArgb(250, 249, 249)), 0, 6, base.Width, 6);
		}
	}
}