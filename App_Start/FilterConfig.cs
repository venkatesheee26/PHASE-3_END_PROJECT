using System.Web;
using System.Web.Mvc;

namespace PHASE_END_PROJECT_3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
