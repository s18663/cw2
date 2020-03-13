using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2
{
    [Serializable]
    [XmlType("student")]
    public class Student
    {
        [XmlElement(ElementName = "FirstName")]
        [JsonProperty("firstname")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "LastName")]
        [JsonProperty("lastname")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "Index")]
        [JsonProperty("index")]
        public string Index { get; set; }
        [XmlElement(ElementName = "Email")]
        [JsonProperty("email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "BirthDate")]
        [JsonProperty("birthdate")]
        public DateTime BirthDate { get; set; }
        [XmlElement(ElementName = "MotherName")]
        [JsonProperty("mothername")]
        public string MotherName { get; set; }
        [XmlElement(ElementName = "FatherName")]
        [JsonProperty("fathername")]
        public string FatherName { get; set; }
        [XmlElement(ElementName = "Studies")]
        [JsonProperty("studies")]
        public Studies Studies { get; set; }
    }
}
