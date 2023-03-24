using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	[DefaultEvent("TextChanged")]
	internal class Ambiance_TextBox : Control
	{
		public TextBox AmbianceTB = new TextBox();

		private GraphicsPath Shape;

		private int _maxchars = 32767;

		private bool _ReadOnly;

		private bool _Multiline;

		private HorizontalAlignment ALNType;

		private bool isPasswordMasked = false;

		private Pen P1;

		private SolidBrush B1;

		public int MaxLength
		{
			get
			{
				return this._maxchars;
			}
			set
			{
				this._maxchars = value;
				this.AmbianceTB.MaxLength = this.MaxLength;
				base.Invalidate();
			}
		}

		public bool Multiline
		{
			get
			{
				return this._Multiline;
			}
			set
			{
				this._Multiline = value;
				if (this.AmbianceTB != null)
				{
					this.AmbianceTB.Multiline = value;
					if (!value)
					{
						base.Height = this.AmbianceTB.Height + 10;
					}
					else
					{
						this.AmbianceTB.Height = base.Height - 10;
					}
				}
			}
		}

		public bool ReadOnly
		{
			get
			{
				return this._ReadOnly;
			}
			set
			{
				this._ReadOnly = value;
				if (this.AmbianceTB != null)
				{
					this.AmbianceTB.ReadOnly = value;
				}
			}
		}

		public HorizontalAlignment TextAlignment
		{
			get
			{
				return this.ALNType;
			}
			set
			{
				this.ALNType = value;
				base.Invalidate();
			}
		}

		public bool UseSystemPasswordChar
		{
			get
			{
				return this.isPasswordMasked;
			}
			set
			{
				this.AmbianceTB.UseSystemPasswordChar = this.UseSystemPasswordChar;
				this.isPasswordMasked = value;
				base.Invalidate();
			}
		}

		public Ambiance_TextBox()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			this.AddTextBox();
			base.Controls.Add(this.AmbianceTB);
			this.P1 = new Pen(Color.FromArgb(180, 180, 180));
			this.B1 = new SolidBrush(Color.White);
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.DimGray;
			this.Text = null;
			this.Font = new System.Drawing.Font("Tahoma", 11f);
			base.Size = new System.Drawing.Size(135, 33);
			this.DoubleBuffered = true;
		}

		private void _Enter(object Obj, EventArgs e)
		{
			this.P1 = new Pen(Color.FromArgb(205, 87, 40));
			this.Refresh();
		}

		private void _Leave(object Obj, EventArgs e)
		{
			this.P1 = new Pen(Color.FromArgb(180, 180, 180));
			this.Refresh();
		}

		private void _OnKeyDown(object Obj, KeyEventArgs e)
		{
			if ((!e.Control ? false : e.KeyCode == Keys.A))
			{
				this.AmbianceTB.SelectAll();
				e.SuppressKeyPress = true;
			}
			if ((!e.Control ? false : e.KeyCode == Keys.C))
			{
				this.AmbianceTB.Copy();
				e.SuppressKeyPress = true;
			}
		}

		public void AddTextBox()
		{
			TextBox ambianceTB = this.AmbianceTB;
			ambianceTB.Size = new System.Drawing.Size(base.Width - 10, 33);
			ambianceTB.Location = new Point(7, 4);
			ambianceTB.Text = string.Empty;
			ambianceTB.BorderStyle = BorderStyle.None;
			ambianceTB.TextAlign = HorizontalAlignment.Left;
			ambianceTB.Font = new System.Drawing.Font("Tahoma", 11f);
			ambianceTB.UseSystemPasswordChar = this.UseSystemPasswordChar;
			ambianceTB.Multiline = false;
			this.AmbianceTB.KeyDown += new KeyEventHandler(this._OnKeyDown);
			this.AmbianceTB.Enter += new EventHandler(this._Enter);
			this.AmbianceTB.Leave += new EventHandler(this._Leave);
			this.AmbianceTB.TextChanged += new EventHandler(this.OnBaseTextChanged);
		}

		private void OnBaseTextChanged(object s, EventArgs e)
		{
			this.Text = this.AmbianceTB.Text;
		}

		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this.AmbianceTB.Font = this.Font;
		}

		protected override void OnForeColorChanged(EventArgs e)
		{
			base.OnForeColorChanged(e);
			this.AmbianceTB.ForeColor = this.ForeColor;
			base.Invalidate();
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.AmbianceTB.Focus();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.SmoothingMode = SmoothingMode.AntiAlias;
			TextBox ambianceTB = this.AmbianceTB;
			ambianceTB.Width = base.Width - 10;
			ambianceTB.TextAlign = this.TextAlignment;
			ambianceTB.UseSystemPasswordChar = this.UseSystemPasswordChar;
			graphic.Clear(Color.Transparent);
			graphic.FillPath(this.B1, this.Shape);
			graphic.DrawPath(this.P1, this.Shape);
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			graphic.Dispose();
			bitmap.Dispose();
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (!this._Multiline)
			{
				base.Height = this.AmbianceTB.Height + 10;
			}
			else
			{
				this.AmbianceTB.Height = base.Height - 10;
			}
			this.Shape = new GraphicsPath();
			GraphicsPath shape = this.Shape;
			shape.AddArc(0, 0, 10, 10, 180f, 90f);
			shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
			shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
			shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
			shape.CloseAllFigures();
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			this.AmbianceTB.Text = this.Text;
			base.Invalidate();
		}
	}
}