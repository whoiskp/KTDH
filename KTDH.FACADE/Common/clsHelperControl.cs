using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTDH.FACADE
{
    public class clsHelperControl
    {
        /// <summary>
        /// La cac goc tren he truc toa do, gia tri tang dan theo nguoc chieu kim dong ho
        /// </summary>
        private enum GocPhanTu
        {
            Thu_1, // x, y > 0
            Thu_2, // x < 0 , y > 0
            Thu_3, // x, y < 0
            Thu_4  // y < 0, x > 0

        }

        /// <summary>
        /// Trả về Góc phần tư chứa điểm
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private static GocPhanTu GetGocPhanTu(Point point)
        {
            if (point.Y >= 0)
            {
                if (point.X >= 0)
                {
                    return GocPhanTu.Thu_1;
                }
                else
                {
                    return GocPhanTu.Thu_2;
                }
            }
            else
            {
                if (point.X <= 0)
                {
                    return GocPhanTu.Thu_3;
                }
                else
                {
                    return GocPhanTu.Thu_4;
                }
            }
        }

        /// <summary>
        /// Convert a Machine Point to User Point
        /// </summary>
        /// <param name="machinePoint"></param>
        /// <returns></returns>
        public static Point ToUserPoint(Point machinePoint)
        {
            return new Point(machinePoint.X / clsCommonBS.RangeHTD, machinePoint.Y / clsCommonBS.RangeHTD);
        }

        /// <summary>
        /// Convert a User Point to Machine Point
        /// </summary>
        /// <param name="userPoint"></param>
        /// <returns></returns>
        public static Point ToMachinePoint(Point userPoint)
        {
            return new Point((clsCommonBS.MaxOx + userPoint.X) * clsCommonBS.RangeHTD,
                                       (clsCommonBS.MaxOy - userPoint.Y) * clsCommonBS.RangeHTD);
            #region "First Version"

            //Point point = new Point();

            //switch (GetGocPhanTu(userPoint))
            //{
            //    case GocPhanTu.Thu_1:
            //    case GocPhanTu.Thu_2:
            //    case GocPhanTu.Thu_3:
            //    case GocPhanTu.Thu_4:
            //        point = new Point((clsCommonBS.MaxOx + userPoint.X) * clsCommonBS.RangeHTD,
            //                           (clsCommonBS.MaxOy - userPoint.Y) * clsCommonBS.RangeHTD);
            //        break;
            //}

            //return point;

            #endregion
        }

        /// <summary>
        /// Lam tron toa do putpixel
        /// </summary>
        /// <param name="tds"></param>
        /// <returns></returns>
        public static int round(double tds)
        {
            int tdm;
            double sodu = tds % clsCommonBS.RangeHTD;
            if (sodu != 0)
            {
                if (sodu >= (int)(clsCommonBS.RangeHTD / 2 +1)) tdm = (int)(tds + clsCommonBS.RangeHTD - sodu);
                else tdm = (int)(tds - sodu);
            }
            else tdm = (int)tds;
            if (tdm > clsCommonBS.WidthPanel) tdm = clsCommonBS.WidthPanel;
            return tdm;
        }

        /// <summary>
        /// Put a pixel with color and graphics (Tọa độ đã được convert sang tọa độ khung nhìn)
        /// </summary>
        /// <param name="point">Tọa độ người dùng</param>
        /// <param name="color"></param>
        /// <param name="grfx">this.panel.CreateGraphics()</param>
        public static void PutPixel(Point point, Color color)
        {

            //// check if point out of panel
            //if (Math.Abs(point.X) > clsCommonBS.MaxOx
            //    || Math.Abs(point.Y) > clsCommonBS.MaxOy) return;

            //// Chuyển sang hệ tọa độ của máy để vẽ.
            //point = clsHelperControl.ToMachinePoint(point);

            // check if point out of panel
            if (point.X > clsCommonBS.WidthPanel
                || point.Y > clsCommonBS.HeightPanel) return;

            Graphics grfx = clsCommonBS.Grfx;

            Pen p = new Pen(color);
            SolidBrush b = new SolidBrush(color);
            grfx.DrawEllipse(p, point.X, point.Y, 2, 2);
            grfx.FillEllipse(b, point.X, point.Y, 2, 2);
            grfx.DrawEllipse(p, point.X - 2, point.Y - 2, 2, 2);
            grfx.FillEllipse(b, point.X - 2, point.Y - 2, 2, 2);
            grfx.DrawEllipse(p, point.X, point.Y - 2, 2, 2);
            grfx.FillEllipse(b, point.X, point.Y - 2, 2, 2);
            grfx.DrawEllipse(p, point.X - 2, point.Y, 2, 2);
            grfx.FillEllipse(b, point.X - 2, point.Y, 2, 2);

            //putcolor(point.X, point.Y, m);
        }

        /// <summary>
        /// Put 4 diem tren grfx doi xung qua tam voi color
        /// </summary>
        /// <param name="point"></param>
        /// <param name="goc"></param>
        /// <param name="color"></param>
        /// <param name="grfx">this.panel.CreateGraphics()</param>
        public static void Put4Pixel(Point point, Point tam, Color color)
        {
            //putpixel(x + cx, y + cy, m);
            PutPixel(new Point(point.X + tam.X, point.Y + tam.Y), color);
            //putpixel(-x + cx, y + cy, m);
            PutPixel(new Point(-point.X + tam.X, point.Y + tam.Y), color);
            //putpixel(x + cx, -y + cy, m);
            PutPixel(new Point(point.X + tam.X, -point.Y + tam.Y), color);
            //putpixel(-x + cx, -y + cy, m);
            PutPixel(new Point(-point.X + tam.X, -point.Y + tam.Y), color);
        }

        /// <summary>
        /// Put 8 diem tren grfx doi xung qua tam voi color
        /// </summary>
        /// <param name="point"></param>
        /// <param name="goc"></param>
        /// <param name="color"></param>
        /// <param name="grfx">this.panel.CreateGraphics()</param>
        public static void Put8Pixel(Point point, Point tam, Color color)
        {
            //putpixel(cx + x, cy + y, m);
            //putpixel(cx + x, cy - y, m);
            //putpixel(cx - x, cy + y, m);
            //putpixel(cx - x, cy - y, m);
            Put4Pixel(point, tam, color);
            //putpixel(cx + y, cy + x, m);
            PutPixel(new Point(tam.X + point.Y, tam.Y + point.X), color);
            //putpixel(cx + y, cy - x, m);
            PutPixel(new Point(tam.X + point.Y, tam.Y - point.X), color);
            //putpixel(cx - y, cy + x, m);
            PutPixel(new Point(tam.X - point.Y, tam.Y + point.X), color);
            //putpixel(cx - y, cy - x, m);
            PutPixel(new Point(tam.X - point.Y, tam.Y - point.X), color);
        }

        /// <summary>
        /// Nhân 2 ma trận bất kỳ.
        /// author: Khoa Phạm
        /// </summary>
        /// <param name="MT1">Kích thước m * n</param>
        /// <param name="MT2">Kích thước n * p</param>
        /// <returns>Ma trận kết quả m * p</returns>
        public static double[,] NhanMaTran(double[,] MT1, double[,] MT2)
        {
            int m = MT1.GetLength(0);
            int n1 = MT1.GetLength(1);

            int n2 = MT2.GetLength(0);
            int p = MT2.GetLength(1);

            // Nếu số dòng MT1 khác số cột MT2 trả về ma trận null
            if (n1 != n2)
            {
                return null;
            }

            // Ma trận kết quả
            double[,] resMaTran = new double[m, p];

            double sum;

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    sum = 0;
                    for (int r = 0; r < m; r++)
                    {
                        sum += MT1[i, r] * MT2[r, j];
                    }
                    resMaTran[i, j] = sum;
                }
            }

            return resMaTran;
        }

        /// <summary>
        /// Nhan Ma tran Bien doi voi diem can bien doi, kq la toa do cua diem qua phep bien doi
        /// </summary>
        /// <returns></returns>
        public static Point NhanMatranVoiDiem2D(double[,] MTBienDoi, Point pCanBienDoi)
        {
            double[,] maTranThuanNhat2D = new double[1, 3];
            return new Point();
        }
    }
}
