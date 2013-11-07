using System.Web;
using System.Web.Mvc;

namespace PicassoWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //rsanch: comentado para manejar errores personalizados
            //filters.Add(new HandleErrorAttribute());
        }
    }
}