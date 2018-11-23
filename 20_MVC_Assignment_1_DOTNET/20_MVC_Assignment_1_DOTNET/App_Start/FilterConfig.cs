using System.Web;
using System.Web.Mvc;

namespace _20_MVC_Assignment_1_DOTNET
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
