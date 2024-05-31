namespace UserManager.AdminPanel.Helpers;

public static class CookieHelper
{
    private const string AuthCookie = "AuthToken";

    public static void SetCookie(this HttpResponse response, string token)
        => response.Cookies.Append(AuthCookie, token);

    public static string? GetCookie(this HttpRequest? request)
        => request?.Cookies[AuthCookie];
}