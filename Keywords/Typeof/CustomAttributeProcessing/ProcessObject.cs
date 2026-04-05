using System.Reflection;

namespace Keywords.Typeof.CustomAttributeProcessing;

public static class ProcessObject
{
    public static void Process(object userObj)
    {
        Type t = userObj.GetType();

        if (t.GetCustomAttribute<LogSensitivityAttribute>() is LogSensitivityAttribute attribute)
        {
            Console.WriteLine($"[Framework] caution! This class has {attribute.Level} sensitivity");

            if (attribute.Level == "High")
            {
                // Logic to encrypt logs or hide data
            }
        }
    }
}
