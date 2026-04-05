using System.Reflection;

namespace Keywords.Typeof.AutomaticDependencyInjection;

public class MagicEngine
{
    private List<object> _activeServices = new();

    public void Start()
    {
        Assembly userProject = Assembly.GetExecutingAssembly();

        Type magicType = typeof(IMagicService);

        var discoveredTypes = userProject.GetTypes().Where(t => magicType.IsAssignableFrom(t) && !t.IsInterface);

        foreach (Type t in discoveredTypes)
        {
            Console.WriteLine($"[Framework] found {t.Name}! Creating it now...");

            object serviceInstance = Activator.CreateInstance(t)!;

            _activeServices.Add(serviceInstance);
        }
    }
}
