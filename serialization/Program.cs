using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp3
{
    class Program
    {
        public static object Xml { get; private set; }

        static void Main(string[] args)
        {
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book("Властелин колец", 7500, "Джон Рональд Руэл Толкин", 1954));
            bookList.Add(new Book("Игра Эндера", 2690, "Орсон Скотт Кард", 1813));
            bookList.Add(new Book("Мертвые души", 3590, "Николай Васильевич Гоголь", 1967));
            bookList.Add(new Book("Война и мир", 4290, "Лев Николаевич Толстой", 1877));


            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                using (System.IO.FileStream fs = new FileStream(@"C:\Users\Zhanibek\Desktop\SerializationList.txt", FileMode.OpenOrCreate))
                {
                    bf.Serialize(fs, bookList);
                    Console.WriteLine("Объект успешно сериализован");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Thread.Sleep(1000);
            Console.WriteLine();

            BinaryFormatter formatter = new BinaryFormatter();
            XmlSerializer x = new XmlSerializer(bookList.GetType());
            using (FileStream fs = new FileStream(@"C:\Users\Zhanibek\Desktop\SerializationList.txt", FileMode.OpenOrCreate))
            {
                var result = (List<Book>)formatter.Deserialize(fs);
                Console.WriteLine("Объект успешно десериализован");
                foreach (Book item in result)
                {
                    Console.WriteLine(item.Name + "\t" + item.Price + "\t" + item.Author + "\t" + item.Year);
                }
                using (FileStream fs2 = new FileStream(@"C:\Users\Zhanibek\Desktop\SerializationList.xml", FileMode.OpenOrCreate))
                {
                   x.Serialize(fs2,bookList);
                }
            }

            Random rnd = new Random();
            XmlDocument doc = new XmlDocument();
            
            doc.Load(@"C:\Users\Zhanibek\Desktop\SerializationList.xml");
            XmlAttribute xmlAttribute = doc.CreateAttribute("FontSize");
            foreach (XmlElement item in doc.SelectNodes("Book"))
            {
                xmlAttribute.InnerText = rnd.Next(8, 11).ToString();
                item.Attributes.Append(xmlAttribute);
            }
           doc.Save(@"C:\Users\Zhanibek\Desktop\SerializationList2.0.xml");
        }
    }
}
