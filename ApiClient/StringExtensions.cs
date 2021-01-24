using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ApiClient
{
   public static class StringExtensions
    {
        public static XmlDocument GetXmlData(string xml)
        {
            var bodyxml = XElement.Parse(xml);
            bodyxml = bodyxml.RemoveAllNamespaces();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(bodyxml.ToString());
            return doc;
        }
        public static string Serialize<T>(MediaTypeFormatter formatter, T value)
        {
            // Create a dummy HTTP Content.
            Stream stream = new MemoryStream();
            var content = new StreamContent(stream);
            /// Serialize the object.
            formatter.WriteToStreamAsync(typeof(T), value, stream, content, null).Wait();
            // Read the serialized string.
            stream.Position = 0;
            return content.ReadAsStringAsync().Result;
        }
        internal static XElement RemoveAllNamespaces(this XElement e)
        {
            return new XElement(e.Name.LocalName,
               (from n in e.Nodes()
                select ((n is XElement) ? RemoveAllNamespaces(n as XElement) : n)),
               (e.HasAttributes) ? (from a in e.Attributes()
                                    where (!a.IsNamespaceDeclaration)
                                    select new XAttribute(a.Name.LocalName, a.Value)) : null);
        }
    }
}
