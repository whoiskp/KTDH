using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTDH.FACADE
{
    public class clsCommonBS
    {
        /// <summary>
        /// Graphic to draw
        /// </summary>
        public static Graphics Grfx;

        #region "Config He Toa Do User"

        public static int WidthPanel = 400;
        public static int HeightPanel = 400;

        public static int MaxOx = 80;
        public static int MaxOy = 80;

        public static int RangeHTD = 5; // Don vi pixel

        #endregion

        #region "Ma Tran Bien Doi"

        /// <summary>
        /// Tịnh tiến điểm một đoạn tx theo Ox và ty theo Oy
        /// </summary>
        /// <param name="tx">= x2 - x1</param>
        /// <param name="ty">= y2 - y1</param>
        /// <returns></returns>
        public static int[,] GetMatrixTinhTien2D(int tx, int ty)
        {
            return new int[3, 3] {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { tx, ty, 1 }
            };
        }

        /// <summary>
        /// Co giãn tỉ lệ theo trục hoành Sx và trục tung là Sy
        /// </summary>
        /// <param name="Sx">x2 = x1.Sx</param>
        /// <param name="Sy">y2 = y1.Sy</param>
        /// <returns></returns>
        public static int[,] GetMaxtrixTyLe2D(int Sx, int Sy)
        {
            return new int[3, 3] {
                { Sx, 0, 0 },
                { 0, Sy, 0 },
                { 0, 0, 1 }
            };
        }

        /// <summary>
        /// Quay quanh gốc O(0,0) một góc anpha
        /// x2 = x1.cos∂ - y1.sin∂
        /// y2 = x1.sin∂ + y1.cos∂
        /// </summary>
        /// <param name="anpha">Góc quay ngược chiều (+), cùng chiều (-)</param>
        /// <returns></returns>
        public static double[,] GetMatrixQuay2D(float anpha)
        {
            return new double[3, 3] {
                { Math.Cos(anpha), Math.Sin(anpha), 0 },
                { -Math.Sin(anpha), Math.Cos(anpha), 0 },
                { 0, 0, 1 }
            };
        }

        /// <summary>
        /// Tịnh tiến P(x, y, x) 1 đoạn theo (Tx, Ty, Tz) theo 3 trục Ox, Oy, Oz
        /// </summary>
        /// <param name="tx"></param>
        /// <param name="ty"></param>
        /// <param name="tz"></param>
        /// <returns></returns>
        public static int[,] GetMatrixTinhTien3D(int tx, int ty, int tz)
        {
            return new int[4, 4] {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { tx, ty, tz, 1}
            };
        }

        /// <summary>
        /// Biến đổi tỉ lệ hình vẽ theo Sx, Sy, Sz
        /// </summary>
        /// <param name="Sx"></param>
        /// <param name="Sy"></param>
        /// <param name="Sz"></param>
        /// <returns></returns>
        public static int[,] GetMaxtrixTyLe3D(int Sx, int Sy, int Sz)
        {
            return new int[4, 4] {
                { Sx, 0, 0, 0},
                { 0, Sy, 0, 0},
                { 0, 0, Sz, 0},
                { 0, 0,  0, 1 }
            };
        }

        /// <summary>
        /// Ma tran chieu cua phep chieu 3D to 2D
        /// Cavalier: f = 1, anpha = 45
        /// Cabinet: f = 1/2, anpha = 45
        /// </summary>
        /// <param name="f">Ti le phep chieu</param>
        /// <param name="anpha">Goc chieu</param>
        /// <returns></returns>
        public static double[,] GetMatrixChieu(double f, int anpha)
        {
            return new double[4, 4] {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { -f * Math.Cos(anpha), -f * Math.Sin(anpha), 0, 0},
                { 0, 0, 0, 1 }
            };
        }
        #endregion
    }

    /// <summary>
    /// Thuật toán vẽ hình
    /// </summary>
    public enum AlgrothmDraw
    {
        DDA, Bresenham, Midpoint
    }

    /// <summary>
    /// Cách vẽ hình tròn
    /// </summary>
    public enum CachVe
    {
        Put4pixel, Put8pixel
    }
}
