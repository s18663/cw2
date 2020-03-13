using System;
namespace cw2
{
    [Serializable]
    public class Studies
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Mode")]
        public string Mode { get; set; }

    }
}