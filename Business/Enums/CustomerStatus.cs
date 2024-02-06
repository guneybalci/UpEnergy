using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enums
{
    public enum CustomerStatus
    {
        [Description("Onay Bekliyor")]
        OnayBekliyor,
        [Description("Onaylandı")]
        Onaylandi,
        [Description("Reddedildi")]
        Reddedildi
    }
}
