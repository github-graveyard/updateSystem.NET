/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

/*###########################
 * MKSoftware Dialog Template
 * ##########################
 * Copyright (c) 2008 Maximilian Krauß; MKSoftware */

namespace updateSystemDotNet.Updater.UI.Components {
	internal class dlgTemplate : Form {
		private const string m_cat_name = "Dialog";
		private Color m_DescriptionColor = Color.White;
		private Image m_Image;

		private string m_Title = "#title#";
		private Color m_TitleColor = Color.White;
		private string m_description = " #description#";
		private bool m_drawTop = true;

		public dlgTemplate() {
			var f = new Font("Tahoma", 8);
			Font = f;
			MinimizeBox = false;
			MaximizeBox = false;
			ShowInTaskbar = false;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			BackColor = Color.White;
			StartPosition = FormStartPosition.CenterScreen;
		}

		[Category(m_cat_name)]
		public Color TitleColor {
			get { return m_TitleColor; }
			set {
				m_TitleColor = value;
				base.Invalidate();
			}
		}

		[Category(m_cat_name)]
		public Color DescriptionColor {
			get { return m_DescriptionColor; }
			set {
				m_DescriptionColor = value;
				base.Invalidate();
			}
		}

		[Category(m_cat_name)]
		public Image SideImage {
			get { return m_Image; }
			set {
				m_Image = value;
				Invalidate();
			}
		}

		[Category(m_cat_name)]
		public string Title {
			get { return m_Title; }
			set {
				m_Title = value;
				Invalidate();
			}
		}

		[Category(m_cat_name)]
		public string Description {
			get { return m_description; }
			set {
				m_description = value;
				Invalidate();
			}
		}

		[Category(m_cat_name)]
		public bool DrawTop {
			get { return m_drawTop; }
			set {
				m_drawTop = value;
				Invalidate();
			}
		}

		protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			Invalidate();
		}

		protected override void OnPaintBackground(PaintEventArgs e) {
			base.OnPaintBackground(e);

			//Draw Top Region
			if (m_drawTop) {
				e.Graphics.DrawLine(new Pen(Color.FromArgb(223, 223, 223), 1), new Point(0, 52), new Point(Width, 52));

				int TextWidth;
				if (m_Image == null) {
					TextWidth = 10;
				}
				else {
					TextWidth = 50;
				}

				//Draw Text
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				TextRenderer.DrawText(e.Graphics, m_Title, new Font("Tahoma", 8, FontStyle.Bold), new Point(TextWidth, 5),
				                      m_TitleColor);
				Size DesSize = TextRenderer.MeasureText(m_description, new Font("Tahoma", 8));
				var DesBounds = new Rectangle(TextWidth, 20, DesSize.Width, DesSize.Height);
				TextRenderer.DrawText(e.Graphics, m_description, new Font("Tahoma", 8), DesBounds, m_DescriptionColor);

				//DrawImage
				if (m_Image != null) {
					e.Graphics.DrawImage(m_Image, new Point(5, 10));
				}
			}

			//Draw Bottomregion
			var rectBottom = new Rectangle(0, ClientRectangle.Height - 34, ClientRectangle.Width, 34);
			e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), rectBottom);
			e.Graphics.DrawLine(new Pen(Color.FromArgb(223, 223, 223), 1), new Point(0, ClientRectangle.Height - 34),
			                    new Point(ClientRectangle.Width, ClientRectangle.Height - 34));
		}
	}
}