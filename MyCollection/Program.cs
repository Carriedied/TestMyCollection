using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var col = new Collection<string, string, string>();

            col.Add("1", "Дмитрий", "Студент");
            col.Add("2", "Александр", "Студент");
            col.Add("3", "Артем", "Студент");
            col.Add("4", "Данил", "Преподаватель");
            ShowMap(col, "Cleared map");
            Console.ReadLine();
        }

        private static void ShowMap(Collection<string, string, string> col, string title)
        {
            Console.WriteLine($"{title}: ");
            foreach (var keyId in col.KeysId)
            {
                // Получаем значение словаря по ключу.
                var value = col.GetById(keyId);
                Console.WriteLine($"{keyId} - {value}");
            }
            Console.WriteLine();
        }
    }
}
