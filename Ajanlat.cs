class Ajanlat
{
    public string Tajegyseg { get; set; }
    public int Ejszaka { get; set; }
    public string Honap { get; set; }
    public int Foglalt { get; set; }
    public int Ar { get; set; }

    public override string ToString() =>
        $"\ttajegyseg: {Tajegyseg}\n" +
        $"\tejszakak szama: {Ejszaka}\n" +
        $"\tutazas honapja: {Honap}\n" +
        $"\tfoglalasok szama: {Foglalt}\n" +
        $"\tuta ara: {Ar} HUF";

    public Ajanlat(string sor)
    {
        var tmp = sor.Split([' ', ';'], StringSplitOptions.RemoveEmptyEntries);
        Tajegyseg = tmp[0];
        Ejszaka = int.Parse(tmp[1]);
        Honap = tmp[2];
        Foglalt = int.Parse(tmp[3]);
        Ar = int.Parse(tmp[4]);
    }
}
