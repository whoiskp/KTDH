using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTDH.FACADE
{
    public class DoanThang : HinhBase
    {
        private Point firstPoint;
        private Point secondPoint;

        /// <summary>
        /// Init Duong Thang
        /// </summary>
        /// <param name="a">Point 1st</param>
        /// <param name="b">Point 2nd</param>
        /// <param name="color">Màu vẽ</param>
        /// <param name="netve">Nét Vẽ</param>
        public DoanThang(Point a, Point b, Color color, NetVe netve)
        {
            this.firstPoint = a;
            this.secondPoint = b;
            this.Mau = color;
            this.NetVe = netve;
            this.ThuatToanVe = AlgrothmDraw.Bresenham;
        }

        /// <summary>
        /// Vẽ bằng thuật toán DDA chưa xử lý nét vẽ
        /// </summary>
        private void LineDDA()
        {
            if (firstPoint != secondPoint)
            {
                #region "Init local var"
                // n : number int 
                int nDx = secondPoint.X - firstPoint.X;
                int nDy = secondPoint.Y - firstPoint.Y;
                int nX = firstPoint.X;
                float fY = firstPoint.Y;
                float m = (float)nDy / nDx;

                #endregion

                // Sinh diem tiep theo
                while (nX < secondPoint.X)
                {
                    nX++;
                    fY += m;

                    Point point = new Point(nX, (int)Math.Round(fY));
                    clsHelperControl.PutPixel(point, this.Mau);
                }
            }
        }

        /// <summary>
        /// Vẽ bằng thuật toán Bresenham chưa xử lý nét vẽ
        /// </summary>
        private void LineBresenham()
        {
            if (firstPoint != secondPoint)
            {
                #region "Init local var"

                int nX, nY, nDx, nDy, nP, nC1, nC2;
                nX = firstPoint.X;
                nY = firstPoint.Y;
                nDx = Math.Abs(secondPoint.X - firstPoint.X);
                nDy = Math.Abs(secondPoint.Y - firstPoint.Y);
                nP = 2 * nDy - nDx;
                nC1 = 2 * nDy; // dung thay the cho Pi < 0 -> Pi+1 = Pi + 2Dy;
                nC2 = 2 * (nDy - nDx); // dung thay the cho Pi >= 0 -> Pi+1 = Pi + 2Dy - 2Dx;

                int count = (nDx > nDy) ? nDx / clsCommonBS.RangeHTD : nDy / clsCommonBS.RangeHTD;

                #endregion


                while (count-- != 0)
                {
                    if (nP < 0)
                    {
                        nP += nC1;
                    }
                    else
                    {
                        nP += nC2;
                        nY = (nY < secondPoint.Y) ? (nY + clsCommonBS.RangeHTD) : (nY - clsCommonBS.RangeHTD);
                    }

                    nX = (nX == secondPoint.X) ?
                            nX : ((nX < secondPoint.X) ?
                                (nX + clsCommonBS.RangeHTD) : (nX - clsCommonBS.RangeHTD));

                    Point point = new Point(nX, nY);
                    clsHelperControl.PutPixel(point, this.Mau);
                }

            }
        }

        /// <summary>
        /// Vẽ bằng thuật toán Bresenham chưa xử lý nét vẽ
        /// </summary>
        private void LineBresenham2()
        {
            if (firstPoint != secondPoint)
            {
                #region "Init local var"

                int nX, nY, nDx, nDy, nP, nC1, nC2;
                nX = firstPoint.X;
                nY = firstPoint.Y;
                nDx = Math.Abs(secondPoint.X - firstPoint.X);
                nDy = Math.Abs(secondPoint.Y - firstPoint.Y);
                nP = 2 * nDy - nDx;
                nC1 = 2 * nDy; // dung thay the cho Pi < 0 -> Pi+1 = Pi + 2Dy;
                nC2 = 2 * (nDy - nDx); // dung thay the cho Pi >= 0 -> Pi+1 = Pi + 2Dy - 2Dx;

                int count = (nDx > nDy) ? nDx : nDy;

                #endregion


                while (count-- != 0)
                {
                    if (nP < 0)
                    {
                        nP += nC1;
                    }
                    else
                    {
                        nP += nC2;
                        nY = (nY == secondPoint.Y) ?
                            nY : ((nY < secondPoint.Y) ?
                                (nY + 1) : (nY - 1));
                    }

                    nX = (nX == secondPoint.X) ?
                            nX : ((nX < secondPoint.X) ?
                                (nX + 1) : (nX - 1));

                    Point point = new Point(nX, nY);
                    clsHelperControl.PutPixel(point, this.Mau);
                }

            }
        }

        /// <summary>
        /// Vẽ bằng thuật toán Midpoint chưa xử lý nét vẽ
        /// </summary>
        private void LineMidpoint()
        {
            if (firstPoint != secondPoint)
            {
                int nDx = Math.Abs(secondPoint.X - firstPoint.X);

                int nDy = Math.Abs(secondPoint.Y - firstPoint.Y);

                int nX = firstPoint.X;
                int nY = firstPoint.Y;

                int nP = 2 * nDy - nDx;

                while (nX < nDx - 1)
                {
                    nX = (nX >= 0) ? nX + 1 : nX - 1;
                    if (nP < 0)
                    {
                        nP += 2 * nDy;
                    }
                    else
                    {
                        nP += 2 * nDy + nDx;
                        nY = (nY >= 0) ? nY + 1 : nY - 1;
                    }
                    Point point = new Point(nX, nY);
                    clsHelperControl.PutPixel(point, this.Mau);
                }
            }
        }

        //private void DoanThangTrungThinh()
        //{
        //    int dx = Math.Abs(secondPoint.X - firstPoint.X) / Netve;
        //    int dy = Math.Abs(secondPoint.Y - firstPoint.Y) / Netve;
        //    int x = firstPoint.X, y = firstPoint.Y;
        //    int x_c = Netve, y_c = Netve;

        //    Diem temp = new Diem(x, y, A.Mau, A.Netve);
        //    temp.VeHinh();
        //    if (secondPoint.X - firstPoint.X < 0)
        //    {
        //        x_c = -x_c;
        //    }
        //    if (secondPoint.Y - firstPoint.Y < 0)
        //    {
        //        y_c = -y_c;
        //    }
        //    if (dx == 0 && dy != 0)
        //    {
        //        for (int i = 0; i <= dy; i++)
        //        {

        //            Diem temp1 = new Diem(x, y, A.Mau, A.Netve);
        //            temp1.VeHinh();
        //            y += y_c;
        //        }
        //    }
        //    else if (dy == 0 && dx != 0)
        //    {
        //        for (int i = 0; i <= dx; i++)
        //        {
        //            Diem temp1 = new Diem(x, y, A.Mau, A.Netve);
        //            temp1.VeHinh();
        //            x += x_c;
        //        }
        //    }
        //    else if (dx != 0 && dy != 0)
        //    {
        //        if (dx >= dy)
        //        {
        //            int p = 2 * dy - dx;
        //            int c1 = 2 * dy;
        //            int c2 = 2 * (dy - dx);
        //            while (Math.Abs(x - secondPoint.X) >= Netve)
        //            {
        //                if (p < 0)
        //                {
        //                    p += c1;
        //                }
        //                else
        //                {
        //                    p += c2;
        //                    y += y_c;
        //                }
        //                Diem temp1 = new Diem(x, y, A.Mau, A.Netve);
        //                temp1.VeHinh();
        //                x += x_c;
        //            }
        //        }
        //        else
        //        {
        //            int p = 2 * dy - dx;
        //            int c1 = 2 * dx;
        //            int c2 = 2 * (dx - dy);
        //            while (Math.Abs(x - secondPoint.X) >= Netve)
        //            {
        //                if (p < 0)
        //                {
        //                    p += c1;
        //                }
        //                else
        //                {
        //                    p += c2;
        //                    x += x_c;
        //                }
        //                Diem temp1 = new Diem(x, y, A.Mau, A.Netve);
        //                temp1.VeHinh();
        //                y += y_c;
        //            }
        //        }
        //    }
        //}

        private void DoanThang_Demo() // Ve duong thang co dinh dang mau
        {
            Color m = this.Mau;
            int Dx, Dy, count, temp_1, temp_2, dem = 1;
            //int temp_3, temp_4;
            Dx = secondPoint.X - firstPoint.X;
            Dy = secondPoint.Y - firstPoint.Y;
            if (Math.Abs(Dy) > Math.Abs(Dx)) count = Math.Abs(Dy);
            else count = Math.Abs(Dx);
            float x, y, delta_X, delta_Y;
            if (count > 0)
            {
                delta_X = Dx;
                delta_X /= count;
                delta_Y = Dy;
                delta_Y /= count;
                x = firstPoint.X;
                y = firstPoint.Y;
                do
                {
                    temp_1 = clsHelperControl.round(x);
                    temp_2 = clsHelperControl.round(y);
                    clsHelperControl.PutPixel(new Point(temp_1, temp_2), m);
                    // temp_3 = temp_1;
                    // temp_4 = temp_2;
                    x += delta_X;
                    y += delta_Y;
                    --count;
                    dem++;
                } while (count != -1);

            }
        }


        /// <summary>
        /// Vẽ Đoạn thẳng
        /// </summary>
        public override void VeHinh()
        {
            firstPoint = clsHelperControl.ToMachinePoint(firstPoint);
            secondPoint = clsHelperControl.ToMachinePoint(secondPoint);

            // Ve Điểm đầu
            Point point = new Point(firstPoint.X, firstPoint.Y);
            clsHelperControl.PutPixel(point, this.Mau);

            // Vẽ Điểm cuối
            point = new Point(secondPoint.X, secondPoint.Y);
            clsHelperControl.PutPixel(point, this.Mau);

            //switch (this.ThuatToanVe)
            //{
            //    case AlgrothmDraw.DDA:
            //        LineDDA();
            //        break;
            //    case AlgrothmDraw.Bresenham:
            //        LineBresenham();
            //        break;
            //    case AlgrothmDraw.Midpoint:
            //        LineMidpoint();
            //        break;
            //    default:
            //        break;
            //}
            DoanThang_Demo();
        }

        /// <summary>
        /// Lấy thông tin hình
        /// </summary>
        /// <returns>Chuỗi string chứa thông tin Hình</returns>
        public override string GetThongSo()
        {
            string str = "Điểm thứ nhất: " + firstPoint.ToString() + " - Điểm Thứ 2: " + secondPoint.ToString();
            return str;
        }

    }
}