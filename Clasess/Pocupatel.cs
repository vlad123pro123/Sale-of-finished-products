using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clasess
{
    public class Pocupatel
    {
        public int Id { get; set; }
        public string  Telefon { get; set; }
        public string Kontactlico { get; set; }
        public string Adres { get; set; }
     

        public Pocupatel(int id, string telefon, string kontactlico, string adres )
        {
            Id = id;
            Telefon= telefon;   
            Kontactlico= kontactlico;
            Adres= adres;


        }
        public void Show()
        {
            Console.WriteLine($"Номер покупателя {Id}\n" +
                              $"Телефон {Telefon}\n" +
                              $"Контактное лицо {Kontactlico}\n" +
                              $"Адрес {Adres}\n");
                         

        }
        public string ToString()
        {
            return $"{Id},{Telefon},{Kontactlico},{Adres}";
        }
        public static Pocupatel ToClass(string line)
        {
            string[] mas = line.Split(',');
            Pocupatel pocupatel = new Pocupatel(int.Parse(mas[0]), mas[1], mas[2], mas[3]);
            return pocupatel;
        }


    }
}