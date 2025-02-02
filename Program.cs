using Kolcsonzo;

List <Kolcsonzes> kolcsonzes = new List <Kolcsonzes> ();
using StreamReader sr = new("../../../src/kolcsonzes.txt", System.Text.Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream)
{
    kolcsonzes.Add(new Kolcsonzes(sr.ReadLine()));
}
foreach (var item in kolcsonzes)
{
    Console.WriteLine(item.Nev);
}

Console.WriteLine("Adjon meg nevet:");
var k = Console.ReadLine();


var kolcsonzo = kolcsonzes.Where(x => x.Nev.Equals(k)).ToList();

if (kolcsonzo.Any())  
{
    foreach (var item in kolcsonzo)
    {
  
        Console.WriteLine($"{item.Nev} hajót bérelt {item.elvitelOraja}:{item.elvitelPerce} - {item.VisszahozatalOraja}:{item.VisszahozatalPerce} időtartamban.");
    }
}
else
{
    Console.WriteLine("Nem volt ilyen nevű kölcsönző!");
}

int magyar = 0;
int kuldoldi = 0;
foreach (var item in kolcsonzes)
{
    if (item.Nev.Contains(','))
    {
        kuldoldi++;
    }
    else
    {
        magyar++;
    }
}
Console.WriteLine($"ennyi magyar van: {magyar}");
Console.WriteLine($"ennyi külföldi van: {kuldoldi}");