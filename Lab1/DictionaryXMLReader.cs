using System.Text;
using System.Xml.Linq;

namespace Lab1
{
    internal class DictionaryXMLReader : Lab1.@interface.IDictionaryXMLReader
    {
        public List<DictionaryBaseType> ReadFromXml(string filePath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding windows1251 = Encoding.GetEncoding("windows-1251");

            var reader = new StreamReader(filePath, windows1251);

            XDocument rawData = XDocument.Load(reader);
            XElement package = rawData.Element("packet");
            
            List<DictionaryBaseType > result = new List<DictionaryBaseType>();

            foreach (XElement note in package.Elements("zap")) {
                N018Dictionary column = new N018Dictionary();

                column.SetCode(note.Element("ID_REAS"));
                column.SetName(note.Element("REAS_NAME"));
                column.SetBeginDate(note.Element("DATEBEG"));
                column.SetEndDate(note.Element("DATEEND"));

                result.Add(column);
            }

            return result;
        }
    }
}
