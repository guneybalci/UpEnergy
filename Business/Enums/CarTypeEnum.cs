using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Enums
{
    public enum CarTypeEnum
    {
        [Description("Binek")]
        Binek,
        [Description("Ticari")]
        Ticari,
        [Description("Motorsiklet")]
        Motorsiklet
    }
}
