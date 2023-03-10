using System.Web;
using System.Web.Mvc;

namespace tranminhtrung_2011061212
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
