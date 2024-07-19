using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sitemapfy.Net
{

    public record struct Priority
    {
        public static readonly Priority Default = new Priority(0.5);
        public static readonly Priority High = new Priority(1);
        public static readonly Priority Low = new Priority(0);

        public Priority(double value)
        {
            Value = (value < 0.0 || value > 1.0) ? Default.Value : value;
        }

        [XmlText]
        public double Value { get; init; }
    }
}
