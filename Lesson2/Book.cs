using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson2
{
    public class Book :Item
    {
        public string Author { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Book(string name, double weight,string author, double price, string title, string description) : base(name, weight)

        {
            Author = author;
            Price = price;
            Title = title;
            Description = description;
        }
        public override string ToString()
        {
            return $" : {Name},  {Author}, : {Price} , : {Weight}, {Title}";
        }
    }
}
