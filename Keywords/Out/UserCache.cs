namespace Keywords.Out;

public static class UserCache
{
    private static readonly List<User> _userData =
    [
        new User { Id = 1, Name = "Alice" },
        new User { Id = 2, Name = "Bob" },
        new User { Id = 3, Name = "Charlie" },
        new User { Id = 4, Name = "Diana" },
    ];

    public static bool TryGetUsername(int userId, out User? user)
    {
        user = _userData.FirstOrDefault(u => u.Id == userId);
        return user != null;
    }
}
