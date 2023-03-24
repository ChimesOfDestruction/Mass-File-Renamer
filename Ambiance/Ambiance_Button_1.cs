using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	internal class Ambiance_Button_1 : Control
	{
		private int MouseState;

		private GraphicsPath Shape;

		private LinearGradientBrush InactiveGB;

		private LinearGradientBrush PressedGB;

		private LinearGradientBrush PressedContourGB;

		private Rectangle R1;

		private Pen P1;

		private Pen P3;

		private System.Drawing.Image _Image;

		private System.Drawing.Size _ImageSize;

		private StringAlignment _TextAlignment = StringAlignment.Center;

		private Color _TextColor = Color.FromArgb(150, 150, 150);

		private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;

		public override Color ForeColor
		{
			get
			{
				return this._TextColor;
			}
			set
			{
				this._TextColor = value;
				base.Invalidate();
			}
		}

		public System.Drawing.Image Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if (value != null)
				{
					this._ImageSize = value.Size;
				}
				else
				{
					this._ImageSize = System.Drawing.Size.Empty;
				}
				this._Image = value;
				base.Invalidate();
			}
		}

		public ContentAlignment ImageAlign
		{
			get
			{
				return this._ImageAlign;
			}
			set
			{
				this._ImageAlign = value;
				base.Invalidate();
			}
		}

		protected System.Drawing.Size ImageSize
		{
			get
			{
				return this._ImageSize;
			}
		}

		public StringAlignment TextAlignment
		{
			get
			{
				return this._TextAlignment;
			}
			set
			{
				this._TextAlignment = value;
				base.Invalidate();
			}
		}

		public Ambiance_Button_1()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.BackColor = Color.Transparent;
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI", 12f);
			this.ForeColor = Color.FromArgb(76, 76, 76);
			base.Size = new System.Drawing.Size(177, 30);
			this._TextAlignment = StringAlignment.Center;
			this.P1 = new Pen(Color.FromArgb(180, 180, 180));
		}

		private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
		{
			StringFormat stringFormat = new StringFormat();
			ContentAlignment contentAlignment = _ContentAlignment;
			if (contentAlignment <= ContentAlignment.MiddleCenter)
			{
				switch (contentAlignment)
				{
					case ContentAlignment.TopLeft:
					{
						stringFormat.LineAlignment = StringAlignment.Near;
						stringFormat.Alignment = StringAlignment.Near;
						break;
					}
					case ContentAlignment.TopCenter:
					{
						stringFormat.LineAlignment = StringAlignment.Near;
						stringFormat.Alignment = StringAlignment.Center;
						break;
					}
					case ContentAlignment.TopLeft | ContentAlignment.TopCenter:
					{
						break;
					}
					case ContentAlignment.TopRight:
					{
						stringFormat.LineAlignment = StringAlignment.Near;
						stringFormat.Alignment = StringAlignment.Far;
						break;
					}
					default:
					{
						if (contentAlignment == ContentAlignment.MiddleLeft)
						{
							stringFormat.LineAlignment = StringAlignment.Center;
							stringFormat.Alignment = StringAlignment.Near;
							break;
						}
						else if (contentAlignment == ContentAlignment.MiddleCenter)
						{
							stringFormat.LineAlignment = StringAlignment.Center;
							stringFormat.Alignment = StringAlignment.Center;
							break;
						}
						else
						{
							break;
						}
					}
				}
			}
			else if (contentAlignment <= ContentAlignment.BottomLeft)
			{
				if (contentAlignment == ContentAlignment.MiddleRight)
				{
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.Alignment = StringAlignment.Far;
				}
				else if (contentAlignment == ContentAlignment.BottomLeft)
				{
					stringFormat.LineAlignment = StringAlignment.Far;
					stringFormat.Alignment = StringAlignment.Near;
				}
			}
			else if (contentAlignment == ContentAlignment.BottomCenter)
			{
				stringFormat.LineAlignment = StringAlignment.Far;
				stringFormat.Alignment = StringAlignment.Center;
			}
			else if (contentAlignment == ContentAlignment.BottomRight)
			{
				stringFormat.LineAlignment = StringAlignment.Far;
				stringFormat.Alignment = StringAlignment.Far;
			}
			return stringFormat;
		}

		private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
		{
			PointF single = new PointF();
			switch (SF.Alignment)
			{
				case StringAlignment.Near:
				{
					single.X = 2f;
					break;
				}
				case StringAlignment.Center:
				{
					single.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2f);
					break;
				}
				case StringAlignment.Far:
				{
					single.X = Area.Width - ImageArea.Width - 2f;
					break;
				}
			}
			switch (SF.LineAlignment)
			{
				case StringAlignment.Near:
				{
					single.Y = 2f;
					break;
				}
				case StringAlignment.Center:
				{
					single.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2f);
					break;
				}
				case StringAlignment.Far:
				{
					single.Y = Area.Height - ImageArea.Height - 2f;
					break;
				}
			}
			return single;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.MouseState = 1;
			base.Focus();
			base.Invalidate();
			base.OnMouseDown(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			this.MouseState = 0;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.MouseState = 0;
			base.Invalidate();
			base.OnMouseUp(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			System.Drawing.Size imageSize;
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			PointF pointF = Ambiance_Button_1.ImageLocation(this.GetStringFormat(this.ImageAlign), base.Size, this.ImageSize);
			int mouseState = this.MouseState;
			if (mouseState == 0)
			{
				graphics.FillPath(this.InactiveGB, this.Shape);
				graphics.DrawPath(this.P1, this.Shape);
				if (this.Image != null)
				{
					System.Drawing.Image image = this._Image;
					float x = pointF.X;
					float y = pointF.Y;
					float width = (float)this.ImageSize.Width;
					imageSize = this.ImageSize;
					graphics.DrawImage(image, x, y, width, (float)imageSize.Height);
					graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.R1, new StringFormat()
					{
						Alignment = this._TextAlignment,
						LineAlignment = StringAlignment.Center
					});
				}
				else
				{
					graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.R1, new StringFormat()
					{
						Alignment = this._TextAlignment,
						LineAlignment = StringAlignment.Center
					});
				}
			}
			else if (mouseState == 1)
			{
				graphics.FillPath(this.PressedGB, this.Shape);
				graphics.DrawPath(this.P3, this.Shape);
				if (this.Image != null)
				{
					System.Drawing.Image image1 = this._Image;
					float single = pointF.X;
					float y1 = pointF.Y;
					float width1 = (float)this.ImageSize.Width;
					imageSize = this.ImageSize;
					graphics.DrawImage(image1, single, y1, width1, (float)imageSize.Height);
					graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.R1, new StringFormat()
					{
						Alignment = this._TextAlignment,
						LineAlignment = StringAlignment.Center
					});
				}
				else
				{
					graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.R1, new StringFormat()
					{
						Alignment = this._TextAlignment,
						LineAlignment = StringAlignment.Center
					});
				}
			}
			base.OnPaint(e);
		}

		protected override void OnResize(EventArgs e)
		{
			if ((base.Width <= 0 ? false : base.Height > 0))
			{
				this.Shape = new GraphicsPath();
				this.R1 = new Rectangle(0, 0, base.Width, base.Height);
				this.InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.FromArgb(253, 252, 252), Color.FromArgb(239, 237, 236), 90f);
				this.PressedGB = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.FromArgb(226, 226, 226), Color.FromArgb(237, 237, 237), 90f);
				this.PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.FromArgb(167, 167, 167), Color.FromArgb(167, 167, 167), 90f);
				this.P3 = new Pen(this.PressedContourGB);
			}
			GraphicsPath shape = this.Shape;
			shape.AddArc(0, 0, 10, 10, 180f, 90f);
			shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
			shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
			shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
			shape.CloseAllFigures();
			base.Invalidate();
			base.OnResize(e);
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.Invalidate();
			base.OnTextChanged(e);
		}
	}
}