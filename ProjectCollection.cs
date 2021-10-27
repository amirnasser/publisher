using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Publisher
{
    [XmlRoot("Projects")]
    public class ProjectCollection: List<Projects>
    {

    }
}
