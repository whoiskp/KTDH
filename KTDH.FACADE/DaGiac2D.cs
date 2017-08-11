using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTDH.FACADE
{
    public class DaGiac2D : HinhBase
    {

        /// <summary>
        /// Danh sách các điểm trong Đa Giác, thêm vào theo thứ tự chiều xoay kim đồng hồ
        /// </summary>
        public List<Point> ListPoint { get; set; }

        /// <summary>
        ///  Số cạnh của đa giác
        /// </summary>
        public int SoCanh
        {
            get
            {
                return ListPoint.Count;
            }
        }

        /// <summary>
        /// Khởi tạo Màu và nét vẽ cho Đa Giác, List Point được set sau!
        /// </summary>
        /// <param name="mau"></param>
        /// <param name="netve"></param>
        public DaGiac2D(Color mau, NetVe netve)
        {
            this.Mau = mau;
            this.NetVe = netve;
        }

        public DaGiac2D(List<Point> listPoint, Color mau, NetVe netve)
        {
            this.ListPoint = listPoint;
            this.Mau = mau;
            this.NetVe = netve;
        }

        public override string GetThongSo()
        {
            string str = string.Empty;

            for (int i = 0; i < ListPoint.Count; i++)
            {
                str += "Tọa độ điểm thứ " + i + " : " + ListPoint[i].ToString();
            }
            return str;
        }

        public override void VeHinh()
        {
            // Vẽ các đoạn thẳng được tạo bởi các điểm trong List theo thứ tự chiều xoay kim đồng hồ
            int length = ListPoint.Count;

            // Vị trí điểm vẽ tiếp theo
            int iNextPoint;

            for (int i = 0; i < length; i++)
            {
                iNextPoint = ((i + 1) == length) ? 0 : i + 1; // trường hợp nối điểm đầu với điểm cuối
                DoanThang dt = new DoanThang(ListPoint[i], ListPoint[iNextPoint], this.Mau, this.NetVe);
                dt.VeHinh();
            }
        }
    }
}
