using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	public class Ambiance_ProgressBar : Control
	{
		private int _Minimum;

		private int _Maximum = 100;

		private int _Value = 0;

		private Ambiance_ProgressBar.Alignment ALN;

		private bool _DrawHatch;

		private bool _ShowPercentage;

		private GraphicsPath GP1;

		private GraphicsPath GP2;

		private GraphicsPath GP3;

		private Rectangle R1;

		private Rectangle R2;

		private LinearGradientBrush GB1;

		private LinearGradientBrush GB2;

		private int I1;

		public bool DrawHatch
		{
			get
			{
				return this._DrawHatch;
			}
			set
			{
				this._DrawHatch = value;
				base.Invalidate();
			}
		}

		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value < 1)
				{
					value = 1;
				}
				if (value < this._Value)
				{
					this._Value = value;
				}
				this._Maximum = value;
				base.Invalidate();
			}
		}

		public int Minimum
		{
			get
			{
				return this._Minimum;
			}
			set
			{
				this._Minimum = value;
				if (value > this._Maximum)
				{
					this._Maximum = value;
				}
				if (value > this._Value)
				{
					this._Value = value;
				}
				base.Invalidate();
			}
		}

		public bool ShowPercentage
		{
			get
			{
				return this._ShowPercentage;
			}
			set
			{
				this._ShowPercentage = value;
				base.Invalidate();
			}
		}

		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (value > this._Maximum)
				{
					value = this.Maximum;
				}
				this._Value = value;
				base.Invalidate();
			}
		}

		public Ambiance_ProgressBar.Alignment ValueAlignment
		{
			get
			{
				return this.ALN;
			}
			set
			{
				this.ALN = value;
				base.Invalidate();
			}
		}

		public Ambiance_ProgressBar()
		{
			this._Maximum = 100;
			this._ShowPercentage = true;
			this._DrawHatch = true;
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			this.BackColor = Color.Transparent;
			this.DoubleBuffered = true;
		}

		public void Deincrement(int value)
		{
			this._Value -= value;
			base.Invalidate();
		}

		public void Increment(int value)
		{
			this._Value += value;
			base.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.Clear(Color.Transparent);
			graphic.SmoothingMode = SmoothingMode.HighQuality;
			this.GP1 = RoundRectangle.RoundRect(new Rectangle(0, 0, base.Width - 1, base.Height - 1), 4);
			this.GP2 = RoundRectangle.RoundRect(new Rectangle(1, 1, base.Width - 3, base.Height - 3), 4);
			this.R1 = new Rectangle(0, 2, base.Width - 1, base.Height - 1);
			this.GB1 = new LinearGradientBrush(this.R1, Color.FromArgb(255, 255, 255), Color.FromArgb(230, 230, 230), 90f);
			graphic.FillRectangle(new SolidBrush(Color.FromArgb(244, 241, 243)), this.R1);
			graphic.SetClip(this.GP1);
			graphic.FillPath(new SolidBrush(Color.FromArgb(244, 241, 243)), RoundRectangle.RoundRect(new Rectangle(1, 1, base.Width - 3, base.Height / 2 - 2), 4));
			this.I1 = (int)Math.Round((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum) * (double)(base.Width - 3));
			if (this.I1 > 1)
			{
				this.GP3 = RoundRectangle.RoundRect(new Rectangle(1, 1, this.I1, base.Height - 3), 4);
				this.R2 = new Rectangle(1, 1, this.I1, base.Height - 3);
				this.GB2 = new LinearGradientBrush(this.R2, Color.FromArgb(214, 89, 37), Color.FromArgb(223, 118, 75), 90f);
				graphic.FillPath(this.GB2, this.GP3);
				if (this._DrawHatch)
				{
					for (int i = 0; i <= (base.Width - 1) * this._Maximum / this._Value; i += 20)
					{
						graphic.DrawLine(new Pen(new SolidBrush(Color.FromArgb(25, Color.White)), 10f), new Point(Convert.ToInt32(i), 0), new Point(i - 10, base.Height));
					}
				}
				graphic.SetClip(this.GP3);
				graphic.SmoothingMode = SmoothingMode.None;
				graphic.SmoothingMode = SmoothingMode.AntiAlias;
				graphic.ResetClip();
			}
			string str = string.Concat(Convert.ToString(Convert.ToInt32(this.Value)), "%");
			float width = (float)base.Width;
			SizeF sizeF = graphic.MeasureString(str, this.Font);
			int num = (int)(width - sizeF.Width - 1f);
			int height = base.Height / 2;
			sizeF = graphic.MeasureString(str, this.Font);
			int num1 = height - (Convert.ToInt32(sizeF.Height / 2f) - 2);
			if (this._ShowPercentage)
			{
				Ambiance_ProgressBar.Alignment valueAlignment = this.ValueAlignment;
				if (valueAlignment == Ambiance_ProgressBar.Alignment.Right)
				{
					graphic.DrawString(str, new System.Drawing.Font("Segoe UI", 8f), Brushes.DimGray, new Point(num, num1));
				}
				else if (valueAlignment == Ambiance_ProgressBar.Alignment.Center)
				{
					graphic.DrawString(str, new System.Drawing.Font("Segoe UI", 8f), Brushes.DimGray, new Rectangle(0, 0, base.Width, base.Height + 2), new StringFormat()
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
				}
			}
			graphic.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), this.GP2);
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			graphic.Dispose();
			bitmap.Dispose();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 20;
			this.MinimumSize = new System.Drawing.Size(58, 20);
		}

		public enum Alignment
		{
			Right,
			Center
		}
	}
}