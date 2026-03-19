using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Text;

namespace Keywords.Enum
{
    //can add attributes to enum members
    public enum ErrorCode
    {
        None = 0,
        Unknown = 1,
        [Display(Name = "Connection Lost")]
        ConnectionLost = 100,
        OutlierReading = 200,
    }
}
