public class ZNAK : ICloneable, IComparable 
{
    public string Familiya { get; set; }
    public string Name { get; set; }
    public string ZnakZodiaca { get; set; }
    public int Birthday { get; set; }

    public ZNAK(string familiya, string name, string znakzodiaca, int birthday)
    {
        Familiya = familiya;
        Name = name;
        ZnakZodiaca = znakzodiaca;
        Birthday = birthday;
    }

    public override string ToString()
    {
        return $"Фамилия: {Familiya},Имя: {Name},Знак зодиака: {ZnakZodiaca}, Месяц рождения: {Birthday}";
    }

    // ICloneable
    public object Clone()
    {
        return new ZNAK(Familiya, Name, ZnakZodiaca, Birthday);
    }

    // IComparable
    public int CompareTo(object ?obj)
    {
        if (obj == null)
            return 1;

        ZNAK otherZnak = obj as ZNAK;
        if (otherZnak != null)
        {
            return ZnakZodiaca.CompareTo(otherZnak.ZnakZodiaca);
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

        for (int i = 0; i < arraySize; i++)
        {
            Console.WriteLine($"Человек: {i + 1}:");

            Console.Write("Фамилия: ");
            string familiya = Console.ReadLine()!;

            Console.Write("Имя: ");
            string name = Console.ReadLine()!;

            Console.Write("Знак зодиака: ");
            string znakzodiaca = Console.ReadLine()!;

            Console.Write("Месяц рождения (1-12): ");
            string birthday = Console.ReadLine()!;

            int month = int.Parse(Console.ReadLine()!);

            znakArray[i] = new ZNAK(familiya, name, znakzodiaca, month);
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
        Console.Write("\n Сортировка по месяцу: ");
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

