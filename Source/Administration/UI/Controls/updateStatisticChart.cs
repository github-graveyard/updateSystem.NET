/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Properties;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class updateStatisticChart : Control {
		#region "  Public Events  "

		#region Delegates

		public delegate void RegionTooSmallForBarsEventHandler(object sender, RegionTooSmallForBarsEventArgs e);

		#endregion

		/// <summary>Raised if there is too much data applied to be displayed in bars mode</summary>
		public event RegionTooSmallForBarsEventHandler RegionTooSmallForBars;

		#endregion

		#region "  Public properties & their variables  "

		private Color _Color1 = Color.Red;
		private Color _Color2 = Color.Blue;
		private Dictionary<DateTime, int> _Data1;
		private Dictionary<DateTime, int> _Data2;
		private string _Error_NoData = "No data available!";

		private string _LegendFormat = "d.";
		private DrawMode _Mode = DrawMode.Bars;

		private string _ToolTipFormat = "Statistic for {0:MM/dd/yyyy}:" + "\r\n" + "    {1} Requests" + "\r\n" +
		                                "    {2} Downloads";

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Dictionary<DateTime, int> Data1 {
			get { return _Data1; }
			set {
				_Data1 = value;
				if (!IsInUpdate)
					RefreshChart();
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Dictionary<DateTime, int> Data2 {
			get { return _Data2; }
			set {
				_Data2 = value;
				if (!IsInUpdate)
					RefreshChart();
			}
		}

		public DrawMode Mode {
			get { return _Mode; }
			set {
				_Mode = value;
				RefreshChart();
			}
		}

		public Color Color1 {
			get { return _Color1; }
			set {
				_Color1 = value;
				RefreshChart();
			}
		}

		public Color Color2 {
			get { return _Color2; }
			set {
				_Color2 = value;
				RefreshChart();
			}
		}

		[Localizable(true), DefaultValue("No data available!")]
		public string Error_NoData {
			get { return _Error_NoData; }
			set {
				_Error_NoData = value;
				if (!IsInUpdate)
					RefreshChart();
			}
		}

		[Localizable(true),
		 DefaultValue("Statistic for {0:MM/dd/yyyy}:" + "\r\n" + "    {1} Requests" + "\r\n" + "    {2} Downloads"),
		 Editor(
		 	"System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
		 	, typeof (UITypeEditor))]
		public string ToolTipFormat {
			get { return _ToolTipFormat; }
			set { _ToolTipFormat = value; }
		}

		[Localizable(true), DefaultValue("d.")]
		public string LegendFormat {
			get { return _LegendFormat; }
			set {
				_LegendFormat = value;
				if (!IsInUpdate)
					RefreshChart();
			}
		}

		#endregion

		#region "  Readonly and overridden properties  "

		/// <summary>Returns true if this control is in update mode (no changes will be displayed), otherwise false</summary>
		/// <remarks>Call BeginUpdate to stop refreshing the chart, apply data, properties, ... and call EndUpdate to redraw it</remarks>
		public bool IsInUpdate {
			get { return (UpdatesPendingCount > 0); }
		}

		/// <summary>Returns true if this control has data, otherwise false</summary>
		public bool HasData {
			get {
				bool RetVal = true;

				if (RetVal && (_Data1 == null))
					RetVal = false;
				if (RetVal && (_Data2 == null))
					RetVal = false;
				if (RetVal && (_Data1.Count == 0))
					RetVal = false;
				if (RetVal && (_Data2.Count == 0))
					RetVal = false;

				return RetVal;
			}
		}


		/// <summary>Backgroundimage is created dynamically. Hide property from designer and from browsing</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public override Image BackgroundImage {
			get { return base.BackgroundImage; }
			set { base.BackgroundImage = value; }
		}

		/// <summary>No text property supported. Hide property from designer and from browsing</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public override string Text {
			get { return string.Empty; }
			set { }
		}

		#endregion

		#region "  Internal variables & constants  "

		/// <summary>Bar Mode: The width (in pixel) of the bars</summary>
		private const int BarWidth = 15;

		/// <summary>Bar Mode: The offset (in pixel) of the bar for the 2nd value</summary>
		private const int Bar2Distance = 5;

		/// <summary>The padding for the legend text in pixel</summary>
		private const int LegendPadding = 4;

		/// <summary>The padding for the charts main area in pixel</summary>
		private const int ChartPadding = 10;

		/// <summary>The color for the inner border (legend / chart seperator)</summary>
		private readonly Color BorderColorInner = Color.Gray;

		/// <summary>The color for the outer border (the whole control)</summary>
		private readonly Color BorderColorOuter = Color.Gray;

		/// <summary>The color for the values lines</summary>
		private readonly Color LineColor = Color.LightGray;

		/// <summary>The bounds for the main chart</summary>
		private Rectangle ChartBounds;

		/// <summary>The size of an item</summary>
		private SizeF ItemSize;

		/// <summary>The previous tool tip text</summary>
		private string PreviousToolTipText;

		/// <summary>The current tool tip text</summary>
		private string ToolTipText;

		/// <summary>Holds how much calls to BeginUpdate were made without calling EndUpdate. Must be 0 to allow refreshing the chart</summary>
		private int UpdatesPendingCount;

		/// <summary>The bounds for the X achsis legend</summary>
		private Rectangle XLegendBounds;

		/// <summary>The bounds for the Y achsis legend</summary>
		private Rectangle YLegendBounds;

		#endregion

		#region "  Event Handling  "

		/// <summary>Creates a new chart instance</summary>
		public updateStatisticChart() {
			MouseLeave += Chart_MouseLeave;
			MouseMove += Me_MouseMove;
			ForeColorChanged += Me_RefreshEvents;
			BackColorChanged += Me_RefreshEvents;
			FontChanged += Me_RefreshEvents;
			Resize += Me_RefreshEvents;
			BackColor = Color.White;
			Size = new Size(100, 100);
		}

		/// <summary>Handler for all events where the chart must be refreshed</summary>
		private void Me_RefreshEvents(object sender, EventArgs e) {
			if (!IsInUpdate)
				RefreshChart();
		}

		/// <summary>Mouse Move Event Handler. Required by the ToolTip</summary>
		private void Me_MouseMove(object sender, MouseEventArgs e) {
			ToolTipText = CreateToolTip(sender, e);

			if (ToolTipText != PreviousToolTipText) {
				RefreshChart();
				PreviousToolTipText = ToolTipText;
			}
		}

		/// <summary>Mouse Leave Event Handler. Required by the ToolTip</summary>
		private void Chart_MouseLeave(object sender, EventArgs e) {
			if (!string.IsNullOrEmpty(ToolTipText)) {
				ToolTipText = string.Empty;
				RefreshChart();
				PreviousToolTipText = ToolTipText;
			}
		}

		#endregion

		#region "  Public Subs  "

		/// <summary>Stops refreshing the chart if more than one property will be changed. Remember to call EndUpdate!</summary>
		public void BeginUpdate() {
			UpdatesPendingCount += 1;
		}

		/// <summary>Starts refreshing the chart again. If no update is pending the chart will be refreshed by itself.</summary>
		public void EndUpdate() {
			UpdatesPendingCount -= 1;
			if (UpdatesPendingCount < 0)
				UpdatesPendingCount = 0;

			if (!IsInUpdate)
				RefreshChart();
		}

		#endregion

		#region "  Internal chart processing  "

		/// <summary>Refreshes the chart. Calls RefreshChartWithData or RefreshChartWithoutData, depending on result of HasData property</summary>
		private void RefreshChart() {
			if (ClientSize == new Size())
				return;
			// Don't update if control is not completely created yet

			if (HasData) {
				RefreshValues();
				RefreshChartWithData();
			}
			else {
				RefreshChartWithoutData();
			}
		}

		/// <summary>Analyses the data and creates informations required by RefreshChartWithData</summary>
		private void RefreshValues() {
			using (Graphics g = CreateGraphics()) {
				DateTime MinDate = GetMinDate();
				DateTime MaxDate = GetMaxDate();
				int MaxValue = GetMaxValue();

				int XLegendWidth = (int) g.MeasureString(MaxValue.ToString(), Font).Width + (LegendPadding*2);
				int YLegendHeight = (int) g.MeasureString(MinDate + MaxDate.ToString(), Font).Height + ChartPadding;
				int XLegendHeight = (ClientSize.Height - YLegendHeight - ChartPadding);
				int YLegendWidth = (ClientSize.Width - XLegendWidth - ChartPadding);

				XLegendBounds = new Rectangle(0, ChartPadding, XLegendWidth, XLegendHeight);
				YLegendBounds = new Rectangle(XLegendBounds.Right, XLegendBounds.Bottom, YLegendWidth, YLegendHeight);
				ChartBounds = new Rectangle(XLegendWidth, ChartPadding, YLegendWidth, XLegendHeight);
				ItemSize = new SizeF(
					(ChartBounds.Width/(float)_Data1.Count),
					(ChartBounds.Height/(float) RoundSpecial(MaxValue)));
			}
		}

		/// <summary>Draws the chart if no data is provided</summary>
		private void RefreshChartWithoutData() {
			// Create new chart
			using (var b = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format24bppRgb)) {
				using (Graphics g = Graphics.FromImage(b)) {
					// Prepare graph
					g.Clear(BackColor);
					g.DrawRectangle(Pens.Gray, new Rectangle(0, 0, ClientSize.Width - 1, ClientSize.Height - 1));

					// Draw NoData Text
					var Format = new StringFormat();
					Format.Alignment = StringAlignment.Center;
					Format.LineAlignment = StringAlignment.Center;
					g.DrawString(_Error_NoData, Font, new SolidBrush(ForeColor),
					             new Rectangle(0, 0, ClientSize.Width - 1, ClientSize.Height - 1), Format);
				}

				// Delete old chart and apply (a copy of) the new one
				if (base.BackgroundImage != null)
					base.BackgroundImage.Dispose();
				base.BackgroundImage = (Bitmap) b.Clone();
			}
		}

		/// <summary>Prepares the chart to display data. Calls DrawValues to draw the values</summary>
		private void RefreshChartWithData() {
			// Declare variables used multiple times
			var Format = new StringFormat();
			int Index = 0;

			// Get data bounds
			int MaxValue = GetMaxValue();
			int NiceMaxValue = RoundSpecial(GetMaxValue());

			// Get x scale factor. Don't get nice value if MaxValue <= 10
			var XItemDividor = (int) (RoundSpecial(MaxValue)/(double) (XLegendBounds.Height/24.0));
			if (XItemDividor < 1)
				XItemDividor = 1;
			if (MaxValue > 10)
				XItemDividor = RoundSpecial(XItemDividor);

			// Get y scale factor. Warn if region is to small for bar mode if selected
			var YItemDividor = (int) (_Data1.Count/(ChartBounds.Width/32.0)/0.9);
			if (YItemDividor < 1)
				YItemDividor = 1;
			if (YItemDividor > 1 & _Mode == DrawMode.Bars) {
				if (RaiseRegionTooSmallForBars())
					return;
			}

			// Create new chart
			using (var b = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format24bppRgb)) {
				using (Graphics g = Graphics.FromImage(b)) {
					// Prepare graph
					g.Clear(BackColor);

					// Set text alignment to right middle
					Format.Alignment = StringAlignment.Far;
					Format.LineAlignment = StringAlignment.Center;

					// Draw x legend
					for (Index = 0; Index <= NiceMaxValue; Index += XItemDividor) {
						// Get y position & text rect
						int Y = XLegendBounds.Bottom - (int) (ItemSize.Height*Index);
						var tr = new Rectangle(XLegendBounds.Left, Y - (int) (ItemSize.Height*(double) XItemDividor/2.0),
						                       XLegendBounds.Width - LegendPadding, Convert.ToInt32(ItemSize.Height*(double) XItemDividor));
						// Draw value
						using (var sb = new SolidBrush(ForeColor)) {
							g.DrawString(Index.ToString(), Font, sb, tr, Format);
						}
						// Draw line
						if (Index > 0) {
							using (var p = new Pen(LineColor)) {
								g.DrawLine(p, ChartBounds.Left, Y, ChartBounds.Right, Y);
							}
						}
					}

					// Set text alignment to center middle
					Format.Alignment = StringAlignment.Center;
					Format.LineAlignment = StringAlignment.Center;

					// Draw y legend
					Index = 0;
					foreach (var kvp in _Data1) {
						if ((Index/(double) YItemDividor*10.0)%10.0 == 0.0) {
							int X = ChartBounds.Left + (int) (ItemSize.Width*(double) Index);
							string S = kvp.Key.ToString(_LegendFormat);
							int W = Convert.ToInt32(ItemSize.Width*(double) YItemDividor);
							using (var sb = new SolidBrush(ForeColor)) {
								g.DrawString(S, Font, sb, new Rectangle(X, YLegendBounds.Top, W, YLegendBounds.Height), Format);
							}
						}
						Index += 1;
					}

					// Draw values
					DrawValues(true, g, _Data1);
					DrawValues(false, g, _Data2);

					// Draw legend / chart seperator
					using (var p = new Pen(BorderColorInner)) {
						g.DrawLine(p, XLegendBounds.Right, XLegendBounds.Top, XLegendBounds.Right, XLegendBounds.Bottom);
						g.DrawLine(p, YLegendBounds.Left, YLegendBounds.Top, YLegendBounds.Right, YLegendBounds.Top);
					}

					// Draw x and y legend background to remove errors that may occour when pen width > 1
					using (var sb = new SolidBrush(BackColor)) {
						g.FillRectangle(sb, new Rectangle(XLegendBounds.Right - 2, XLegendBounds.Top, 2, XLegendBounds.Height));
						g.FillRectangle(sb, new Rectangle(YLegendBounds.Left, YLegendBounds.Top + 1, YLegendBounds.Width, 2));
					}

					// Draw outer border
					using (var p = new Pen(BorderColorOuter)) {
						g.DrawRectangle(p, new Rectangle(0, 0, ClientSize.Width - 1, ClientSize.Height - 1));
					}

					// Set text alignment to top left
					Format.Alignment = StringAlignment.Near;
					Format.LineAlignment = StringAlignment.Near;


					if (!string.IsNullOrEmpty(ToolTipText)) {
						// Draw tooltip
						SizeF ToolTipSize = g.MeasureString(ToolTipText, Font);
						var ToolTipRect = new Rectangle(Convert.ToInt32(ChartBounds.Right - ToolTipSize.Width - (ChartPadding*2)),
						                                ChartBounds.Top, Convert.ToInt32(ToolTipSize.Width + (2*ChartPadding)),
						                                Convert.ToInt32(ToolTipSize.Height + (2*ChartPadding)));
						using (var sb = new SolidBrush(Color.FromArgb(0xa0, BackColor))) {
							g.FillRectangle(sb, ToolTipRect);
							using (var p = new Pen(BorderColorOuter)) {
								g.DrawRectangle(p, ToolTipRect);
							}
						}
						using (var sb = new SolidBrush(ForeColor)) {
							g.DrawString(ToolTipText, Font, sb,
							             new Rectangle(ToolTipRect.X + ChartPadding, ToolTipRect.Y + ChartPadding, ToolTipRect.Width,
							                           ToolTipRect.Height), Format);
						}
					}
				}

				// Delete old chart and apply (a copy of) the new one
				if (base.BackgroundImage != null)
					base.BackgroundImage.Dispose();
				base.BackgroundImage = (Bitmap) b.Clone();
			}

			Format.Dispose();
		}

		/// <summary>Draws the values into the prepared chart using the provided display mode</summary>
		private void DrawValues(bool IsFirst, Graphics g, Dictionary<DateTime, int> Data) {
			int Index = 0;
			Color Color = (IsFirst ? _Color1 : _Color2);

			switch (_Mode) {
				case DrawMode.Bars:

					using (var Texture = new Bitmap(BarWidth, ChartBounds.Height)) {
						using (Graphics gTexture = Graphics.FromImage(Texture)) {
							gTexture.Clear(Color);
							using (Bitmap Prototype = Resources.BarTexture) {
								gTexture.DrawImage(Prototype, new Rectangle(0, 0, BarWidth, ChartBounds.Height),
								                   new Rectangle(0, 0, Prototype.Width, Prototype.Height), GraphicsUnit.Pixel);
							}
						}
						foreach (var kvp in Data) {
							int O = Convert.ToInt32((ItemSize.Width - BarWidth - Bar2Distance)/2);
							int X = ChartBounds.Left + Convert.ToInt32(ItemSize.Width*Index) + O +
							        Convert.ToInt32((IsFirst ? 0 : Bar2Distance));
							int H = Convert.ToInt32(ItemSize.Height*kvp.Value);
							int Y = ChartBounds.Bottom - H;
							g.DrawImage(Texture, new Rectangle(X, Y, BarWidth, H));
							Index += 1;
						}
					}


					break;
				case DrawMode.Lines:

					var Points = new List<Point>();
					foreach (var kvp in Data) {
						int O = Convert.ToInt32(ItemSize.Width/2);
						int X = ChartBounds.Left + Convert.ToInt32(ItemSize.Width*Index) + O;
						int Y = ChartBounds.Bottom - Convert.ToInt32(ItemSize.Height*kvp.Value);
						Points.Add(new Point(X, Y));
						Index += 1;
					}

					g.SmoothingMode = SmoothingMode.HighQuality;
					g.DrawLines(new Pen(Color, 2), Points.ToArray());
					g.SmoothingMode = SmoothingMode.Default;

					break;
				case DrawMode.Solid:

					var Path = new GraphicsPath();
					var LastPoint = new Point(ChartBounds.Left, ChartBounds.Bottom);
					foreach (var kvp in Data) {
						var O = (int) (ItemSize.Width/2);
						int X = ChartBounds.Left + Convert.ToInt32(ItemSize.Width*Index) + O;
						int Y = ChartBounds.Bottom - Convert.ToInt32(ItemSize.Height*kvp.Value);
						var NewPoint = new Point(X, Y);
						Path.AddLine(LastPoint, NewPoint);
						LastPoint = NewPoint;
						Index += 1;
					}

					Path.AddLine(LastPoint, new Point(ChartBounds.Right, ChartBounds.Bottom));
					g.SmoothingMode = SmoothingMode.HighQuality;
					using (var p = new Pen(Color, 1)) {
						g.DrawPath(p, Path);
					}

					Path.AddLine(new Point(ChartBounds.Right, ChartBounds.Bottom), new Point(ChartBounds.Left, ChartBounds.Bottom));
					Path.CloseFigure();
					Color innerColor = Color.FromArgb(100, Color);
					//using (var lgb = new LinearGradientBrush(ChartBounds, Color, Color.Transparent /*LightColor(Color)*/, LinearGradientMode.Vertical)) {
					//	g.FillPath(lgb, Path);
					//}
					using (SolidBrush brush = new SolidBrush(innerColor)) {
						g.FillPath(brush, Path);
					}

					g.SmoothingMode = SmoothingMode.Default;

					break;
			}
		}

		#endregion

		#region "  Internal helper  "

		/// <summary>Returns the minimum date found in data</summary>
		private DateTime GetMinDate() {
			DateTime RetVal = DateTime.MaxValue;

			foreach (DateTime Value in _Data1.Keys) {
				if (Value < RetVal)
					RetVal = Value;
			}
			foreach (DateTime Value in _Data2.Keys) {
				if (Value < RetVal)
					RetVal = Value;
			}

			return RetVal;
		}

		/// <summary>Returns the maximum date found in data</summary>
		private DateTime GetMaxDate() {
			DateTime RetVal = DateTime.MinValue;

			foreach (DateTime Value in _Data1.Keys) {
				if (Value > RetVal)
					RetVal = Value;
			}
			foreach (DateTime Value in _Data2.Keys) {
				if (Value > RetVal)
					RetVal = Value;
			}

			return RetVal;
		}

		/// <summary>Returns the maximum value found in data</summary>
		private int GetMaxValue() {
			int RetVal = 0;

			foreach (int Value in _Data1.Values) {
				if (Value > RetVal)
					RetVal = Value;
			}
			foreach (int Value in _Data2.Values) {
				if (Value > RetVal)
					RetVal = Value;
			}

			return RetVal;
		}

		/// <summary>
		///     Returns the next highest or same nice value. For example:
		///     4 -> 5
		///     13 -> 15
		///     175 -> 200
		///     1000 -> 1000
		/// </summary>
		private int RoundSpecial(int Base) {
			int Length = Base.ToString().Length;

			if (Length == 1)
				return Convert.ToInt32((Base <= 5 ? 5 : 10));
			// if value < 10 don't calculate it

			double tmp = Base/(Math.Pow(10, (Length - 1)));
			// get the first 2 numbers (1326 -> 1.3)
			// If the last number < 5 ...
			if ((tmp*10)%10 <= 5) {
				return Convert.ToInt32(Math.Ceiling(tmp*2)*Convert.ToInt32(Math.Pow(10, (Length - 1)))/2);
				// ... return the 5 based nice value
			}
			else {
				return Convert.ToInt32(Math.Ceiling(tmp)*Convert.ToInt32(Math.Pow(10, (Length - 1))));
				// ... return the 10 based value
			}
		}

		/// <summary>Raises the RegionTooSmallForBars Event. Returns true if painting should be interrupted, otherwise false</summary>
		private bool RaiseRegionTooSmallForBars() {
			var Args = new RegionTooSmallForBarsEventArgs();
			if (RegionTooSmallForBars != null) {
				RegionTooSmallForBars(this, Args);
			}
			return Args.CancelDrawing;
		}

		/// <summary>Lights up the provided color and returns it</summary>
		private Color LightColor(Color Color) {
			int A = Color.A;
			int R = (Convert.ToInt32(Color.R) + 1024)/5;
			int G = (Convert.ToInt32(Color.G) + 1024)/5;
			int B = (Convert.ToInt32(Color.B) + 1024)/5;

			return Color.FromArgb(A, R, G, B);
		}

		/// <summary>Creates the tooltip text</summary>
		private string CreateToolTip(object sender, MouseEventArgs e) {
			// Check if initialized and data is present
			if (ChartBounds == new Rectangle())
				return string.Empty;
			if (!HasData)
				return string.Empty;

			// Check if cursor is in chart region
			if ((e.X < ChartBounds.Left))
				return string.Empty;
			if ((e.X > ChartBounds.Right))
				return string.Empty;
			if ((e.Y < ChartBounds.Top))
				return string.Empty;
			if ((e.Y > ChartBounds.Bottom))
				return string.Empty;


			int Index = 0;
			DateTime Day = default(DateTime);
			int Value1 = 0;
			int Value2 = 0;

			// Get data from position
			foreach (var kvp in _Data1) {
				if (e.X > Convert.ToInt32(ChartBounds.Left + (ItemSize.Width*Index)) &&
				    e.X < Convert.ToInt32(ChartBounds.Left + ItemSize.Width + (ItemSize.Width*Index))) {
					Day = kvp.Key;
					Value1 = kvp.Value;
					if (_Data2.ContainsKey(kvp.Key))
						Value2 = _Data2[kvp.Key];
					break;
				}
				Index += 1;
			}

			// Check if entry found
			if (Day == new DateTime())
				return string.Empty;

			// return tooltip text
			return string.Format(_ToolTipFormat, Day, Value1, Value2);
		}

		#endregion

		#region "  Sub-Types  "

		public enum DrawMode {
			Bars = 0,
			Lines = 1,
			Solid = 2
		}

		public class RegionTooSmallForBarsEventArgs : EventArgs {
			/// <summary>If set to true the current painting will be interrupted. Stops flickering if you want to change display mode</summary>
			public bool CancelDrawing { get; set; }
		}

		#endregion
	}
}