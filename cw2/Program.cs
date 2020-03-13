using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {

            var path = args[0];
            var resultpath = args[1];
            var resultformat = args[2];
            var lines = File.ReadLines(path);
            var hash = new HashSet<Student>(new MyComp());
            var today = DateTime.Today;
            University uni = new University();
            uni.createdAt = today.ToString("dd.MM.yyyy");
            uni.author = "Zuzanna Bubrowska";


            using (var logput = new StreamWriter("log.txt"))
            {
                try
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
                                hash.Add(student);
                            }

                        }

                    }

                    uni.students = hash;

                    if (resultformat == "xml")
                    {
                        XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
                        xns.Add("", "");
                        using (FileStream writer = new FileStream(resultpath, FileMode.Create))
                        {
                            XmlRootAttribute root = new XmlRootAttribute("university");
                            XmlSerializer serializer = new XmlSerializer(typeof(University), root);
                            serializer.Serialize(writer, uni, xns);
                        }

                    }
                    else if (resultformat == "json")
                    {
                        var result = JsonConvert.SerializeObject(uni, Newtonsoft.Json.Formatting.Indented);
                        File.WriteAllText(resultpath, result);

                    }
                    else
                    {
                        logput.WriteLine("Nieobslugiwane rozszerzenie");
                    }
                }

                //var parsedDate = DateTime.Parse("2020-03-09");
                //Console.WriteLine(parsedDate);



                catch (FileNotFoundException)
                {
                    logput.WriteLine("Plik nie istnieje");
                    throw;
                }
                catch (ArgumentException)
                {
                    logput.WriteLine("Podana sciezka jest niepoprawna");
                    throw;
                }

            }

        }
        
    }
}
