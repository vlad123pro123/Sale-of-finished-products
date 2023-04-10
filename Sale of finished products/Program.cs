using Clasess;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

Menu();
static void Menu()
{   
    Console.Clear();
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;   
    Console.Title = "Строк Владислав";
    Console.Clear();
    Console.WriteLine("-------------------------------------------------------------------------\n" +
                      "|  Товары(1)  |  Покупатели(2)  |  Сделки(3)  |  Выход из программы(4)  |\n" +
                      "-------------------------------------------------------------------------");
    Console.Write("Введите код операции: ");
    char Code = Console.ReadKey(true).KeyChar;
    switch (Code)
    {
        case '1':
            TovarMenu();
            break;
        case '2':
            PocupatelMenu();
            break;
        case '3':
            SdelkaMenu();
            break;
        case '4':
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Не верный символ ");
            Thread.Sleep(1000);
            Menu();
            break;

    }
}

static void TovarMenu()
{
    ICollection<Tovar> _Tovari = new List<Tovar>();
    int Tovar_id = -1;

    using (StreamReader reader = new StreamReader("Tovari.txt"))
    {
        while (!reader.EndOfStream)
        {
            _Tovari.Add(Tovar.ToClass(reader.ReadLine()));
        }
    }
    if (_Tovari.Count > 0) { Tovar_id = _Tovari.Last().Id; }
    Console.Clear();
    Console.WriteLine("-----------------------------------------------------------------------------------------------\n" +
                      "|  Показать товары(1)  |  Добавить товар(2)  |  Удалить товар(3)  |  Выход в главное меню(4)  |\n" +
                      "-----------------------------------------------------------------------------------------------");
    Console.Write("Введите код операции: ");
    char Code = Console.ReadKey(true).KeyChar;
    switch (Code)
    {
        case '1':
            ShowTovari(_Tovari);
            break;
        case '2':
            AddTovar(_Tovari, Tovar_id);
            break;
        case '3':
            DeleteTovar(_Tovari);
            break;
        case '4':
            Menu();
            break;
        default:
            Console.WriteLine("Не верный символ ");
            Thread.Sleep(1000);
            TovarMenu();
            break;

    }
}
static void ShowTovari(ICollection<Tovar> _Tovari)
{
    Console.Clear();
    if (_Tovari.Count == 0)
    {
        Console.WriteLine("Товаров нет");
    }
    else
    {
        foreach (Tovar Tovari in _Tovari)
        {
            Tovari.Show();
        }
    }
    Console.ReadKey();
    TovarMenu();
}

static void AddTovar(ICollection<Tovar> _Tovari, int Tovari_id)
{
    Console.Clear();
    try
    {
        Console.WriteLine("Введите наименование");
        string Name = Console.ReadLine();
        Console.WriteLine("Введите оптовую цену");
        int Optcena = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите розничную цену");
        int Rozcena = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите описание");
        string Opisanie = Console.ReadLine();
        Tovari_id++;
        Tovar Tovari = new Tovar(Tovari_id, Name, Optcena, Rozcena, Opisanie);
        _Tovari.Add(Tovari);
        using (StreamWriter writer = new StreamWriter("Tovari.txt", false))
        {
            foreach (Tovar _Tovar in _Tovari)
            {
                writer.WriteLine(_Tovar.ToString());
            }
        }
    }
    catch {
        Console.WriteLine("Вы ввели неверные данные, повторите ввод. Нажмите любую кнопку для продолжения");
        Console.ReadKey();
        TovarMenu();
    }
    TovarMenu();
}

static void DeleteTovar(ICollection<Tovar> _Tovari)
{
    Console.Clear();
    Console.WriteLine("Введите код товара");
    int id = int.Parse(Console.ReadLine());
    if (id >= 0 && id<= _Tovari.Count)
    {
        var temp = _Tovari.Where(d => d.Id == id).First();
        _Tovari.Remove(temp);
        using (StreamWriter writer = new StreamWriter("Tovari.txt", false))
        {
            foreach (Tovar _Tovar in _Tovari)
            {
                writer.WriteLine(_Tovar.ToString());
            }
        }
    }
    else
    {
        Console.WriteLine("Товара с таким кодом не существует");
        Console.ReadKey();
    }
    TovarMenu();
}

static void PocupatelMenu()
{
    ICollection<Pocupatel> _Pocupateli = new List<Pocupatel>();
    int Pocupateli_id = -1;

    using (StreamReader reader = new StreamReader("Pocupateli.txt"))
    {
        while (!reader.EndOfStream)
        {
            _Pocupateli.Add(Pocupatel.ToClass(reader.ReadLine()));
        }
    }
    if (_Pocupateli.Count > 0)
    {
        Pocupateli_id = _Pocupateli.Last().Id;
    }
    Console.Clear();
    Console.WriteLine("--------------------------------------------------------------------------------------------------------------\n" +
                      "|  Показать покупателей(1)  |  Добавить покупателя(2)  |  Удалить покупателя(3)  |  Выход в главное меню(4)  |\n" +
                      "--------------------------------------------------------------------------------------------------------------");
    Console.Write("Введите код операции: ");
    char Code = Console.ReadKey(true).KeyChar;
    switch (Code)
    {
        case '1':
            ShowPocupateli(_Pocupateli);
            break;
        case '2':
            AddPocupatel(_Pocupateli, Pocupateli_id);
            break;
        case '3':
            DeletePocupatel(_Pocupateli);
            break;
        case '4':
            Menu();
            break;
        default:
            Console.WriteLine("Не верный символ ");
            Thread.Sleep(1000);
            PocupatelMenu();
            break;

    }
}

static void ShowPocupateli(ICollection<Pocupatel> Pocupateli)
{
    Console.Clear();
    if (Pocupateli.Count == 0)
    {
        Console.WriteLine("Покупателей нет");
    }
    else
    {
        foreach (Pocupatel Pocupatel in Pocupateli)
        {
            Pocupatel.Show();
        }
    }
    Console.ReadKey();
    PocupatelMenu();
}

static void AddPocupatel(ICollection<Pocupatel> Pocupateli, int Pocupatel_id)
{
    try
    {
        Console.Clear();
        Console.WriteLine("Введите телефон");
        string Telefon = Console.ReadLine();
        Console.WriteLine("Введите контактное лицо");
        string Kontactlico = Console.ReadLine();
        Console.WriteLine("Введите адрес");
        string Adres = Console.ReadLine();
        Pocupatel_id++;
        Pocupatel Pocupatel = new Pocupatel(Pocupatel_id, Telefon, Kontactlico, Adres); ;
        Pocupateli.Add(Pocupatel);
        using (StreamWriter writer = new StreamWriter("Pocupateli.txt", false))
        {
            foreach (Pocupatel _Pocupatel in Pocupateli)
            {
                writer.WriteLine(_Pocupatel.ToString());
            }
        }
    }
    catch
    {
        Console.WriteLine("Вы ввели неверные данные, повторите ввод. Нажмите любую кнопку для продолжения");
        Console.ReadKey();
        PocupatelMenu();
    }
    PocupatelMenu();
}

static void DeletePocupatel(ICollection<Pocupatel> Pocupateli)
{
    Console.Clear();
    Console.WriteLine("Введите код покупателя");
    int id = int.Parse(Console.ReadLine());
    if (id >= 0 && id <= Pocupateli.Count)
    {
        var temp = Pocupateli.Where(d => d.Id == id).First();
        Pocupateli.Remove(temp);
        using (StreamWriter writer = new StreamWriter("Pocupateli.txt", false))
        {
            foreach (Pocupatel _Pocupatel in Pocupateli)
            {
                writer.WriteLine(_Pocupatel.ToString());
            }
        }
    }
    else
    {
        Console.WriteLine("Покупателя с таким кодом не существует");
        Console.ReadKey();
    }
    PocupatelMenu();
}
static void SdelkaMenu()
{
    ICollection<Sdelka> _Sdelki = new List<Sdelka>();
    int Sdelka_id = -1;

    using (StreamReader reader = new StreamReader("Sdelki.txt"))
    {
        while (!reader.EndOfStream)
        {
            _Sdelki.Add(Sdelka.ToClass(reader.ReadLine()));
        }
    }
    if (_Sdelki.Count > 0) { Sdelka_id = _Sdelki.Last().Id; }
    Console.Clear();
    Console.WriteLine("-------------------------------------------------------------------------------------------------\n" +
                      "|  Показать сделки(1)  |  Добавить сделку(2)  |  Удалить сделку(3)  |  Выход в главное меню(4)  |\n" +
                      "-------------------------------------------------------------------------------------------------");
    Console.Write("Введите код операции: ");
    char Code = Console.ReadKey(true).KeyChar;
    switch (Code)
    {
        case '1':
            SdelkiShow(_Sdelki);
            break;
        case '2':
            SdelkaAdd(_Sdelki, Sdelka_id);
            break;
        case '3':
            SdelkaDelete(_Sdelki);
            break;
        case '4':
            Menu();
            break;
        default:
            Console.WriteLine("Не верный символ ");
            Thread.Sleep(1000);
            SdelkaMenu();
            break;

    }
}

static void SdelkiShow(ICollection<Sdelka> Sdelki)
{
    Console.Clear();
    if (Sdelki.Count == 0)
    {
        Console.WriteLine("Сделок нет");
    }
    else
    {
        foreach (Sdelka Sdelka in Sdelki)
        {
            Sdelka.Show();
        }
    }
    Console.ReadKey();
    SdelkaMenu();
}
static void SdelkaAdd(ICollection<Sdelka> Sdelki, int Sdelka_id)
{
    ICollection<Tovar> _Tovari = new List<Tovar>();

    using (StreamReader reader = new StreamReader("Tovari.txt"))
    {
        while (!reader.EndOfStream)
        {
            _Tovari.Add(Tovar.ToClass(reader.ReadLine()));
        }
    }

    ICollection<Pocupatel> _Pocupateli = new List<Pocupatel>();

    using (StreamReader reader = new StreamReader("Pocupateli.txt"))
    {
        while (!reader.EndOfStream)
        {
            _Pocupateli.Add(Pocupatel.ToClass(reader.ReadLine()));
        }
    }

    Console.Clear();
    if (_Pocupateli.Count == 0)
    {
        Console.WriteLine("Покупателей нет");
        Console.ReadKey();
        SdelkaMenu();
    }
    else
    {
        foreach (Pocupatel Pocupatel in _Pocupateli)
        {
            Pocupatel.Show();

        }
        Console.WriteLine("Введите номер покупателя");
        int p_code = int.Parse(Console.ReadLine());
        int p_temp = _Pocupateli.Where(d => d.Id == p_code).First().Id;
        if (p_temp != null)
        {
            Console.Clear();
            if (_Tovari.Count == 0)
            {
                Console.WriteLine("Товаров нет");
                Console.ReadKey();
                SdelkaMenu();
            }
            else
            {
                foreach (Tovar Tovar in _Tovari)
                {
                    Tovar.Show();
                }
                try {
                    Console.WriteLine("Введите номер нужного товара");
                    int t_code = int.Parse(Console.ReadLine());
                    int t_temp = _Tovari.Where(d => d.Id == t_code).First().Id;
                    if (t_temp != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите дату сделки");
                        DateTime Datasdelki = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Введите количество товаров");
                        int Kolihestvo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите признак оптовой продажи");
                        string Priznak = Console.ReadLine();
                        Sdelka_id++;
                        Sdelka Sdelka = new Sdelka(Sdelka_id, Datasdelki, t_temp, Kolihestvo, p_temp, Priznak);
                        Sdelki.Add(Sdelka);
                        using (StreamWriter writer = new StreamWriter("Sdelki.txt", false))
                        {
                            foreach (Sdelka _Sdelka in Sdelki)
                            {
                                writer.WriteLine(_Sdelka.ToString());
                            }
                        }
                    }
                }
                catch {
                    Console.WriteLine("Вы ввели неверные данные, повторите ввод. Нажмите любую кнопку для продолжения");
                    Console.ReadKey();
                    SdelkaMenu();
                }
                }
        }
    }
    SdelkaMenu();
}
static void SdelkaDelete(ICollection<Sdelka> Sdelki)
{
    Console.Clear();
    Console.WriteLine("Введите код сделки");
    int id = int.Parse(Console.ReadLine());
    if (id >= 0 && id <= Sdelki.Count)
    {
        var temp = Sdelki.Where(d => d.Id == id).First();
        Sdelki.Remove(temp);
        using (StreamWriter writer = new StreamWriter("Sdelki.txt", false))
        {
            foreach (Sdelka Sdelka in Sdelki)
            {
                writer.WriteLine(Sdelka.ToString());
            }
        }
    }
    else
    {
        Console.WriteLine("Сделки с таким кодом не существует");
        Console.ReadKey();
    }
    SdelkaMenu();
}