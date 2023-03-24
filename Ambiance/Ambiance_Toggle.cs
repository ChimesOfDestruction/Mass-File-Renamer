using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	[DefaultEvent("ToggledChanged")]
	public class Ambiance_Toggle : Control
	{
		private bool _Toggled;

		private Ambiance_Toggle._Type ToggleType;

		private Rectangle Bar;

		private System.Drawing.Size cHandle = new System.Drawing.Size(15, 20);

		public bool Toggled
		{
			get
			{
				return this._Toggled;
			}
			set
			{
				this._Toggled = value;
				base.Invalidate();
				if (this.ToggledChanged != null)
				{
					this.ToggledChanged();
				}
			}
		}

		public Ambiance_Toggle._Type Type
		{
			get
			{
				return this.ToggleType;
			}
			set
			{
				this.ToggleType = value;
				base.Invalidate();
			}
		}

		public Ambiance_Toggle()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Toggled = !this.Toggled;
			base.Focus();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.Clear(base.Parent.BackColor);
			int num = 3;
			Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
			GraphicsPath graphicsPath = RoundRectangle.RoundRect(rectangle, 4);
			LinearGradientBrush linearGradientBrush = null;
			if (!this._Toggled)
			{
				num = 0;
				linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(208, 208, 208), Color.FromArgb(226, 226, 226), 90f);
			}
			else
			{
				num = 37;
				linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(231, 108, 58), Color.FromArgb(236, 113, 63), 90f);
			}
			graphics.FillPath(linearGradientBrush, graphicsPath);
			switch (this.ToggleType)
			{
				case Ambiance_Toggle._Type.OnOff:
				{
					if (!this.Toggled)
					{
						graphics.DrawString("OFF", new System.Drawing.Font("Segoe UI", 12f, FontStyle.Regular), Brushes.DimGray, (float)(this.Bar.X + 59), (float)((double)this.Bar.Y + 13.5), new StringFormat()
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					else
					{
						graphics.DrawString("ON", new System.Drawing.Font("Segoe UI", 12f, FontStyle.Regular), Brushes.WhiteSmoke, (float)(this.Bar.X + 18), (float)((double)this.Bar.Y + 13.5), new StringFormat()
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					break;
				}
				case Ambiance_Toggle._Type.YesNo:
				{
					if (!this.Toggled)
					{
						graphics.DrawString("NO", new System.Drawing.Font("Segoe UI", 12f, FontStyle.Regular), Brushes.DimGray, (float)(this.Bar.X + 59), (float)((double)this.Bar.Y + 13.5), new StringFormat()
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					else
					{
						graphics.DrawString("YES", new System.Drawing.Font("Segoe UI", 12f, FontStyle.Regular), Brushes.WhiteSmoke, (float)(this.Bar.X + 18), (float)((double)this.Bar.Y + 13.5), new StringFormat()
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					break;
				}
				case Ambiance_Toggle._Type.IO:
				{
					if (!this.Toggled)
					{
						graphics.DrawString("O", new System.Drawing.Font("Segoe UI", 12f, FontStyle.Regular), Brushes.DimGray, (float)(this.Bar.X + 59), (float)((double)this.Bar.Y + 13.5), new StringFormat()
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					else
					{
						graphics.DrawString("I", new System.Drawing.Font("Segoe UI", 12f, FontStyle.Regular), Brushes.WhiteSmoke, (float)(this.Bar.X + 18), (float)((double)this.Bar.Y + 13.5), new StringFormat()
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					break;
				}
			}
			Rectangle rectangle1 = new Rectangle(num, 0, base.Width - 38, base.Height);
			GraphicsPath graphicsPath1 = RoundRectangle.RoundRect(rectangle1, 4);
			LinearGradientBrush linearGradientBrush1 = new LinearGradientBrush(rectangle1, Color.FromArgb(253, 253, 253), Color.FromArgb(240, 238, 237), LinearGradientMode.Vertical);
			graphics.FillPath(linearGradientBrush1, graphicsPath1);
			if (!this._Toggled)
			{
				graphics.DrawPath(new Pen(Color.FromArgb(181, 181, 181)), graphicsPath1);
				graphics.DrawPath(new Pen(Color.FromArgb(181, 181, 181)), graphicsPath);
			}
			else
			{
				graphics.DrawPath(new Pen(Color.FromArgb(185, 89, 55)), graphicsPath1);
				graphics.DrawPath(new Pen(Color.FromArgb(185, 89, 55)), graphicsPath);
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Width = 79;
			base.Height = 27;
		}

		public event Ambiance_Toggle.ToggledChangedEventHandler ToggledChanged;

		public enum _Type
		{
			OnOff,
			YesNo,
			IO
		}

		public delegate void ToggledChangedEventHandler();
	}
}