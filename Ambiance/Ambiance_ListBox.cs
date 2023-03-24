using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	public class Ambiance_ListBox : ListBox
	{
		public Ambiance_ListBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
			this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			base.IntegralHeight = false;
			this.ItemHeight = 18;
			this.Font = new System.Drawing.Font("Seoge UI", 11f, FontStyle.Regular);
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			base.OnDrawItem(e);
			e.DrawBackground();
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Bounds, Color.FromArgb(246, 132, 85), Color.FromArgb(231, 108, 57), 90f);
			if (Convert.ToInt32(e.State & DrawItemState.Selected) == 1)
			{
				e.Graphics.FillRectangle(linearGradientBrush, e.Bounds);
			}
			using (SolidBrush solidBrush = new SolidBrush(e.ForeColor))
			{
				if (base.Items.Count != 0)
				{
					e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, solidBrush, e.Bounds);
				}
				else
				{
					return;
				}
			}
			linearGradientBrush.Dispose();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			bool flag;
			base.OnPaint(e);
			System.Drawing.Region region = new System.Drawing.Region(e.ClipRectangle);
			e.Graphics.FillRegion(new SolidBrush(this.BackColor), region);
			if (base.Items.Count > 0)
			{
				for (int i = 0; i <= base.Items.Count - 1; i++)
				{
					Rectangle itemRectangle = base.GetItemRectangle(i);
					if (e.ClipRectangle.IntersectsWith(itemRectangle))
					{
						if ((this.SelectionMode != System.Windows.Forms.SelectionMode.One || this.SelectedIndex != i) && (this.SelectionMode != System.Windows.Forms.SelectionMode.MultiSimple || !base.SelectedIndices.Contains(i)))
						{
							flag = (this.SelectionMode != System.Windows.Forms.SelectionMode.MultiExtended ? false : base.SelectedIndices.Contains(i));
						}
						else
						{
							flag = true;
						}
						if (!flag)
						{
							this.OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font, itemRectangle, i, DrawItemState.Default, Color.FromArgb(60, 60, 60), this.BackColor));
						}
						else
						{
							this.OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font, itemRectangle, i, DrawItemState.Selected, this.ForeColor, this.BackColor));
						}
						region.Complement(itemRectangle);
					}
				}
			}
		}
	}
}