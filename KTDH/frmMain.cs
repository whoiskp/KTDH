using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTDH.FACADE;

namespace KTDH
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            initHeToaDo();
            //DrawString();
            DrawTest2D();
        }
        private void initHeToaDo()
        {
            Graphics g = clsCommonBS.Grfx;

            // SolidBrush brush = new SolidBrush(Color.DarkSlateBlue);
            int i = 0;
            for (; i < clsCommonBS.MaxOx * 2; i++)
            {
                g.DrawLine(new Pen(Color.Black), i * clsCommonBS.RangeHTD, 0, i * clsCommonBS.RangeHTD, clsCommonBS.MaxOy * clsCommonBS.RangeHTD * 2);
            }

            int j = 0;
            for (; j < clsCommonBS.MaxOy * 2; j++)
            {
                g.DrawLine(new Pen(Color.Black), 0, j * clsCommonBS.RangeHTD, clsCommonBS.MaxOx * clsCommonBS.RangeHTD * 2, j * clsCommonBS.RangeHTD);
            }

            // line Red ngang
            g.DrawLine(new Pen(Color.Red), 0, clsCommonBS.MaxOy * clsCommonBS.RangeHTD, clsCommonBS.MaxOx * clsCommonBS.RangeHTD * 2, clsCommonBS.MaxOy * clsCommonBS.RangeHTD);
            // line Red doc
            g.DrawLine(new Pen(Color.Red), clsCommonBS.MaxOx * clsCommonBS.RangeHTD, 0, clsCommonBS.MaxOx * clsCommonBS.RangeHTD, clsCommonBS.MaxOy * clsCommonBS.RangeHTD * 2);

        }

        private void info()
        {
            //Point locationOnForm = panel.FindForm().PointToClient(panel.Parent.PointToScreen(panel.Location));
            //lbTest.Text += locationOnForm.ToString();
            //lbTest.Text += "\n" + panel.Location.ToString();
            //lbTest.Text += "\nLabel: " + lbTest.Location.ToString();
            //lbTest.Text += "\nLabel: " + lbTest.FindForm().PointToClient(lbTest.Parent.PointToScreen(lbTest.Location)).ToString();
            //lbTest.Text += "\n" + this.Size.ToString();
            lbTest.Text += "\n" + this.panel.Size.ToString();

            //foreach (var item in test)
            //{

            //    lbTest.Text += "\nMa trận: " + item;
            //}
            //lbTest.Text += "\n" + "putpixel(400, 400 red)";
            //putpixel(200, 200, Color.Green);
            //clsCommonBS.HeightPanel = this.panel.Size.Height;
            //clsCommonBS.WidthPanel = this.panel.Size.Width;

            //clsCommonBS.MaxOx = (int)Math.Floor((double)clsCommonBS.WidthPanel / clsCommonBS.RangeHTD);
            //clsCommonBS.MaxOy = (int)Math.Floor((double)clsCommonBS.HeightPanel / clsCommonBS.RangeHTD);

            lbTest.Text += "\n MaxOx: " + clsCommonBS.MaxOx;
            lbTest.Text += "\n MaxOy: " + clsCommonBS.MaxOy;
        }

        private void DrawString()
        {
            System.Drawing.Graphics formGraphics = this.panel.CreateGraphics();
            string drawString = "Sample Text";
            System.Drawing.Font drawFont = new System.Drawing.Font(
                "Arial", 30);
            System.Drawing.SolidBrush drawBrush = new
                System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float x = 400f;
            float y = 400f;
            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y);
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }

        private void panel_Resize(object sender, EventArgs e)
        {
            #region Set config value
            clsCommonBS.Grfx = this.panel.CreateGraphics();
            clsCommonBS.HeightPanel = this.panel.Size.Height;
            clsCommonBS.WidthPanel = this.panel.Size.Width;

            //clsCommonBS.HeightPanel = 400;
            //clsCommonBS.WidthPanel = 400;

            clsCommonBS.MaxOx = (int)Math.Floor((double)clsCommonBS.WidthPanel / clsCommonBS.RangeHTD / 2);
            clsCommonBS.MaxOy = (int)Math.Floor((double)clsCommonBS.HeightPanel / clsCommonBS.RangeHTD / 2);

            #endregion

            this.panel.Refresh();
            initHeToaDo();
        }

        /// <summary>
        /// This funtion use for test
        /// </summary>
        private void DrawTest2D()
        {

            #region "Test Put Pixel"
            //Point p1 = new Point(0, 0);
            //Point p2 = new Point(1, 1);
            //Point p3 = new Point(-1, 1);
            //Point p4 = new Point(-1, -1);
            //Point p5 = new Point(1, -1);

            //clsHelperControl.PutPixel(p1, Color.Red);
            //clsHelperControl.PutPixel(p2, Color.Red);
            //clsHelperControl.PutPixel(p3, Color.Red);
            //clsHelperControl.PutPixel(p4, Color.Red);
            //clsHelperControl.PutPixel(p5, Color.Red);

            #endregion

            #region "Test Doan Thang "

            //DoanThang a = new DoanThang(new Point(0, 0), new Point(0, 5), Color.Red, new NetVeLienMach());
            //DoanThang b = new DoanThang(new Point(-1, -1), new Point(-5, -3), Color.Blue, new NetVeLienMach());
            //DoanThang c = new DoanThang(new Point(-5, 6), new Point(5, -6), Color.Red, new NetVeLienMach());
            //DoanThang d = new DoanThang(new Point(-5, -5), new Point(0, 0), Color.Blue, new NetVeLienMach());

            //a.VeHinh();
            //b.VeHinh();
            //c.VeHinh();
            //d.VeHinh();
            #endregion

            #region "Ve hinh tron"
            HinhTron ht1 = new HinhTron(new Point(0,0), 20, Color.Blue, new NetVeLienMach());
            ht1.VeHinh();
            #endregion
        }
    }
}
