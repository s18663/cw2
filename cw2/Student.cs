using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2
{
    [Serializable]
    public class Student
    {
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "Index")]
        public string Index { get; set; }
        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "BirthDate")]
        public DateTime BirthDate { get; set; }
        [XmlElement(ElementName = "MotherName")]
        public string MotherName { get; set; }
        [XmlElement(ElementName = "FatherName")]
        public string FatherName { get; set; }
        [XmlElement(ElementName = "Studies")]
        public Studies Studies { get; set; }
    }
}
