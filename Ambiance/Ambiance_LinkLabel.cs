using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ambiance
{
	internal class Ambiance_LinkLabel : LinkLabel
	{
		public Ambiance_LinkLabel()
		{
			this.Font = new System.Drawing.Font("Segoe UI", 11f, FontStyle.Regular);
			this.BackColor = Color.Transparent;
			base.LinkColor = Color.FromArgb(240, 119, 70);
			base.ActiveLinkColor = Color.FromArgb(221, 72, 20);
			base.VisitedLinkColor = Color.FromArgb(240, 119, 70);
			base.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
		}
	}
}