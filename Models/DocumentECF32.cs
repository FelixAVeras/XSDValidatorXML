using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XsdConvertXml.Models;

public class DocumentECF32
{
    private void CreateXML(XmlNode xsdNode, XmlElement element, ref XmlDocument xml)
    {
        if (xsdNode.HasChildNodes)
        {
            var childs = xsdNode.ChildNodes;

            foreach (XmlNode node in childs)
            {
                XmlElement newElement = null;

                if (node.Name == "xs:element")
                {
                    newElement = xml.CreateElement(node.Attributes["name"].Value);

                    CreateXML(node, newElement, ref xml);

                    if (element == null)
                    {
                        xml.AppendChild(newElement);
                    }
                    else
                    {
                        element.AppendChild(newElement);
                    }
                }

                if (node.Name == "xs:attribute")
                {
                    element.SetAttribute(node.Attributes["name"].Value, "");
                }

                if ((node.Name == "xs:complexType") || 
                    (node.Name == "xs:sequence") || 
                    (node.Name == "xs:schema")) CreateXML(node, element, ref xml);
            }
        }
    }
}

