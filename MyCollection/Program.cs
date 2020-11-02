using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection.Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var col = new MyDictionary<MyKey, string>();

            col.Edit(MyKey.Set(1, "Дмитрий"), "Студент");
          //  col.Edit(MyKey.Set(1), "Студент");
            col.Edit(MyKey.Set(1, "Дмитрий"), "Студент");
            col.Edit(MyKey.Set(1), "Студент");
            col.Edit(MyKey.Set(1, "Дмитрий"), "Студент");


            ShowMap(col);
            Console.ReadLine();
        }

        private static void ShowMap(MyDictionary<MyKey, string> col)
        {
            foreach (KeyValuePair<MyKey, string> item in col)
            {
                Console.WriteLine($"{item.Key.Id} - {item.Key.Name} - {item.Value}");
            }
            Console.WriteLine();
        }
    }
}
