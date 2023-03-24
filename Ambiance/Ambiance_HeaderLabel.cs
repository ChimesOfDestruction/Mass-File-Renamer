using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ambiance
{
	internal class Ambiance_HeaderLabel : Label
	{
		public Ambiance_HeaderLabel()
		{
			this.Font = new System.Drawing.Font("Segoe UI", 11f, FontStyle.Bold);
			this.ForeColor = Color.FromArgb(76, 76, 77);
			this.BackColor = Color.Transparent;
		}
	}
}