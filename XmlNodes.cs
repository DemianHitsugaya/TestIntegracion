using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace TestIntegracion
{
    public static class XmlNodes
    {
        public static string FindText(XmlNode father)
        {
            string text = string.Empty;

            if (father.HasChildNodes)
            {
                foreach (XmlNode child in father.ChildNodes)
                {
                    text = FindText(child);
                    if (!string.IsNullOrEmpty(text))
                        break;
                }
            }
            else
            {

                if (!string.IsNullOrEmpty(father.InnerText) && father.NodeType != XmlNodeType.XmlDeclaration)
                    text = father.InnerText;
            }

            return text;


        }
    }
}
