namespace CommonLibrary.Utilities;
public static class ValidationHelper
{
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public static bool IsValidPassword(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Length >= Constants.PasswordMinimumLength;
    }
}