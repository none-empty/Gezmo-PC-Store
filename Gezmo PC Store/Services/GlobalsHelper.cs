using System.Text.Json;
using Gezmo_PC_Store.Models;

namespace Gezmo_PC_Store.Services;

public class GlobalsHelper:IGlobalsHelper
{
    public GlobalModels FetchGlobals(HttpContext httpContext)
    {
        var globalsJson = httpContext.Session.GetString("Globals");
        if (!string.IsNullOrEmpty(globalsJson))
        {
            return JsonSerializer.Deserialize<GlobalModels>(globalsJson);
        }
        return null;
    }
}