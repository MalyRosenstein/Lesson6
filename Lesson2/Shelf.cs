using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class Shelf<T> where T : Item
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public double MaxWeight { get; set; }
        public List<T> Items { get; set; } = new List<T>();

        public Shelf(int row, int column, double maxWeight)
        {
            Row = row;
            Column = column;
            MaxWeight = maxWeight;
        }


        public override string ToString()
        {
            return $"{Row},  {Column},  {Items.Count}";
        }
        public List<T> Search(Func<T, bool> condition)
        {
            return Items.Where(condition).ToList();
        }

    }
}
