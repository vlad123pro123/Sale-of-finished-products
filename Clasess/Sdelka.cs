using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasess
{
    public class Sdelka
    {
        public int Id { get; set; }
        public DateTime  Datasdelci { get; set; }
        public int Tovarid { get; set; }
        public int Kolihestvo { get; set; }
        public int Pocupatelid { get; set; }
        public string Priznak { get; set; }



        public Sdelka(int id, DateTime datasdelci, int tovarid, int kolihestvo, int pocupatelid,string priznak)
        {
            Id = id;
            Datasdelci= datasdelci; 
            Tovarid = tovarid;
            Kolihestvo= kolihestvo; 
            Pocupatelid=pocupatelid;
            Priznak = priznak;
            

        }
        public void Show()
        {
            Console.WriteLine($"Номер сделки {Id}\n" +
                              $"Дата сделки {Datasdelci}\n" +
                              $"id Товар {Tovarid}\n" +
                              $"Количество {Kolihestvo}\n" +
                              $"id Покупатель {Pocupatelid}\n" +
                              $"Признак оптовой продажи {Priznak}\n");


        }
        public string ToString()
        {
            return $"{Id},{Datasdelci},{Tovarid},{Kolihestvo},{Pocupatelid},{Priznak}";
        }
        public static Sdelka ToClass(string line)
        {
            string[] mas = line.Split(',');
            Sdelka sdelki = new Sdelka(int.Parse(mas[0]), DateTime.Parse( mas[1]), int.Parse(mas[2]), int.Parse(mas[3]), int.Parse(mas[4]), mas[5]);
            return sdelki;
        }


    }
}
