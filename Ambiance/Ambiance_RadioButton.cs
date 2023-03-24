using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Ambiance
{
	[DefaultEvent("CheckedChanged")]
	internal class Ambiance_RadioButton : Control
	{
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
				this.InvalidateControls();
				if (this.CheckedChanged != null)
				{
					this.CheckedChanged(this);
				}
				base.Invalidate();
			}
		}

		public Ambiance_RadioButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.BackColor = Color.Transparent;
			this.Font = new System.Drawing.Font("Segoe UI", 12f);
			base.Width = 193;
		}

		private void InvalidateControls()
		{
			if ((!base.IsHandleCreated ? false : this._Checked))
			{
				foreach (Control control in base.Parent.Controls)
				{
					if ((control == this ? false : control is Ambiance_RadioButton))
					{
						((Ambiance_RadioButton)control).Checked = false;
					}
				}
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (!this._Checked)
			{
				this.Checked = true;
			}
			base.OnMouseDown(e);
			base.Focus();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.Clear(base.Parent.BackColor);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(new Point(0, 0), new System.Drawing.Size(14, 14)), Color.FromArgb(213, 85, 32), Color.FromArgb(224, 123, 82), 90f);
			graphics.FillEllipse(linearGradientBrush, new Rectangle(new Point(0, 0), new System.Drawing.Size(14, 14)));
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(new Rectangle(0, 0, 14, 14));
			graphics.SetClip(graphicsPath);
			graphics.ResetClip();
			graphics.DrawEllipse(new Pen(Color.FromArgb(182, 88, 55)), new Rectangle(new Point(0, 0), new System.Drawing.Size(14, 14)));
			if (this._Checked)
			{
				SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
				graphics.FillEllipse(solidBrush, new Rectangle(new Point(4, 4), new System.Drawing.Size(6, 6)));
			}
			graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(76, 76, 95)), 16f, 7f, new StringFormat()
			{
				LineAlignment = StringAlignment.Center
			});
			e.Dispose();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 15;
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.Invalidate();
			base.OnTextChanged(e);
		}

		public event Ambiance_RadioButton.CheckedChangedEventHandler CheckedChanged;

		public delegate void CheckedChangedEventHandler(object sender);

		public enum MouseState : byte
		{
			None,
			Over,
			Down,
			Block
		}
	}
}