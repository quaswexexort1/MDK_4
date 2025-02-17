public class ZNAK : ICloneable, IComparable
{
    public string Familiya { get; set; }
    public string Name { get; set; }
    public string ZnakZodiaca { get; set; }
    public int Birthday { get; set; }
    public int IdNumber { get; set; }

    // Конструктор класса
    public ZNAK(string familiya, string name, string znakzodiaca, int birthday, int idnumber)
    {
        Familiya = familiya;
        Name = name;
        ZnakZodiaca = znakzodiaca;
        Birthday = birthday;
        IdNumber = idnumber;
    }

    public override string ToString()
    {
        return $"Фамилия: {Familiya},Имя: {Name},Знак зодиака: {ZnakZodiaca}, Месяц рождения: {Birthday}";
    }

    // ICloneable
    public object Clone()
    {
        return new ZNAK(Familiya, Name, ZnakZodiaca, Birthday, IdNumber);
    }

    // IComparable
    public int CompareTo(object? obj)
    {
        if (obj == null)
            return 1;

        ZNAK otherZnak = obj as ZNAK;
        if (otherZnak != null)
        {
            return ZnakZodiaca.CompareTo(otherZnak.ZnakZodiaca); // Сравниваем знаки зодиака
        }

        else
        {
            throw new ArgumentException("не ZNAK");
        }

    }
}

class Program
{
    static void Main(String[] args)
    {
        int arraySize = 3;
        ZNAK[] znakArray = new ZNAK[arraySize];

        for (int i = 0; i < arraySize; i++)  // Цикл для ввода данных о каждом человеке
        {
            Console.WriteLine($"Человек: {i + 1}:");

            Console.Write("Фамилия: ");
            string familiya = Console.ReadLine()!;

            Console.Write("Имя: ");
            string name = Console.ReadLine()!;

            Console.Write("Знак зодиака: ");
            string znakzodiaca = Console.ReadLine()!;

            Console.Write("Месяц рождения (1-12): ");
            int month = int.Parse(Console.ReadLine()!);

            Console.Write("Идентификационный номер: ");
            int idnumber = int.Parse(Console.ReadLine()!);

            znakArray[i] = new ZNAK(familiya, name, znakzodiaca, month, idnumber);
        }


        // Сортировка по знаку зодиака
        Array.Sort(znakArray);

        // Вывод
        Console.WriteLine("\n Сортировка по знаку зодиака: ");
        foreach (var znak in znakArray)
        {
            Console.WriteLine(znak);
        }




        // Поиск по месяцу
        Console.Write("\n Введите месяц для сортировки по его числу:");
        int searchMonth = int.Parse(Console.ReadLine()!);

        // Вывод
        Console.WriteLine($"\n Люди, рожденные в месяце: {searchMonth}");
        bool found = false;
        foreach (var znak in znakArray)
        {
            if (znak.Birthday == searchMonth) // Если месяц рождения совпадает 
            {
                Console.WriteLine(znak);
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Никто не найден в этом месяце.");
        }
    }

}
