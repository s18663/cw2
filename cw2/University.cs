using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace cw2
{
	[Serializable]
	[XmlType("university")]
	public class University
	{

		[XmlElement(ElementName = "createdAt")]
		[JsonProperty("createdAt")]
		public string createdAt { get; set; }
		[XmlElement(ElementName = "author")]
		[JsonProperty("author")]
		public string author { get; set; }
		[XmlElement(ElementName = "students")]
		[JsonProperty("students")]
		public HashSet<Student> students;

	}
}
