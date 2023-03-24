using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	public class Ambiance_ComboBox : ComboBox
	{
		private int _StartIndex = 0;

		private Color _HoverSelectionColor;

		public Color HoverSelectionColor
		{
			get
			{
				return this._HoverSelectionColor;
			}
			set
			{
				this._HoverSelectionColor = value;
				base.Invalidate();
			}
		}

		public int StartIndex
		{
			get
			{
				return this._StartIndex;
			}
			set
			{
				this._StartIndex = value;
				try
				{
					base.SelectedIndex = value;
				}
				catch
				{
				}
				base.Invalidate();
			}
		}

		public Ambiance_ComboBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.Selectable, false);
			base.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			base.DropDownStyle = ComboBoxStyle.DropDownList;
			this.BackColor = Color.FromArgb(246, 246, 246);
			this.ForeColor = Color.FromArgb(142, 142, 142);
			base.Size = new System.Drawing.Size(135, 26);
			base.ItemHeight = 20;
			base.DropDownHeight = 100;
			this.Font = new System.Drawing.Font("Segoe UI", 10f, FontStyle.Regular);
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			base.OnDrawItem(e);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Bounds, Color.FromArgb(246, 132, 85), Color.FromArgb(231, 108, 57), 90f);
			if (Convert.ToInt32(e.State & DrawItemState.Selected) == 1)
			{
				if (e.Index != -1)
				{
					e.Graphics.FillRectangle(linearGradientBrush, e.Bounds);
					e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, Brushes.WhiteSmoke, e.Bounds);
				}
			}
			else if (e.Index != -1)
			{
				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(242, 241, 240)), e.Bounds);
				e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, Brushes.DimGray, e.Bounds);
			}
			linearGradientBrush.Dispose();
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			base.SuspendLayout();
			base.Update();
			base.ResumeLayout();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			LinearGradientBrush linearGradientBrush = null;
			GraphicsPath graphicsPath = null;
			e.Graphics.Clear(base.Parent.BackColor);
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphicsPath = RoundRectangle.RoundRect(0, 0, base.Width - 1, base.Height - 1, 5);
			linearGradientBrush = new LinearGradientBrush(base.ClientRectangle, Color.FromArgb(253, 252, 252), Color.FromArgb(239, 237, 236), 90f);
			e.Graphics.SetClip(graphicsPath);
			e.Graphics.FillRectangle(linearGradientBrush, base.ClientRectangle);
			e.Graphics.ResetClip();
			e.Graphics.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), graphicsPath);
			e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(76, 76, 97)), new Rectangle(3, 0, base.Width - 20, base.Height), new StringFormat()
			{
				LineAlignment = StringAlignment.Center,
				Alignment = StringAlignment.Near
			});
			e.Graphics.DrawString("6", new System.Drawing.Font("Marlett", 13f, FontStyle.Regular), new SolidBrush(Color.FromArgb(119, 119, 118)), new Rectangle(3, 0, base.Width - 4, base.Height), new StringFormat()
			{
				LineAlignment = StringAlignment.Center,
				Alignment = StringAlignment.Far
			});
			e.Graphics.DrawLine(new Pen(Color.FromArgb(224, 222, 220)), base.Width - 24, 4, base.Width - 24, base.Height - 5);
			e.Graphics.DrawLine(new Pen(Color.FromArgb(250, 249, 249)), base.Width - 25, 4, base.Width - 25, base.Height - 5);
			graphicsPath.Dispose();
			linearGradientBrush.Dispose();
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (!this.Focused)
			{
				base.SelectionLength = 0;
			}
		}
	}
}