using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Lab1
{
    internal class N018Dictionary : DictionaryBaseType
    {
        public N018Dictionary() { }
        
        public void SetCode(XElement codeAttribute)
        {
            this.Code = Int32.Parse(codeAttribute.Value);
        }

        public void SetName(XElement nameAttribute)
        {
            this.Name = nameAttribute.Value;
        }

        public void SetBeginDate(XElement beginDateAttribute)
        {
            Regex regex = new Regex(@"\d\d\.\d\d\.\d*");
            if (beginDateAttribute.Value is not null & regex.IsMatch(beginDateAttribute.Value))
            {
                this.BeginDate = DateTime.Parse(beginDateAttribute.Value);
            }
        }

        public void SetEndDate(XElement endDateAttribute)
        {
            Regex regex = new Regex(@"\d\d\.\d\d\.\d*");
            if (endDateAttribute.Value is not null & regex.IsMatch(endDateAttribute.Value))
            {
                this.EndDate = DateTime.Parse(endDateAttribute.Value);
            }
        }
    }
}
