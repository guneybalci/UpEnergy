using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enums
{
    public enum FuelOilTypeEnum
    {
        [Description("Benzin")]
        Benzin,
        [Description("Dizel")]
        Dizel,
        [Description("LPG")]
        LPG,
        [Description("Elektrik")]
        Elektrik
    }
}
