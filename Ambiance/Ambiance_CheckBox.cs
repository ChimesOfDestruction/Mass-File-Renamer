using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Ambiance
{
	[DefaultEvent("CheckedChanged")]
	internal class Ambiance_CheckBox : Control
	{
		private GraphicsPath Shape;

		private LinearGradientBrush GB;

		private Rectangle R1;

		private Rectangle R2;

		private bool _Checked;

		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
				if (this.CheckedChanged != null)
				{
					this.CheckedChanged(this);
				}
				base.Invalidate();
			}
		}

		public Ambiance_CheckBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.BackColor = Color.Transparent;
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI", 12f);
			base.Size = new System.Drawing.Size(171, 26);
		}

		protected override void OnClick(EventArgs e)
		{
			this._Checked = !this._Checked;
			if (this.CheckedChanged != null)
			{
				this.CheckedChanged(this);
			}
			base.Focus();
			base.Invalidate();
			base.OnClick(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.Clear(base.Parent.BackColor);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.FillPath(this.GB, this.Shape);
			graphics.DrawPath(new Pen(Color.FromArgb(182, 88, 55)), this.Shape);
			graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(76, 76, 95)), new Rectangle(17, 0, base.Width, base.Height - 1), new StringFormat()
			{
				LineAlignment = StringAlignment.Center
			});
			if (this.Checked)
			{
				graphics.DrawString("ü", new System.Drawing.Font("Wingdings", 12f), new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(-2, 1, base.Width, base.Height + 2), new StringFormat()
				{
					LineAlignment = StringAlignment.Center
				});
			}
			e.Dispose();
		}

		protected override void OnResize(EventArgs e)
		{
			if ((base.Width <= 0 ? false : base.Height > 0))
			{
				this.Shape = new GraphicsPath();
				this.R1 = new Rectangle(17, 0, base.Width, base.Height + 1);
				this.R2 = new Rectangle(0, 0, base.Width, base.Height);
				this.GB = new LinearGradientBrush(new Rectangle(0, 0, 25, 25), Color.FromArgb(213, 85, 32), Color.FromArgb(224, 123, 82), 90f);
				GraphicsPath shape = this.Shape;
				shape.AddArc(0, 0, 7, 7, 180f, 90f);
				shape.AddArc(7, 0, 7, 7, -90f, 90f);
				shape.AddArc(7, 7, 7, 7, 0f, 90f);
				shape.AddArc(0, 7, 7, 7, 90f, 90f);
				shape.CloseAllFigures();
				base.Height = 15;
			}
			base.Invalidate();
			base.OnResize(e);
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.Invalidate();
			base.OnTextChanged(e);
		}

		public event Ambiance_CheckBox.CheckedChangedEventHandler CheckedChanged;

		public delegate void CheckedChangedEventHandler(object sender);
	}
}