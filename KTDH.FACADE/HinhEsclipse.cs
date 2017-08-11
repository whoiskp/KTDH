using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTDH.FACADE
{
    public class HinhEsclipse : HinhBase
    {
        /// <summary>
        /// Ban kinh lớn
        /// </summary>
        private int ra;
        /// <summary>
        /// Ban kinh nho;
        /// </summary>
        private int rb;
        private Point pTam;
        public HinhEsclipse(int ra, int rb, Point tam, Color color, NetVe netve)
        {
            this.ra = ra;
            this.rb = rb;
            this.pTam = tam;
            this.Mau = color;
            this.NetVe = netve;
        }
        private void EsclipseBresenham()
        {
            float p, a2, b2;
            int x, y;
            a2 = ra * ra;
            b2 = rb * rb;
            x = 0;
            y = rb;

            p = 2 * ((float)b2 / a2) - (2 * rb) + 1;

            //ve nhanh thu 1(tu tren xuong )
            while (((float)b2 / a2) * x <= y)
            {
                clsHelperControl.Put4Pixel(new Point(x, y), this.pTam, this.Mau);
                if (p < 0)
                {
                    p = p + 2 * ((float)b2 / a2) * (2 * x + 3);
                }
                else
                {
                    p = p - 4 * y + 2 * ((float)b2 / a2) * (2 * x + 3);
                    y--;
                }
                x++;
            }

            //ve nhanh thu 2(tu duoi len )
            y = 0;
            x = ra;
            p = 2 * ((float)a2 / b2) - 2 * ra + 1;
            while (((float)a2 / b2) * y <= x)
            {
                clsHelperControl.Put4Pixel(new Point(x, y), this.pTam, this.Mau);
                if (p < 0)
                {
                    p = p + 2 * ((float)a2 / b2) * (2 * y + 3);
                }
                else
                {
                    p = p - 4 * x + 2 * ((float)a2 / b2) * (2 * y + 3);
                    x = x - 1;
                }
                y = y + 1;
            }
        }
        private void EsclipseMidpoint()
        {
            int x, y, fx, fy, a2, b2, p;
            x = 0;
            y = rb;
            a2 = ra * ra;
            b2 = rb * rb;
            fx = 0;
            fy = 2 * a2 * y;

            clsHelperControl.Put4Pixel(new Point(x, y), this.pTam, this.Mau);
            p = (int)Math.Round(b2 - (a2 * rb) + (0.25 * a2));//p=b2 - a2*b +a2/4
            while (fx < fy)
            {
                x++;
                fx += 2 * b2;

                if (p < 0)
                {
                    p += b2 * (2 * x + 3);//p=p + b2*(2x +3)
                }
                else
                {
                    y--;
                    p += b2 * (2 * x + 3) + a2 * (2 - 2 * y);//p=p +b2(2x +3) +a2(2-2y)
                    fy -= 2 * a2;
                }
                clsHelperControl.Put4Pixel(new Point(x, y), this.pTam, this.Mau);
            }

            p = (int)Math.Round(b2 * (x + 0.5) * (x + 0.5) + a2 * (y - 1) * (y - 1) - a2 * b2);
            //
            while (y > 0)
            {
                y--;
                fy -= 2 * a2;

                if (p >= 0)
                {
                    p += a2 * (3 - 2 * y); //p=p +a2(3-2y)
                }
                else
                {
                    x++;
                    fx += 2 * b2;
                    p += b2 * (2 * x + 2) + a2 * (3 - 2 * y);//p=p+ b2(2x +2) + a2(3-2y)
                }
                clsHelperControl.Put4Pixel(new Point(x, y), this.pTam, this.Mau);
            }
        }
        private void Midpoint_elip()
        {
            int x, y, cx, cy, a, b;
            cx = pTam.X; cy = pTam.Y;
            a = this.ra; b = this.rb;
            Color m = this.Mau;
            x = 0; y = b;
            int A, B;
            A = a * a;
            B = b * b;
            double p = B + A / 4 - A * b;
            x = 0;
            y = b;
            int Dx = 0;
            int Dy = 2 * A * y;
            clsHelperControl.Put4Pixel(new Point(x, y), new Point(cx, cy), m);

            while (Dx < Dy)
            {
                x++;
                Dx += 2 * B;
                if (p < 0)
                    p += B + Dx;
                else
                {
                    y--;
                    Dy -= 2 * A;
                    p += B + Dx - Dy;
                }
                //putcolor1(s.round(x), s.round(y), cx, cy, m);

                if (x % 5 == 0) clsHelperControl.Put4Pixel(new Point(x, clsHelperControl.round(y)), new Point(cx, cy), m);
            }
            p = Math.Round(B * (x + 0.5f) * (x + 0.5f) + A * (y - 1) * (y - 1) - A * B);
            while (y > 0)
            {
                y--;
                Dy -= A * 2;
                if (p > 0)
                    p += A - Dy;
                else
                {
                    x++;
                    Dx += B * 2;
                    p += A - Dy + Dx;
                }
                //putcolor1(s.round(x), s.round(y), cx, cy, m);
                if (x % 5 == 0) clsHelperControl.Put4Pixel(new Point(x, clsHelperControl.round(y)), new Point(cx, cy), m);
            }

        }
        public override string GetThongSo()
        {
            throw new NotImplementedException();
        }
        public override void VeHinh()
        {
            Midpoint_elip();
            //switch (this.ThuatToanVe)
            //{
            //    case AlgrothmDraw.DDA:
            //        break;
            //    case AlgrothmDraw.Bresenham:
            //        EsclipseBresenham();
            //        break;
            //    case AlgrothmDraw.Midpoint:
            //        EsclipseMidpoint();
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
