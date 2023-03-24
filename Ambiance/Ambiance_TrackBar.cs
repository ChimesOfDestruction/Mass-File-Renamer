using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	[DefaultEvent("ValueChanged")]
	public class Ambiance_TrackBar : Control
	{
		private GraphicsPath PipeBorder;

		private GraphicsPath FillValue;

		private Rectangle TrackBarHandleRect;

		private bool Cap;

		private int ValueDrawer;

		private System.Drawing.Size ThumbSize = new System.Drawing.Size(15, 15);

		private Rectangle TrackThumb;

		private int _Minimum = 0;

		private int _Maximum = 10;

		private int _Value = 0;

		private bool _DrawValueString = false;

		private bool _JumpToMouse = false;

		private Ambiance_TrackBar.ValueDivisor DividedValue = Ambiance_TrackBar.ValueDivisor.By1;

		public bool DrawValueString
		{
			get
			{
				return this._DrawValueString;
			}
			set
			{
				this._DrawValueString = value;
				if (!this._DrawValueString)
				{
					base.Height = 22;
				}
				else
				{
					base.Height = 35;
				}
				base.Invalidate();
			}
		}

		public bool JumpToMouse
		{
			get
			{
				return this._JumpToMouse;
			}
			set
			{
				this._JumpToMouse = value;
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
				if (value <= this._Minimum)
				{
					value = this._Minimum + 10;
				}
				if (this._Value > value)
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
				if (value >= this._Maximum)
				{
					value = this._Maximum - 10;
				}
				if (this._Value < value)
				{
					this._Value = value;
				}
				this._Minimum = value;
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
				if (this._Value != value)
				{
					if (value < this._Minimum)
					{
						this._Value = this._Minimum;
					}
					else if (value <= this._Maximum)
					{
						this._Value = value;
					}
					else
					{
						this._Value = this._Maximum;
					}
					base.Invalidate();
					if (this.ValueChanged != null)
					{
						this.ValueChanged();
					}
				}
			}
		}

		public Ambiance_TrackBar.ValueDivisor ValueDivison
		{
			get
			{
				return this.DividedValue;
			}
			set
			{
				this.DividedValue = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		public float ValueToSet
		{
			get
			{
				return (float)(this._Value / (int)this.DividedValue);
			}
			set
			{
				this.Value = (int)(value * (float)this.DividedValue);
			}
		}

		public Ambiance_TrackBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.Size = new System.Drawing.Size(80, 22);
			this.MinimumSize = new System.Drawing.Size(47, 22);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				this.ValueDrawer = checked((int)Math.Round((double)(checked(this._Value - this._Minimum)) / (double)(checked(this._Maximum - this._Minimum)) * (double)(checked(base.Width - 11))));
				this.TrackBarHandleRect = new Rectangle(this.ValueDrawer, 0, 25, 25);
				this.Cap = this.TrackBarHandleRect.Contains(e.Location);
				base.Focus();
				if (this._JumpToMouse)
				{
					this.Value = checked(this._Minimum + checked((int)Math.Round((double)(checked(this._Maximum - this._Minimum)) * ((double)e.X / (double)base.Width))));
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if ((!this.Cap || e.X <= -1 ? false : e.X < checked(base.Width + 1)))
			{
				this.Value = checked(this._Minimum + checked((int)Math.Round((double)(checked(this._Maximum - this._Minimum)) * ((double)e.X / (double)base.Width))));
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Cap = false;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.Clear(base.Parent.BackColor);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			this.TrackThumb = new Rectangle(8, 10, base.Width - 16, 2);
			this.PipeBorder = RoundRectangle.RoundRect(1, 8, base.Width - 3, 5, 2);
			try
			{
				this.ValueDrawer = (int)Math.Round((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum) * (double)(base.Width - 11));
			}
			catch (Exception exception)
			{
			}
			this.TrackBarHandleRect = new Rectangle(this.ValueDrawer, 0, 10, 20);
			graphics.SetClip(this.PipeBorder);
			graphics.FillPath(new SolidBrush(Color.FromArgb(221, 221, 221)), this.PipeBorder);
			this.FillValue = RoundRectangle.RoundRect(1, 8, this.TrackBarHandleRect.X + this.TrackBarHandleRect.Width - 4, 5, 2);
			graphics.ResetClip();
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.DrawPath(new Pen(Color.FromArgb(200, 200, 200)), this.PipeBorder);
			graphics.FillPath(new SolidBrush(Color.FromArgb(217, 99, 50)), this.FillValue);
			graphics.FillEllipse(new SolidBrush(Color.FromArgb(244, 244, 244)), this.TrackThumb.X + (int)Math.Round((double)this.TrackThumb.Width * ((double)this.Value / (double)this.Maximum)) - (int)Math.Round((double)this.ThumbSize.Width / 2), this.TrackThumb.Y + (int)Math.Round((double)this.TrackThumb.Height / 2) - (int)Math.Round((double)this.ThumbSize.Height / 2), this.ThumbSize.Width, this.ThumbSize.Height);
			graphics.DrawEllipse(new Pen(Color.FromArgb(180, 180, 180)), this.TrackThumb.X + (int)Math.Round((double)this.TrackThumb.Width * ((double)this.Value / (double)this.Maximum)) - (int)Math.Round((double)this.ThumbSize.Width / 2), this.TrackThumb.Y + (int)Math.Round((double)this.TrackThumb.Height / 2) - (int)Math.Round((double)this.ThumbSize.Height / 2), this.ThumbSize.Width, this.ThumbSize.Height);
			if (this._DrawValueString)
			{
				graphics.DrawString(Convert.ToString(this.ValueToSet), this.Font, Brushes.DimGray, 1f, 20f);
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (!this._DrawValueString)
			{
				base.Height = 22;
			}
			else
			{
				base.Height = 35;
			}
		}

		public event Ambiance_TrackBar.ValueChangedEventHandler ValueChanged;

		public delegate void ValueChangedEventHandler();

		public enum ValueDivisor
		{
			By1 = 1,
			By10 = 10,
			By100 = 100,
			By1000 = 1000
		}
	}
}