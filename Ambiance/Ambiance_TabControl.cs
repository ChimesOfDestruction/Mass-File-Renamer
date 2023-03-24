using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ambiance
{
	public class Ambiance_TabControl : TabControl
	{
		public Ambiance_TabControl()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		protected override void CreateHandle()
		{
			base.CreateHandle();
			base.ItemSize = new System.Drawing.Size(80, 24);
			base.Alignment = TabAlignment.Top;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle tabRect;
			Graphics graphics = e.Graphics;
			Rectangle rectangle = new Rectangle();
			graphics.Clear(base.Parent.BackColor);
			for (int i = 0; i <= base.TabCount - 1; i++)
			{
				rectangle = base.GetTabRect(i);
				if (i != base.SelectedIndex)
				{
					string text = base.TabPages[i].Text;
					System.Drawing.Font font = new System.Drawing.Font(this.Font.Name, this.Font.Size - 2f, FontStyle.Bold);
					SolidBrush solidBrush = new SolidBrush(Color.FromArgb(80, 76, 76));
					Point location = base.GetTabRect(i).Location;
					tabRect = base.GetTabRect(i);
					graphics.DrawString(text, font, solidBrush, new Rectangle(location, tabRect.Size), new StringFormat()
					{
						LineAlignment = StringAlignment.Center,
						Alignment = StringAlignment.Center
					});
				}
			}
			graphics.FillPath(new SolidBrush(Color.FromArgb(247, 246, 246)), RoundRectangle.RoundRect(0, 23, base.Width - 1, base.Height - 24, 2));
			graphics.DrawPath(new Pen(Color.FromArgb(201, 198, 195)), RoundRectangle.RoundRect(0, 23, base.Width - 1, base.Height - 24, 2));
			for (int j = 0; j <= base.TabCount - 1; j++)
			{
				rectangle = base.GetTabRect(j);
				if (j == base.SelectedIndex)
				{
					graphics.DrawPath(new Pen(Color.FromArgb(201, 198, 195)), RoundRectangle.RoundedTopRect(new Rectangle(new Point(rectangle.X - 2, rectangle.Y - 2), new System.Drawing.Size(rectangle.Width + 3, rectangle.Height)), 7));
					graphics.FillPath(new SolidBrush(Color.FromArgb(247, 246, 246)), RoundRectangle.RoundedTopRect(new Rectangle(new Point(rectangle.X - 1, rectangle.Y - 1), new System.Drawing.Size(rectangle.Width + 2, rectangle.Height)), 7));
					try
					{
						string str = base.TabPages[j].Text;
						System.Drawing.Font font1 = new System.Drawing.Font(this.Font.Name, this.Font.Size - 1f, FontStyle.Bold);
						SolidBrush solidBrush1 = new SolidBrush(Color.FromArgb(80, 76, 76));
						Point point = base.GetTabRect(j).Location;
						tabRect = base.GetTabRect(j);
						graphics.DrawString(str, font1, solidBrush1, new Rectangle(point, tabRect.Size), new StringFormat()
						{
							LineAlignment = StringAlignment.Center,
							Alignment = StringAlignment.Center
						});
						base.TabPages[j].BackColor = Color.FromArgb(247, 246, 246);
					}
					catch
					{
					}
				}
			}
		}
	}
}