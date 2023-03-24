using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	public class Ambiance_NumericUpDown : Control
	{
		private GraphicsPath Shape;

		private Pen P1;

		private long _Value;

		private long _Minimum;

		private long _Maximum;

		private int Xval;

		private bool KeyboardNum;

		private Ambiance_NumericUpDown._TextAlignment MyStringAlignment;

		private Timer LongPressTimer = new Timer();

		public long Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value > this._Minimum)
				{
					this._Maximum = value;
				}
				if (this._Value > this._Maximum)
				{
					this._Value = this._Maximum;
				}
				base.Invalidate();
			}
		}

		public long Minimum
		{
			get
			{
				return this._Minimum;
			}
			set
			{
				if (value < this._Maximum)
				{
					this._Minimum = value;
				}
				if (this._Value < this._Minimum)
				{
					this._Value = this.Minimum;
				}
				base.Invalidate();
			}
		}

		public Ambiance_NumericUpDown._TextAlignment TextAlignment
		{
			get
			{
				return this.MyStringAlignment;
			}
			set
			{
				this.MyStringAlignment = value;
				base.Invalidate();
			}
		}

		public long Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (value <= this._Maximum & value >= this._Minimum)
				{
					this._Value = value;
				}
				base.Invalidate();
			}
		}

		public Ambiance_NumericUpDown()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			this.P1 = new Pen(Color.FromArgb(180, 180, 180));
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.FromArgb(76, 76, 76);
			this._Minimum = (long)0;
			this._Maximum = (long)100;
			this.Font = new System.Drawing.Font("Tahoma", 11f);
			base.Size = new System.Drawing.Size(70, 28);
			this.MinimumSize = new System.Drawing.Size(62, 28);
			this.DoubleBuffered = true;
			this.LongPressTimer.Tick += new EventHandler(this.LongPressTimer_Tick);
			this.LongPressTimer.Interval = 300;
		}

		private void ClickButton()
		{
			if ((this.Xval <= base.Width - 25 ? true : this.Xval >= base.Width - 10))
			{
				if ((this.Xval <= base.Width - 44 ? false : this.Xval < base.Width - 33))
				{
					if (this.Value - (long)1 >= this._Minimum)
					{
						this._Value -= (long)1;
					}
				}
				this.KeyboardNum = !this.KeyboardNum;
			}
			else if (this.Value + (long)1 <= this._Maximum)
			{
				this._Value += (long)1;
			}
			base.Focus();
			base.Invalidate();
		}

		public void Decrement(int Value)
		{
			this._Value -= (long)Value;
			base.Invalidate();
		}

		public void Increment(int Value)
		{
			this._Value += (long)Value;
			base.Invalidate();
		}

		private void LongPressTimer_Tick(object sender, EventArgs e)
		{
			this.ClickButton();
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			try
			{
				if (this.KeyboardNum)
				{
					string str = this._Value.ToString();
					char keyChar = e.KeyChar;
					this._Value = long.Parse(string.Concat(str, keyChar.ToString().ToString()));
				}
				if (this._Value > this._Maximum)
				{
					this._Value = this._Maximum;
				}
			}
			catch (Exception exception)
			{
			}
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			if (e.KeyCode == Keys.Back)
			{
				string str = this._Value.ToString();
				str = str.Remove(Convert.ToInt32(str.Length - 1));
				if (str.Length == 0)
				{
					str = "0";
				}
				this._Value = (long)Convert.ToInt32(str);
			}
			base.Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			this.ClickButton();
			this.LongPressTimer.Start();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.Xval = e.Location.X;
			base.Invalidate();
			if (e.X >= base.Width - 50)
			{
				this.Cursor = Cursors.Default;
			}
			else
			{
				this.Cursor = Cursors.IBeam;
			}
			if ((e.X <= base.Width - 25 ? false : e.X < base.Width - 10))
			{
				this.Cursor = Cursors.Hand;
			}
			if ((e.X <= base.Width - 44 ? false : e.X < base.Width - 33))
			{
				this.Cursor = Cursors.Hand;
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.LongPressTimer.Stop();
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			if (e.Delta <= 0)
			{
				if (this.Value - (long)1 >= this._Minimum)
				{
					this._Value -= (long)1;
				}
				base.Invalidate();
			}
			else
			{
				if (this.Value + (long)1 <= this._Maximum)
				{
					this._Value += (long)1;
				}
				base.Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphic = Graphics.FromImage(bitmap);
			LinearGradientBrush linearGradientBrush = null;
			linearGradientBrush = new LinearGradientBrush(base.ClientRectangle, Color.FromArgb(246, 246, 246), Color.FromArgb(254, 254, 254), 90f);
			graphic.SmoothingMode = SmoothingMode.AntiAlias;
			graphic.Clear(Color.Transparent);
			graphic.FillPath(linearGradientBrush, this.Shape);
			graphic.DrawPath(this.P1, this.Shape);
			graphic.DrawString("+", new System.Drawing.Font("Tahoma", 14f), new SolidBrush(Color.FromArgb(75, 75, 75)), new Rectangle(base.Width - 25, 1, 19, 30));
			graphic.DrawLine(new Pen(Color.FromArgb(229, 228, 227)), base.Width - 28, 1, base.Width - 28, base.Height - 2);
			graphic.DrawString("-", new System.Drawing.Font("Tahoma", 14f), new SolidBrush(Color.FromArgb(75, 75, 75)), new Rectangle(base.Width - 44, 1, 19, 30));
			graphic.DrawLine(new Pen(Color.FromArgb(229, 228, 227)), base.Width - 48, 1, base.Width - 48, base.Height - 2);
			Ambiance_NumericUpDown._TextAlignment myStringAlignment = this.MyStringAlignment;
			if (myStringAlignment == Ambiance_NumericUpDown._TextAlignment.Near)
			{
				graphic.DrawString(Convert.ToString(this.Value), this.Font, new SolidBrush(this.ForeColor), new Rectangle(5, 0, base.Width - 1, base.Height - 1), new StringFormat()
				{
					Alignment = StringAlignment.Near,
					LineAlignment = StringAlignment.Center
				});
			}
			else if (myStringAlignment == Ambiance_NumericUpDown._TextAlignment.Center)
			{
				graphic.DrawString(Convert.ToString(this.Value), this.Font, new SolidBrush(this.ForeColor), new Rectangle(0, 0, base.Width - 1, base.Height - 1), new StringFormat()
				{
					Alignment = StringAlignment.Center,
					LineAlignment = StringAlignment.Center
				});
			}
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			graphic.Dispose();
			bitmap.Dispose();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 28;
			this.MinimumSize = new System.Drawing.Size(93, 28);
			this.Shape = new GraphicsPath();
			this.Shape.AddArc(0, 0, 10, 10, 180f, 90f);
			this.Shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
			this.Shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
			this.Shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
			this.Shape.CloseAllFigures();
		}

		public enum _TextAlignment
		{
			Near,
			Center
		}
	}
}