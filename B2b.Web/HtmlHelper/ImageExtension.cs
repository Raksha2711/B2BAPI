using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;

namespace B2b.Web
{
    public class ImageHelper
    {
        //Dictionary<string, string> _Config { get; set; }
        //public ImageHelper(Dictionary<string, string> config)
        //{
        //    _Config = config;
        //}
        public ImageHelper()
        {

        }
        public IHtmlContent Render(string path)
        {
            var baseUrl = "https://b2bpotential.s3.ap-south-1.amazonaws.com/";//_Config.Get("cdn:BaseUrl");
            baseUrl = string.IsNullOrWhiteSpace(baseUrl) ? "~/" : baseUrl;
            path = path.Replace("~/", baseUrl);
            return new HtmlString(AddVersion(path));
        }
        //public IHtmlContent RenderBlobImage(string name)
        //{
        //    if (string.IsNullOrWhiteSpace(name)) return new HtmlString("//mtimages.blob.core.windows.net/cdn-staging-admin/images/mt.png");
        //    var cdnStorage = _Config.Get("cdn:Storage");
        //    var bloburl = _Config.Get("cdn:BaseUrl");
        //    return new HtmlString(string.Format("{0}images/{1}", bloburl, name).ToLowerInvariant());
        //}
        public string AddVersion(string url)
        {
            url = url.ToLowerInvariant();
            var version = "1";//_Config.Get("cdn:Version");
            if (string.IsNullOrWhiteSpace(version)) return url;

            return url.Contains("?") ? string.Concat(url, "&v=", version) : string.Concat(url, "?v=", version);
        }
    }
}
