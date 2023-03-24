using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	public class Ambiance_ThemeContainer : ContainerControl
	{
		private Rectangle HeaderRect;

		protected Ambiance_ThemeContainer.MouseState State;

		private int MoveHeight;

		private Point MouseP = new Point(0, 0);

		private bool Cap = false;

		private bool HasShown;

		private bool _Sizable = true;

		private bool _SmartBounds = true;

		private bool _RoundCorners = true;

		private bool _IsParentForm;

		private bool _ControlMode;

		private FormStartPosition _StartPosition;

		private Point GetIndexPoint;

		private bool B1x;

		private bool B2x;

		private bool B3;

		private bool B4;

		private int Current;

		private int Previous;

		private Message[] Messages = new Message[9];

		private bool WM_LMBUTTONDOWN;

		protected bool ControlMode
		{
			get
			{
				return this._ControlMode;
			}
			set
			{
				this._ControlMode = value;
				base.Invalidate();
			}
		}

		protected bool IsParentForm
		{
			get
			{
				return this._IsParentForm;
			}
		}

		protected bool IsParentMdi
		{
			get
			{
				bool flag;
				flag = (base.Parent != null ? base.Parent.Parent != null : false);
				return flag;
			}
		}

		public bool RoundCorners
		{
			get
			{
				return this._RoundCorners;
			}
			set
			{
				this._RoundCorners = value;
				base.Invalidate();
			}
		}

		public bool Sizable
		{
			get
			{
				return this._Sizable;
			}
			set
			{
				this._Sizable = value;
			}
		}

		public bool SmartBounds
		{
			get
			{
				return this._SmartBounds;
			}
			set
			{
				this._SmartBounds = value;
			}
		}

		public FormStartPosition StartPosition
		{
			get
			{
				return ((!this._IsParentForm ? true : this._ControlMode) ? this._StartPosition : base.ParentForm.StartPosition);
			}
			set
			{
				this._StartPosition = value;
				if ((!this._IsParentForm ? false : !this._ControlMode))
				{
					base.ParentForm.StartPosition = value;
				}
			}
		}

		public Ambiance_ThemeContainer()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.BackColor = Color.FromArgb(244, 241, 243);
			base.Padding = new System.Windows.Forms.Padding(20, 56, 20, 16);
			this.DoubleBuffered = true;
			this.Dock = DockStyle.Fill;
			this.MoveHeight = 48;
			this.Font = new System.Drawing.Font("Segoe UI", 9f);
		}

		private void CorrectBounds(Rectangle bounds)
		{
			if (base.Parent.Width > bounds.Width)
			{
				base.Parent.Width = bounds.Width;
			}
			if (base.Parent.Height > bounds.Height)
			{
				base.Parent.Height = bounds.Height;
			}
			Point location = base.Parent.Location;
			int x = location.X;
			location = base.Parent.Location;
			int y = location.Y;
			if (x < bounds.X)
			{
				x = bounds.X;
			}
			if (y < bounds.Y)
			{
				y = bounds.Y;
			}
			int num = bounds.X + bounds.Width;
			int y1 = bounds.Y + bounds.Height;
			if (x + base.Parent.Width > num)
			{
				x = num - base.Parent.Width;
			}
			if (y + base.Parent.Height > y1)
			{
				y = y1 - base.Parent.Height;
			}
			base.Parent.Location = new Point(x, y);
		}

		protected override void CreateHandle()
		{
			base.CreateHandle();
		}

		private void FormShown(object sender, EventArgs e)
		{
			if ((this._ControlMode ? false : !this.HasShown))
			{
				if ((this._StartPosition == FormStartPosition.CenterParent ? true : this._StartPosition == FormStartPosition.CenterScreen))
				{
					Rectangle bounds = Screen.PrimaryScreen.Bounds;
					Rectangle rectangle = base.ParentForm.Bounds;
					base.ParentForm.Location = new Point(bounds.Width / 2 - rectangle.Width / 2, bounds.Height / 2 - rectangle.Width / 2);
				}
				this.HasShown = true;
			}
		}

		private int GetIndex()
		{
			int num;
			this.GetIndexPoint = base.PointToClient(Control.MousePosition);
			this.B1x = this.GetIndexPoint.X < 7;
			this.B2x = this.GetIndexPoint.X > base.Width - 7;
			this.B3 = this.GetIndexPoint.Y < 7;
			this.B4 = this.GetIndexPoint.Y > base.Height - 7;
			if ((!this.B1x ? false : this.B3))
			{
				num = 4;
			}
			else if ((!this.B1x ? false : this.B4))
			{
				num = 7;
			}
			else if ((!this.B2x ? false : this.B3))
			{
				num = 5;
			}
			else if ((!this.B2x ? false : this.B4))
			{
				num = 8;
			}
			else if (this.B1x)
			{
				num = 1;
			}
			else if (this.B2x)
			{
				num = 2;
			}
			else if (!this.B3)
			{
				num = (!this.B4 ? 0 : 6);
			}
			else
			{
				num = 3;
			}
			return num;
		}

		private void InitializeMessages()
		{
			this.Messages[0] = Message.Create(base.Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
			for (int i = 1; i <= 8; i++)
			{
				this.Messages[i] = Message.Create(base.Parent.Handle, 161, new IntPtr(i + 9), IntPtr.Zero);
			}
		}

		private void InvalidateMouse()
		{
			this.Current = this.GetIndex();
			if (this.Current != this.Previous)
			{
				this.Previous = this.Current;
				int previous = this.Previous;
				if (previous == 0)
				{
					this.Cursor = Cursors.Default;
				}
				else
				{
					switch (previous)
					{
						case 6:
						{
							this.Cursor = Cursors.SizeNS;
							break;
						}
						case 7:
						{
							this.Cursor = Cursors.SizeNESW;
							break;
						}
						case 8:
						{
							this.Cursor = Cursors.SizeNWSE;
							break;
						}
					}
				}
			}
		}

		protected override void OnInvalidated(InvalidateEventArgs e)
		{
			base.OnInvalidated(e);
			base.ParentForm.Text = this.Text;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				this.SetState(Ambiance_ThemeContainer.MouseState.Down);
			}
			if ((!this._IsParentForm || base.ParentForm.WindowState != FormWindowState.Maximized ? !this._ControlMode : false))
			{
				if (this.HeaderRect.Contains(e.Location))
				{
					base.Capture = false;
					this.WM_LMBUTTONDOWN = true;
					this.DefWndProc(ref this.Messages[0]);
				}
				else if ((!this._Sizable ? false : this.Previous != 0))
				{
					base.Capture = false;
					this.WM_LMBUTTONDOWN = true;
					this.DefWndProc(ref this.Messages[this.Previous]);
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if ((!this._IsParentForm ? true : base.ParentForm.WindowState != FormWindowState.Maximized))
			{
				if ((!this._Sizable ? false : !this._ControlMode))
				{
					this.InvalidateMouse();
				}
			}
			if (this.Cap)
			{
				base.Parent.Location = (Point)(object)(Convert.ToDouble(Control.MousePosition) - Convert.ToDouble(this.MouseP));
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Cap = false;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.Clear(Color.FromArgb(69, 68, 63));
			graphics.DrawRectangle(new Pen(Color.FromArgb(38, 38, 38)), new Rectangle(0, 0, base.Width - 1, base.Height - 1));
			graphics.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, 36), Color.FromArgb(87, 85, 77), Color.FromArgb(69, 68, 63)), new Rectangle(1, 1, base.Width - 2, 36));
			graphics.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(69, 68, 63), Color.FromArgb(69, 68, 63)), new Rectangle(1, 36, base.Width - 2, base.Height - 46));
			graphics.DrawRectangle(new Pen(Color.FromArgb(38, 38, 38)), new Rectangle(9, 47, base.Width - 19, base.Height - 55));
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(244, 241, 243)), new Rectangle(10, 48, base.Width - 20, base.Height - 56));
			if (this._RoundCorners)
			{
				graphics.FillRectangle(Brushes.Fuchsia, 0, 0, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 1, 0, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 2, 0, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 3, 0, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 0, 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 0, 2, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 0, 3, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 1, 1, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 1, 3, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 1, 2, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 2, 1, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 3, 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 1, 0, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 2, 0, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 3, 0, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 4, 0, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 1, 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 1, 2, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 1, 3, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 2, 1, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), base.Width - 2, 3, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), base.Width - 2, 2, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), base.Width - 3, 1, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), base.Width - 4, 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 0, base.Height - 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 0, base.Height - 2, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 0, base.Height - 3, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 0, base.Height - 4, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 1, base.Height - 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 2, base.Height - 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 3, base.Height - 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 1, base.Height - 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, 1, base.Height - 2, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 1, base.Height - 3, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 1, base.Height - 4, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 3, base.Height - 2, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), 2, base.Height - 2, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 1, base.Height, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 2, base.Height, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 3, base.Height, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 4, base.Height, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 1, base.Height - 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 1, base.Height - 2, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 1, base.Height - 3, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 2, base.Height - 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 3, base.Height - 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 4, base.Height - 1, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 1, base.Height - 4, 1, 1);
				graphics.FillRectangle(Brushes.Fuchsia, base.Width - 2, base.Height - 2, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), base.Width - 2, base.Height - 3, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), base.Width - 2, base.Height - 4, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), base.Width - 4, base.Height - 2, 1, 1);
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), base.Width - 3, base.Height - 2, 1, 1);
			}
			graphics.DrawString(this.Text, new System.Drawing.Font("Tahoma", 12f, FontStyle.Bold), new SolidBrush(Color.FromArgb(223, 219, 210)), new Rectangle(0, 14, base.Width - 1, base.Height), new StringFormat()
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Near
			});
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
		}

		protected sealed override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (base.Parent != null)
			{
				this._IsParentForm = base.Parent is Form;
				if (!this._ControlMode)
				{
					this.InitializeMessages();
					if (this._IsParentForm)
					{
						base.ParentForm.FormBorderStyle = FormBorderStyle.None;
						base.ParentForm.TransparencyKey = Color.Fuchsia;
						if (!base.DesignMode)
						{
							base.ParentForm.Shown += new EventHandler(this.FormShown);
						}
					}
					base.Parent.BackColor = this.BackColor;
					base.Parent.MinimumSize = new System.Drawing.Size(261, 65);
				}
			}
		}

		protected sealed override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (!this._ControlMode)
			{
				this.HeaderRect = new Rectangle(0, 0, base.Width - 14, this.MoveHeight - 7);
			}
			base.Invalidate();
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		private void SetState(Ambiance_ThemeContainer.MouseState current)
		{
			this.State = current;
			base.Invalidate();
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if ((!this.WM_LMBUTTONDOWN ? false : m.Msg == 513))
			{
				this.WM_LMBUTTONDOWN = false;
				this.SetState(Ambiance_ThemeContainer.MouseState.Over);
				if (this._SmartBounds)
				{
					if (!this.IsParentMdi)
					{
						this.CorrectBounds(Screen.FromControl(base.Parent).WorkingArea);
					}
					else
					{
						this.CorrectBounds(new Rectangle(Point.Empty, base.Parent.Parent.Size));
					}
				}
			}
		}

		public enum MouseState
		{
			None,
			Over,
			Down,
			Block
		}
	}
}