using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ambiance
{
	internal class Ambiance_Label : Label
	{
		public Ambiance_Label()
		{
			this.Font = new System.Drawing.Font("Segoe UI", 11f);
			this.ForeColor = Color.FromArgb(76, 76, 77);
			this.BackColor = Color.Transparent;
		}
	}
}