using System;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1
{
       public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }

        public override string ToString()
        {
            return string.Format($"The name: {Name} from {Address} is available at {PhoneNumber}");
        }
    }
    class Serialize
    {
        static void Main(string[] args)
        {
            xml();
            Console.ReadKey();
        }
        private static void xml()
        {
            Console.WriteLine("Do you want to : R or W");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "r")
                deserializingXml();
            else
                serializingXml();
        }
        private static void deserializingXml()
        {
            try
            {
                XmlSerializer sl = new XmlSerializer(typeof(Student));
                FileStream fs = new FileStream("Data.xml", FileMode.Open, FileAccess.Read);
                Student s = (Student)sl.Deserialize(fs);
                Console.WriteLine(s);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void serializingXml()
        {
            Student s = new Student();
            Console.WriteLine("Enter name");
            s.Name = Console.ReadLine();
            Console.WriteLine("Enter Adress");
            s.Address = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            s.PhoneNumber = long.Parse(Console.ReadLine());
            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sl = new XmlSerializer(typeof(Student));
            sl.Serialize(fs, s);
            fs.Flush();
            fs.Close();
        }
    }
}
