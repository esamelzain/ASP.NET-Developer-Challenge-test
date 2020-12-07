using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Developer_Challenge_test
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
