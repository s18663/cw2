using System;
using System.Collections.Generic;
using System.IO;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"Z:\cw2\dane\dane.csv";
            var logpath = @"Z:\cw2\dane\log.txt";
            var resultpath = @"Z:\cw2\result\result.xml";
            var lines = File.ReadLines(path);
            ICollection <Student> list = new List<Student>();
            var hash = new HashSet<Student>();
            var today = DateTime.Today;

            using(var output = new StreamWriter(logpath)) { 
            foreach(var line in lines)
            {
                var data = line.Split(",");
                bool log = false;

                foreach(var value in data)
                {
                    if (string.IsNullOrEmpty(value))
                        log = true;
                }

                if (log)
                {
                        output.WriteLine(line);
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

                    }
                
                Console.WriteLine(line);
            }
            }

            var parsedDate = DateTime.Parse("2020-03-09");
            Console.WriteLine(parsedDate);
        }
    }
}
