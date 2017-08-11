using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTDH.FACADE
{
    public enum KieuNetVe
    {
        LienMach,
        DutDoan
    }

    public abstract class NetVe
    {
        public int DoRong { get; set; }
        public KieuNetVe TypeNetVe { get; set; }
    }
}
