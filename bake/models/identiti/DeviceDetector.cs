using Microsoft.AspNetCore.Components;

namespace bake.models.identiti;

public class DeviceDetector 
{
    private readonly NavigationManager _navigationManager;

    public DeviceDetector(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public bool IsMobile(string userAgent)
    {
        return userAgent.Contains("Mobi") || userAgent.Contains("Android");
    }
    public bool IsMobile()
    {
        // Здесь можно использовать User-Agent или другие методы для определения устройства
        var userAgent = _navigationManager.ToAbsoluteUri(_navigationManager.Uri).ToString();
        return userAgent.Contains("Mobi") || userAgent.Contains("Android")|| userAgent.Contains("IOS");
    }
}