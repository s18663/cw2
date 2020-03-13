using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace cw2
{
    [Serializable]
    [XmlType("studies")]
    public class Studies
    {

        [XmlElement(ElementName = "Name")]
        [JsonProperty("name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Mode")]
        [JsonProperty("mode")]
        public string Mode { get; set; }

    }
}