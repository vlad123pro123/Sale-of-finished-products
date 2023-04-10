using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Clasess
{
    public class Tovar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Optcena { get; set; }
        public int Rozncena { get; set; }
        public string Opisania { get; set; }

        public Tovar(int id,string name, int optcena, int rozncena, string opisania)
        {
            Id = id;
            Name =name;
            Optcena =optcena;   
            Rozncena =rozncena; 
            Opisania =opisania; 


        }
        public void Show()
        {
            Console.WriteLine($"Номер товаров {Id}\n" +
                              $"Нименование {Name}\n" +
                              $"Оптовая цена {Optcena}\n" +
                              $"Розничная цена {Rozncena}\n" +
                              $"Описание {Opisania}\n");
                              
        }
        public string ToString()
        {
            return $"{Id},{Name},{Optcena},{Rozncena},{Opisania}";
        }
        public static Tovar ToClass(string line)
        {
            string[] mas = line.Split(',');
            Tovar tovar = new Tovar(int.Parse(mas[0]), mas[1], int.Parse(mas[2]), int.Parse(mas[3]), (mas[4]));
            return tovar;
        }
    }
}
