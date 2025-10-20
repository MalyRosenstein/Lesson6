using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lesson2
{
    public  class Game:Item
    {
            public string Description { get; set; }
        public int Code { get; set; }
        public int Level { get; set; }

        public Game(string name, double weight,string description, int code, int level) : base(name, weight)

        {
            Description = description;
            Code = code;
            Level = level;
        }
        public override string ToString()
        {
            return $" {Name},   {Code} ת {Code} , {Weight}";
        }
    }
    }

