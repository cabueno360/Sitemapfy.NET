using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sitemapfy.Net
{
    public record struct ChangeFrequency
    {
        public static readonly ChangeFrequency Monthly = new ChangeFrequency("monthly");
        public static readonly ChangeFrequency Weekly = new ChangeFrequency("weekly");

        public ChangeFrequency(string value)
        {
            Value = string.IsNullOrWhiteSpace(value) ? Monthly.Value : value;
        }

        [XmlText]
        public string Value { get; init; }
    }

}
