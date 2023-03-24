using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ambiance
{
	internal class Ambiance_ProgressIndicator : Control
	{
		private readonly SolidBrush BaseColor = new SolidBrush(Color.FromArgb(76, 76, 76));

		private readonly SolidBrush AnimationColor = new SolidBrush(Color.Gray);

		private readonly Timer AnimationSpeed = new Timer();

		private PointF[] FloatPoint;

		private BufferedGraphics BuffGraphics;

		private int IndicatorIndex;

		private readonly BufferedGraphicsContext GraphicsContext = BufferedGraphicsManager.Current;

		private double Rise;

		private double Run;

		private PointF _StartingFloatPoint;

		private PointF EndPoint
		{
			get
			{
				float single = Convert.ToSingle((double)this._StartingFloatPoint.Y + this.Rise);
				float single1 = Convert.ToSingle((double)this._StartingFloatPoint.X + this.Run);
				return new PointF(single1, single);
			}
		}

		public Color P_AnimationColor
		{
			get
			{
				return this.AnimationColor.Color;
			}
			set
			{
				this.AnimationColor.Color = value;
			}
		}

		public int P_AnimationSpeed
		{
			get
			{
				return this.AnimationSpeed.Interval;
			}
			set
			{
				this.AnimationSpeed.Interval = value;
			}
		}

		public Color P_BaseColor
		{
			get
			{
				return this.BaseColor.Color;
			}
			set
			{
				this.BaseColor.Color = value;
			}
		}

		public Ambiance_ProgressIndicator()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.Size = new System.Drawing.Size(80, 80);
			this.Text = string.Empty;
			this.MinimumSize = new System.Drawing.Size(80, 80);
			this.SetPoints();
			this.AnimationSpeed.Interval = 100;
		}

		private void AnimationSpeed_Tick(object sender, EventArgs e)
		{
			if (!this.IndicatorIndex.Equals(0))
			{
				this.IndicatorIndex--;
			}
			else
			{
				this.IndicatorIndex = (int)this.FloatPoint.Length - 1;
			}
			base.Invalidate(false);
		}

		private X AssignValues<X>(ref X Run, X Length)
		{
			Run = Length;
			return Length;
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			this.AnimationSpeed.Enabled = base.Enabled;
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			this.AnimationSpeed.Tick += new EventHandler(this.AnimationSpeed_Tick);
			this.AnimationSpeed.Start();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			this.BuffGraphics.Graphics.Clear(this.BackColor);
			int length = (int)this.FloatPoint.Length - 1;
			for (int i = 0; i <= length; i++)
			{
				if (this.IndicatorIndex != i)
				{
					this.BuffGraphics.Graphics.FillEllipse(this.BaseColor, this.FloatPoint[i].X, this.FloatPoint[i].Y, 15f, 15f);
				}
				else
				{
					this.BuffGraphics.Graphics.FillEllipse(this.AnimationColor, this.FloatPoint[i].X, this.FloatPoint[i].Y, 15f, 15f);
				}
			}
			this.BuffGraphics.Render(e.Graphics);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			this.SetStandardSize();
			this.UpdateGraphics();
			this.SetPoints();
		}

		private void SetPoints()
		{
			Stack<PointF> pointFs = new Stack<PointF>();
			PointF pointF = new PointF((float)base.Width / 2f, (float)base.Height / 2f);
			for (float i = 0f; i < 360f; i += 45f)
			{
				this.SetValue(pointF, (int)Math.Round((double)((double)base.Width / 2 - 15)), (double)i);
				PointF endPoint = this.EndPoint;
				endPoint = new PointF(endPoint.X - 7.5f, endPoint.Y - 7.5f);
				pointFs.Push(endPoint);
			}
			this.FloatPoint = pointFs.ToArray();
		}

		private void SetStandardSize()
		{
			int num = Math.Max(base.Width, base.Height);
			base.Size = new System.Drawing.Size(num, num);
		}

		private void SetValue(PointF StartingFloatPoint, int Length, double Angle)
		{
			double angle = 3.14159265358979 * Angle / 180;
			this._StartingFloatPoint = StartingFloatPoint;
			this.Rise = this.AssignValues<double>(ref this.Run, (double)Length);
			this.Rise = Math.Sin(angle) * this.Rise;
			this.Run = Math.Cos(angle) * this.Run;
		}

		private void UpdateGraphics()
		{
			if ((base.Width <= 0 ? false : base.Height > 0))
			{
				System.Drawing.Size size = new System.Drawing.Size(base.Width + 1, base.Height + 1);
				this.GraphicsContext.MaximumBuffer = size;
				this.BuffGraphics = this.GraphicsContext.Allocate(base.CreateGraphics(), base.ClientRectangle);
				this.BuffGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			}
		}
	}
}