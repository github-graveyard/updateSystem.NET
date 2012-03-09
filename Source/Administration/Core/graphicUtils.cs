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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace updateSystemDotNet.Administration.Core {
	internal static class graphicUtils {
		public static GraphicsPath RoundRect(int x, int y, int width, int height, int radius, int lw) {
			var path = new GraphicsPath();
			int num = radius*2;
			path.AddArc(x + lw, y, num, num, 180f, 90f);
			path.AddArc(x + ((width - num) - lw), y, num, num, 270f, 90f);
			path.AddArc(x + ((width - num) - lw), y + ((height - num) - lw), num, num, 360f, 90f);
			path.AddArc(x + lw, y + ((height - num) - lw), num, num, 90f, 90f);
			path.CloseFigure();
			return path;
		}

		public static void paintButtonBorder(PaintEventArgs e) {
			e.Graphics.FillRectangle(SystemBrushes.Control, e.ClipRectangle);
			e.Graphics.DrawLine(SystemPens.ControlLight, new Point(0, 0), new Point(e.ClipRectangle.Width, 0));
		}

		public static void paintBottomLine(PaintEventArgs e) {
			e.Graphics.DrawLine(SystemPens.ControlDark, new Point(0, e.ClipRectangle.Height - 1),
			                    new Point(e.ClipRectangle.Width, e.ClipRectangle.Height - 1));
		}

		public static void drawInsertedRectangle(PaintEventArgs e) {
			var rectTop = new Rectangle(new Point(0, 0), new Size(e.ClipRectangle.Width, 1));
			var rectBottom = new Rectangle(new Point(0, e.ClipRectangle.Height - 1), new Size(e.ClipRectangle.Width, 1));
			var brushTop = new LinearGradientBrush(rectTop, Color.White, SystemColors.ControlDark, LinearGradientMode.Horizontal);
			var brushBottom = new LinearGradientBrush(rectBottom, Color.White, SystemColors.ControlDark,
			                                          LinearGradientMode.Horizontal);
			brushTop.SetBlendTriangularShape(0.5f);
			brushBottom.SetBlendTriangularShape(0.5f);

			e.Graphics.FillRectangle(brushTop, rectTop);
			e.Graphics.FillRectangle(brushBottom, rectBottom);

			brushTop.Dispose();
			brushBottom.Dispose();
		}

		public static void paintBottomPanel(PaintEventArgs e) {
			if (e.ClipRectangle == Rectangle.Empty) {
				return;
			}

			var brush = new LinearGradientBrush(e.ClipRectangle, Color.FromArgb(246, 219, 128), Color.FromArgb(254, 251, 200),
			                                    LinearGradientMode.Vertical);
			e.Graphics.FillRectangle(brush, e.ClipRectangle);
			e.Graphics.DrawLine(SystemPens.ControlDark, new Point(0, 0), new Point(e.ClipRectangle.Width, 0));
		}

		/// <summary>Verkleinert die Größe eines Bildes.</summary>
		/// <param name="originalImage">Das Bild welches verkleinert werden soll.</param>
		/// <param name="newSize">Die neue Größe des Bildes.</param>
		/// <returns>Gibt das verkleinerte Bild zurück.</returns>
		public static Image shrinkImage(Image originalImage, Size newSize) {
			var retval = new Bitmap(newSize.Width, newSize.Height);
			using (Graphics g = Graphics.FromImage(retval)) {
				g.InterpolationMode = InterpolationMode.High;
				g.DrawImage(originalImage, new Rectangle(new Point(0, 0), newSize));
			}
			return retval;
		}

		public static Color DarkenColor(Color color, int Factor) {
			//// Farbe dunkler
			int R = 0;
			int G = 0;
			int B = 0;

			//Faktor kontrollieren
			if (Factor < 0 | Factor > 255)
				Factor = 1;

			//Farbanteile filtern
			R = color.R;
			G = color.G;
			B = color.B;

			//Farbe verdunkeln
			R = R - Factor;
			G = G - Factor;
			B = B - Factor;

			//Kontrollieren
			if (R < 0)
				R = 0;
			if (G < 0)
				G = 0;
			if (B < 0)
				B = 0;

			return Color.FromArgb(R, G, B);
		}

		public static Image ConvertBlackAndWhite(Image image) {
			Image TempImage = image;
			ImageFormat ImageFormat = TempImage.RawFormat;
			var TempBitmap = new Bitmap(TempImage, TempImage.Width, TempImage.Height);

			var NewBitmap = new Bitmap(TempBitmap.Width, TempBitmap.Height);
			Graphics NewGraphics = Graphics.FromImage(NewBitmap);
			float[][] FloatColorMatrix = {
			                             	new[] {.3f, .3f, .3f, 0, 0},
			                             	new[] {.59f, .59f, .59f, 0, 0},
			                             	new[] {.11f, .11f, .11f, 0, 0},
			                             	new float[] {0, 0, 0, 1, 0},
			                             	new float[] {0, 0, 0, 0, 1}
			                             };

			var NewColorMatrix = new ColorMatrix(FloatColorMatrix);
			var Attributes = new ImageAttributes();
			Attributes.SetColorMatrix(NewColorMatrix);
			NewGraphics.DrawImage(TempBitmap, new Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width,
			                      TempBitmap.Height, GraphicsUnit.Pixel, Attributes);
			NewGraphics.Dispose();
			return NewBitmap;
		}
	}
}