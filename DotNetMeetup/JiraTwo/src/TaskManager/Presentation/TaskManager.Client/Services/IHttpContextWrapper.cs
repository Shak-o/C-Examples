namespace TaskManager.Client.Services;

public interface IHttpContextWrapper
{
    HttpContext? GetHttpContext();
}