namespace Keywords.Typeof.SmartFactory;

public static class PlayerLoader
{
    private static readonly Dictionary<string, Type> _typeRegistry = new()
    {
        { "Warrior", typeof(Warrior) },
        { "Mage", typeof(Mage) },
        { "Rogue", typeof(Rogue) }
    };

    public static object LoadPlayer(string typeNameFromSaveFile)
    {
        if (_typeRegistry.TryGetValue(typeNameFromSaveFile, out Type playerBlueprint))
        {
            Console.WriteLine($"[Engine] Found blueprint for {typeNameFromSaveFile}. Constructing...");
            return Activator.CreateInstance(playerBlueprint)!;
        }

        throw new Exception($"Unknown player type: {typeNameFromSaveFile}");

    }
}
