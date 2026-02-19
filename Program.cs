using System.Text;

const string TxtPath = "..\\..\\..\\data\\utazas.txt";
const string F5Path = "..\\..\\..\\data\\masik_file.txt";
const string F10Path = "..\\..\\..\\data\\utak_rendezve.txt"; 

string[] nyar = ["Június", "Július", "Augusztus"];
string[] tel = ["December", "Január", "Február"];

List<Ajanlat> ajanlatok = [];

using StreamReader sr = new(TxtPath, Encoding.UTF8);
while (!sr.EndOfStream) ajanlatok.Add(new(sr.ReadLine()));

Console.WriteLine($"ajanlatok szama: {ajanlatok.Count}");

var f2 = ajanlatok
    .Where(a => nyar.Contains(a.Honap) && a.Tajegyseg == "Balaton");

Console.WriteLine("nyari balatoni utazasok: ");
foreach (var ajnlt in f2) Console.WriteLine($"\t{ajnlt.Honap,-12} - {ajnlt.Ar,6} HUF");

var f3 = ajanlatok
    .Where(a => a.Tajegyseg == "Tisza-tó")
    .Sum(a => a.Ejszaka);
Console.WriteLine($"osszes ejszaka a tisza-ton: {f3}");

var f4 = ajanlatok
    .Where(a => a.Honap == "Január")
    .Sum(a => a.Ar);
Console.WriteLine($"januari \"bevetel\": {f4} HUF");

var f5 = ajanlatok
    .Where(a => a.Ejszaka >= 3 && a.Foglalt <= 20 && a.Foglalt >= 10);
using StreamWriter swF5 = new(F5Path, false, Encoding.UTF8);
foreach (var item in f5) swF5.WriteLine($"{item.Tajegyseg},{item.Ejszaka}");
Console.WriteLine($"{F5Path} kesz!");

var f6 = ajanlatok
    .Where(a => tel.Contains(a.Honap) 
    && (a.Tajegyseg == "Mátra" || a.Tajegyseg == "Bükk"))
    .Sum(a => a.Foglalt);
Console.WriteLine($"matra+bukk utasok szama telen: {f6} fo");

var f7 = ajanlatok
    .Where(a => a.Tajegyseg == "Bakony")
    .Average(a => a.Ejszaka);
Console.WriteLine($"avg bakonyi ejszakak szama: {f7:0.00}");

var f8 = ajanlatok.Min(a => a.Ar);
Console.WriteLine($"legolcsobb utazas ara: {f8} HUF");

var f9 = ajanlatok.Any(a => a.Foglalt > 30);
Console.WriteLine($"{(f9 ? "VAN" : "NINCS")} olyan ut, amire 30nal tobben jelentkeztek");

var f10 = ajanlatok.OrderBy(a => a.Ar);
using StreamWriter swF10 = new(F10Path, false, Encoding.UTF8);
foreach (var ut in f10) swF10.WriteLine($"{ut.Tajegyseg};{ut.Ejszaka};{ut.Ar}");
Console.WriteLine($"{F10Path} kesz!");

var f11 = ajanlatok.MinBy(a => a.Ar);
Console.WriteLine($"legolcsobb utazas:\n{f11}");

var f12 = ajanlatok.Where(a => a.Ejszaka == ajanlatok.Max(a => a.Ejszaka));
Console.WriteLine($"legtobb eltoltott ejszakaval megegyezo szamu ejszakara foglalt lehetosegek szama: {f12.Count()}");
Console.WriteLine($"az 'elso' ilyen ut celja: {f12.First().Tajegyseg}");


