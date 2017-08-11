using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTDH.FACADE
{
    public class HinhTron : HinhBase
    {
        private Point pTam;
        private int iBanKinh;
        private CachVe cachVe;

        public HinhTron(Point tam, int bankinh, Color color, NetVe netve)
        {
            this.pTam = tam;
            this.iBanKinh = bankinh;
            this.Mau = color;
            this.NetVe = netve;
            cachVe = CachVe.Put8pixel;
        }

        private void Midpoint_htron()
        {
            int x, y, cx, cy, p, R;
            Color m = this.Mau;
            cx = pTam.X; cy = pTam.Y;
            x = 0;
            y = R = iBanKinh * 5;
            int maxX = clsHelperControl.round((float)(Math.Sqrt(2) / 2 * R));
            // int maxX = Math.Sqrt(2) / 2 * R;
            p = 1 - R;
            clsHelperControl.Put8Pixel(new Point(x, y), new Point(cx, cy), m);
            while (x <= maxX)
            {
                if (p < 0) p += 2 * x + 3;
                else { p += 2 * (x - y) + 5; y -= 5; }
                x += 5;
                clsHelperControl.Put8Pixel(new Point(x, y), new Point(cx, cy), m);
            }
        }

        private void CircleMidpoint()
        {
            int x, y, P, R, iMaxX;
            x = 0;
            y = R = this.iBanKinh * 5;
            P = 5 / 4 - R;

            switch (cachVe)
            {
                case CachVe.Put4pixel:
                    {
                        iMaxX = R;
                        clsHelperControl.Put4Pixel(new Point(x, y), this.pTam, this.Mau);
                        while (x <= iMaxX)
                        {
                            if (P < 0)
                            {
                                P += 2 * x + 3;
                            }
                            else
                            {
                                P += 2 * x - 2 * y + 5;
                                y -= 5;
                            }
                            x += 5;
                            clsHelperControl.Put4Pixel(new Point(x, y), this.pTam, this.Mau);
                        }
                    }
                    break;
                case CachVe.Put8pixel:
                    {
                        iMaxX = (int)Math.Ceiling(R / Math.Sqrt(2));
                        clsHelperControl.Put8Pixel(new Point(x, y), this.pTam, this.Mau);
                        while (x <= iMaxX)
                        {
                            if (P < 0)
                            {
                                P += 2 * x + 3;
                            }
                            else
                            {
                                P += 2 * x - 2 * y + 5;
                                y -= 5;
                            }
                            x += 5;
                            clsHelperControl.Put8Pixel(new Point(x, y), this.pTam, this.Mau);
                        }
                    }
                    break;
            }
        }

        private void CircleBresenham()
        {
            int x, y, P, R, iMaxX;
            x = 0;
            y = R = this.iBanKinh * 5;
            P = 3 - 2 * R;

            switch (cachVe)
            {
                case CachVe.Put4pixel:
                    {
                        iMaxX = R;
                        clsHelperControl.Put4Pixel(new Point(x, y), this.pTam, this.Mau);
                        while (x <= iMaxX)
                        {
                            if (P < 0)
                            {
                                P += 4 * x + 6;
                            }
                            else
                            {
                                P += 4 * (x - y) + 10;
                                y -= 5;
                            }
                            x += 5;
                            clsHelperControl.Put4Pixel(new Point(x, y), this.pTam, this.Mau);
                        }
                    }
                    break;
                case CachVe.Put8pixel:
                    {
                        iMaxX = (int)Math.Ceiling(R / Math.Sqrt(2));
                        clsHelperControl.Put8Pixel(new Point(x, y), this.pTam, this.Mau);
                        while (x <= iMaxX)
                        {
                            if (P < 0)
                            {
                                P += 2 * x + 3;
                            }
                            else
                            {
                                P += 2 * x - 2 * y + 5;
                                y -= 5;
                            }
                            x += 5;
                            clsHelperControl.Put8Pixel(new Point(x, y), this.pTam, this.Mau);
                        }
                    }
                    break;
            }
        }

        public override void VeHinh()
        {
            pTam = clsHelperControl.ToMachinePoint(pTam);
            //Midpoint_htron();
            switch (this.ThuatToanVe)
            {
                case AlgrothmDraw.DDA:
                    break;
                case AlgrothmDraw.Bresenham:
                    CircleBresenham();
                    break;
                case AlgrothmDraw.Midpoint:
                    CircleMidpoint();
                    break;
                default:
                    break;
            }
        }

        public override string GetThongSo()
        {
            throw new NotImplementedException();
        }
    }
}
