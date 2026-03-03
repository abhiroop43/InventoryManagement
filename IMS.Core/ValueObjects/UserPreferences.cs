namespace IMS.Core.ValueObjects;

public class UserPreferences
{
    public bool IsDarkModeEnabled { get; } = false;

    internal UserPreferences(bool isDarkModeEnabled)
    {
        IsDarkModeEnabled = isDarkModeEnabled;
    }

    public static UserPreferences Of(bool? isDarkModeEnabled)
    {
        return isDarkModeEnabled == null
            ? new UserPreferences(false)
            : new UserPreferences(isDarkModeEnabled.Value);
    }
}
