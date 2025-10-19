using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Calculator.BusinessLogic;

public class UserSettings
{
    private const string RegistryKeyPath = @"SOFTWARE\Calculator";
    private const string UserNameValueName = "UserName";

    public string? GetUserName()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return null;
        }

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
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // On non-Windows platforms, registry is not available
            // In a real application, you might use a different storage mechanism
            return;
        }

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
