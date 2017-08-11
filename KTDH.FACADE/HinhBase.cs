using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTDH.FACADE
{
    public abstract class HinhBase
    {
        public HinhBase()
        {
            this.ThuatToanVe = AlgrothmDraw.Bresenham;
        }

        public NetVe NetVe { get; set; }
        public Color Mau { get; set; }
        public AlgrothmDraw ThuatToanVe { get; set; }
        public abstract void VeHinh();

        /// <summary>
        /// Lấy thông tin hình
        /// </summary>
        /// <returns>Trả về chuỗi string</returns>
        public abstract string GetThongSo();
    }
}
