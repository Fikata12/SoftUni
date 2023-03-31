using System.Text;
using System.Xml.Serialization;

namespace Trucks.Utilities.XmlConvert
{
    public static class XmlConvert
    {
        public static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            using (StringReader reader = new StringReader(inputXml))
            {
                return (T)serializer.Deserialize(reader)!;
            }
        }

        public static string Serialize(object? value, string rootName)
        {
            XmlSerializer serializer = new XmlSerializer(value.GetType(), new XmlRootAttribute(rootName));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, value, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
