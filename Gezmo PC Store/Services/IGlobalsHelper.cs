using Gezmo_PC_Store.Models;

namespace Gezmo_PC_Store.Services;

public interface IGlobalsHelper
{
    public GlobalModels FetchGlobals(HttpContext httpContext);
    public void SetGlobals(HttpContext httpContext, GlobalModels globals);
}