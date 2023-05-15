using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Model.Enum
{
    public enum ReviewGradeEnum
    {
        [Description("Рекомендует")]
        Positive,
        [Description("Не рекомендует")]
        Negative
    }
}
