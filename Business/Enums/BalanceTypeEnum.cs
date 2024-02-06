using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enums
{
    public enum BalanceTypeEnum
    {
        [Description("Hediye")]
        Gift,
        [Description("Kredi")]
        Credit,
        [Description("Ön Ödeme")]
        DownPayment
    }
}
