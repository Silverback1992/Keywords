using System.ComponentModel.DataAnnotations;

namespace Keywords.Enum;

//can add attributes to enum members
public enum ErrorCode
{
    None = 0,
    Unknown = 1,
    [Display(Name = "Connection Lost")]
    ConnectionLost = 100,
    OutlierReading = 200,
}
