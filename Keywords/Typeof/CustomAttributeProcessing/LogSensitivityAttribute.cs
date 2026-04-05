namespace Keywords.Typeof.CustomAttributeProcessing;

[AttributeUsage(AttributeTargets.Class)]
public class LogSensitivityAttribute : Attribute
{
    public required string Level { get; set; }
}
