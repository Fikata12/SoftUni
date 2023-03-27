using System.Xml.Serialization;

namespace ProductShop.Utilities
{
    public static class XmlConvert
    {
        public static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));
            using (var reader = new StringReader(inputXml))
            {
                return (T)serializer.Deserialize(reader)!;
            }
        }
    }
}
