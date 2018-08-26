using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{

    [Serializable]
    public class Book
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public Book() { }
        public Book(string Name, double Price, string Author, int Year)
        {
            this.Name = Name;
            this.Price = Price;
            this.Author = Author;
            this.Year = Year;
        }
    }
}
