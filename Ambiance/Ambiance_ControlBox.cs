using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	public class Ambiance_ControlBox : Control
	{
		private Ambiance_ControlBox.MouseState State = Ambiance_ControlBox.MouseState.None;

		private int X;

		private Rectangle CloseBtn = new Rectangle(3, 2, 17, 17);

		private Rectangle MinBtn = new Rectangle(23, 2, 17, 17);

		private Rectangle MaxBtn = new Rectangle(43, 2, 17, 17);

		private bool _EnableMaximize = true;

		public bool EnableMaximize
		{
			get
			{
				return this._EnableMaximize;
			}
			set
			{
				this._EnableMaximize = value;
				if (!this._EnableMaximize)
				{
					base.Size = new System.Drawing.Size(44, 22);
				}
				else
				{
					base.Size = new System.Drawing.Size(64, 22);
				}
				base.Invalidate();
			}
		}

		public Ambiance_ControlBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.DoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			this.Font = new System.Drawing.Font("Marlett", 7f);
			this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			base.Location = new Point(5, 13);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = Ambiance_ControlBox.MouseState.Down;
			base.Invalidate();
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = Ambiance_ControlBox.MouseState.Over;
			base.Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = Ambiance_ControlBox.MouseState.None;
			base.Invalidate();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.X = e.Location.X;
			base.Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if ((this.X <= 3 ? false : this.X < 20))
			{
				base.FindForm().Close();
			}
			else if ((this.X <= 23 ? false : this.X < 40))
			{
				base.FindForm().WindowState = FormWindowState.Minimized;
			}
			else if ((this.X <= 43 ? false : this.X < 60))
			{
				if (this._EnableMaximize)
				{
					if (base.FindForm().WindowState != FormWindowState.Maximized)
					{
						base.FindForm().WindowState = FormWindowState.Minimized;
						base.FindForm().WindowState = FormWindowState.Maximized;
					}
					else
					{
						base.FindForm().WindowState = FormWindowState.Minimized;
						base.FindForm().WindowState = FormWindowState.Normal;
					}
				}
			}
			this.State = Ambiance_ControlBox.MouseState.Over;
			base.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphic = Graphics.FromImage(bitmap);
			base.OnPaint(e);
			graphic.SmoothingMode = SmoothingMode.AntiAlias;
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.CloseBtn, Color.FromArgb(242, 132, 99), Color.FromArgb(224, 82, 33), 90f);
			graphic.FillEllipse(linearGradientBrush, this.CloseBtn);
			graphic.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), this.CloseBtn);
			graphic.DrawString("r", new System.Drawing.Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(6, 8, 0, 0));
			LinearGradientBrush linearGradientBrush1 = new LinearGradientBrush(this.MinBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90f);
			graphic.FillEllipse(linearGradientBrush1, this.MinBtn);
			graphic.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), this.MinBtn);
			graphic.DrawString("0", new System.Drawing.Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(26, 4, 0, 0));
			if (this._EnableMaximize)
			{
				LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(this.MaxBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90f);
				graphic.FillEllipse(linearGradientBrush2, this.MaxBtn);
				graphic.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), this.MaxBtn);
				graphic.DrawString("1", new System.Drawing.Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(46, 7, 0, 0));
			}
			Ambiance_ControlBox.MouseState state = this.State;
			if (state == Ambiance_ControlBox.MouseState.None)
			{
				LinearGradientBrush linearGradientBrush3 = new LinearGradientBrush(this.CloseBtn, Color.FromArgb(242, 132, 99), Color.FromArgb(224, 82, 33), 90f);
				graphic.FillEllipse(linearGradientBrush3, this.CloseBtn);
				graphic.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), this.CloseBtn);
				graphic.DrawString("r", new System.Drawing.Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(6, 8, 0, 0));
				LinearGradientBrush linearGradientBrush4 = new LinearGradientBrush(this.MinBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90f);
				graphic.FillEllipse(linearGradientBrush4, this.MinBtn);
				graphic.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), this.MinBtn);
				graphic.DrawString("0", new System.Drawing.Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(26, 4, 0, 0));
				if (this._EnableMaximize)
				{
					LinearGradientBrush linearGradientBrush5 = new LinearGradientBrush(this.MaxBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90f);
					graphic.FillEllipse(linearGradientBrush5, this.MaxBtn);
					graphic.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), this.MaxBtn);
					graphic.DrawString("1", new System.Drawing.Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(46, 7, 0, 0));
				}
			}
			else if (state == Ambiance_ControlBox.MouseState.Over)
			{
				if ((this.X <= 3 ? false : this.X < 20))
				{
					LinearGradientBrush linearGradientBrush6 = new LinearGradientBrush(this.CloseBtn, Color.FromArgb(248, 152, 124), Color.FromArgb(231, 92, 45), 90f);
					graphic.FillEllipse(linearGradientBrush6, this.CloseBtn);
					graphic.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), this.CloseBtn);
					graphic.DrawString("r", new System.Drawing.Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(6, 8, 0, 0));
				}
				else if ((this.X <= 23 ? false : this.X < 40))
				{
					LinearGradientBrush linearGradientBrush7 = new LinearGradientBrush(this.MinBtn, Color.FromArgb(196, 196, 196), Color.FromArgb(173, 173, 173), 90f);
					graphic.FillEllipse(linearGradientBrush7, this.MinBtn);
					graphic.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), this.MinBtn);
					graphic.DrawString("0", new System.Drawing.Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(26, 4, 0, 0));
				}
				else if ((this.X <= 43 ? false : this.X < 60))
				{
					if (this._EnableMaximize)
					{
						LinearGradientBrush linearGradientBrush8 = new LinearGradientBrush(this.MaxBtn, Color.FromArgb(196, 196, 196), Color.FromArgb(173, 173, 173), 90f);
						graphic.FillEllipse(linearGradientBrush8, this.MaxBtn);
						graphic.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), this.MaxBtn);
						graphic.DrawString("1", new System.Drawing.Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(46, 7, 0, 0));
					}
				}
			}
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			graphic.Dispose();
			bitmap.Dispose();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (!this._EnableMaximize)
			{
				base.Size = new System.Drawing.Size(44, 22);
			}
			else
			{
				base.Size = new System.Drawing.Size(64, 22);
			}
		}

		public enum MouseState
		{
			None,
			Over,
			Down
		}
	}
}