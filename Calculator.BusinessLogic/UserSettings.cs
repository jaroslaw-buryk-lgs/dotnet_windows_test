using Microsoft.Win32;

namespace Calculator.BusinessLogic;

public class UserSettings
{
    private const string RegistryKeyPath = @"SOFTWARE\Calculator";
    private const string UserNameValueName = "UserName";

    public string? GetUserName()
    {
        try
        {
            using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                return key?.GetValue(UserNameValueName) as string;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void SetUserName(string userName)
    {
        try
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
            {
                key.SetValue(UserNameValueName, userName);
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to save user name to registry: {ex.Message}", ex);
        }
    }
}
