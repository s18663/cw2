using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];
            var logpath = args[1];
            var resultpath = args[2];
            var lines = File.ReadLines(path);
            var hash = new HashSet<Student>(new MyComp());
            var today = DateTime.Today;
            XmlSerializer xms = new XmlSerializer(typeof(Student));

            using (var logput = new StreamWriter(logpath))
            {
                using (var output = new StreamWriter(resultpath))
                {
                    using (XmlWriter writer = XmlWriter.Create(output))
                    {
                        foreach (var line in lines)
                        {
                            var data = line.Split(",");
                            bool log = false;

                            foreach (var value in data)
                            {
                                if (string.IsNullOrEmpty(value))
                                    log = true;
                            }

                            if (log)
                            {
                                logput.WriteLine(line);
                            }
                            else
                            {
                                Studies studies = new Studies { Name = data[2], Mode = data[3] };
                                Student student = new Student
                                {
                                    FirstName = data[0],
                                    LastName = data[1],
                                    Index = data[4],
                                    BirthDate = DateTime.Parse(data[5]),
                                    Email = data[6],
                                    MotherName = data[7],
                                    FatherName = data[8],
                                    Studies = studies
                                };

                                if (!hash.Add(student))
                                {
                                    logput.WriteLine(line);
                                }
                                else
                                {
                                    xms.Serialize(writer, student);
                                }

                            }

                        }
                    }

                    var parsedDate = DateTime.Parse("2020-03-09");
                    Console.WriteLine(parsedDate);

                }
            }

        }
    }
}
