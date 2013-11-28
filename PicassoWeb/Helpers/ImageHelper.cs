using System;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web.Routing;

namespace PicassoWeb.Helpers
{
    public static class ImageHelper {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string id,string name) {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("id", id);
            builder.MergeAttribute("name", name);
            //builder.MergeAttribute("alt", altText);
            //builder.MergeAttribute("height", height);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }

}