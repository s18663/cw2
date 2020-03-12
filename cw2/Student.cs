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
        public string LastName { get; set; }
        public string Index { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public Studies Studies { get; set; }
    }
}
