using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	[DefaultEvent("TextChanged")]
	internal class Ambiance_RichTextBox : Control
	{
		public RichTextBox AmbianceRTB = new RichTextBox();

		private bool _ReadOnly;

		private bool _WordWrap;

		private bool _AutoWordSelection;

		private GraphicsPath Shape;

		private Pen P1;

		public bool AutoWordSelection
		{
			get
			{
				return this._AutoWordSelection;
			}
			set
			{
				this._AutoWordSelection = value;
				if (this.AmbianceRTB != null)
				{
					this.AmbianceRTB.AutoWordSelection = value;
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
				if (this.AmbianceRTB != null)
				{
					this.AmbianceRTB.ReadOnly = value;
				}
			}
		}

		public override string Text
		{
			get
			{
				return this.AmbianceRTB.Text;
			}
			set
			{
				this.AmbianceRTB.Text = value;
				base.Invalidate();
			}
		}

		public bool WordWrap
		{
			get
			{
				return this._WordWrap;
			}
			set
			{
				this._WordWrap = value;
				if (this.AmbianceRTB != null)
				{
					this.AmbianceRTB.WordWrap = value;
				}
			}
		}

		public Ambiance_RichTextBox()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			this.AddRichTextBox();
			base.Controls.Add(this.AmbianceRTB);
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.FromArgb(76, 76, 76);
			this.P1 = new Pen(Color.FromArgb(180, 180, 180));
			this.Text = null;
			this.Font = new System.Drawing.Font("Tahoma", 10f);
			base.Size = new System.Drawing.Size(150, 100);
			this.WordWrap = true;
			this.AutoWordSelection = false;
			this.DoubleBuffered = true;
			this.AmbianceRTB.Enter += new EventHandler(this._Enter);
			this.AmbianceRTB.Leave += new EventHandler(this._Leave);
			base.TextChanged += new EventHandler(this._TextChanged);
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

		public void _TextChanged(object s, EventArgs e)
		{
			this.AmbianceRTB.Text = this.Text;
		}

		public void AddRichTextBox()
		{
			RichTextBox ambianceRTB = this.AmbianceRTB;
			ambianceRTB.BackColor = Color.White;
			ambianceRTB.Size = new System.Drawing.Size(base.Width - 10, 100);
			ambianceRTB.Location = new Point(7, 5);
			ambianceRTB.Text = string.Empty;
			ambianceRTB.BorderStyle = BorderStyle.None;
			ambianceRTB.Font = new System.Drawing.Font("Tahoma", 10f);
			ambianceRTB.Multiline = true;
		}

		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this.AmbianceRTB.Font = this.Font;
		}

		protected override void OnForeColorChanged(EventArgs e)
		{
			base.OnForeColorChanged(e);
			this.AmbianceRTB.ForeColor = this.ForeColor;
			base.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphic = Graphics.FromImage(bitmap);
			graphic.SmoothingMode = SmoothingMode.AntiAlias;
			graphic.Clear(Color.Transparent);
			graphic.FillPath(Brushes.White, this.Shape);
			graphic.DrawPath(this.P1, this.Shape);
			graphic.Dispose();
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			bitmap.Dispose();
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Shape = new GraphicsPath();
			GraphicsPath shape = this.Shape;
			shape.AddArc(0, 0, 10, 10, 180f, 90f);
			shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
			shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
			shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
			shape.CloseAllFigures();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			this.AmbianceRTB.Size = new System.Drawing.Size(base.Width - 13, base.Height - 11);
		}
	}
}