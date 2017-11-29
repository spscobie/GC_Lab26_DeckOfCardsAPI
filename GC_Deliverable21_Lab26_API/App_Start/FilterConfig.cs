using System.Web;
using System.Web.Mvc;

namespace GC_Deliverable21_Lab26_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
