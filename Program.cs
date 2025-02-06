
public class ZNAK : ICloneable, IComparable <ZNAK>
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
        return $"{Familiya} {Name} ({ZnakZodiaca}), Month: {Birthday}";
    }

    // ICloneable
    public object Clone()
    {
        return new ZNAK(Familiya, Name, ZnakZodiaca, Birthday);
    }

    // IComparable
    public int CompareTo(ZNAK ?other)
    {
        if (other == null)
            return 1;

        return ZnakZodiaca.CompareTo(other.ZnakZodiaca);
    }
}

