using Kolcsonzo;

List<Kolcsonzes> kolcsonzes = new List<Kolcsonzes>();
using StreamReader sr = new("../../../src/kolcsonzes.txt", System.Text.Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream)
{
    kolcsonzes.Add(new Kolcsonzes(sr.ReadLine()));
}

Console.WriteLine($"ennyi hajót béreltek: ({kolcsonzes.Count()})");

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

var f1 = kolcsonzes.GroupBy(x => x.elvitelOraja).Where(x => x.Count() >= 5).ToDictionary(x => x.Key, x => new
{
    leglabbotszorelvitt = x.Select(x => x.HajoTipus).Count()
})
.ToList();
foreach (var item in f1)
{
    Console.WriteLine($"ebben az órában: {item.Key} ennyi hajót vittek el: {item.Value.leglabbotszorelvitt}");
}

Console.WriteLine("adjon meg egy azonositót: ");
var IdInput = Console.ReadLine();
Console.WriteLine("adjon meg egy hajó Tipusát: ");
var TypeInput = Console.ReadLine();
Console.WriteLine("adja meg a férőhelyek számát: ");
var PlaceInput = Console.ReadLine();

var f3 = kolcsonzes.Where(x => x.Letezikemar(int.Parse(IdInput), TypeInput, int.Parse(PlaceInput))).ToList();
using StreamWriter sw = new("../../../src/harmadikfeladat.txt", true, System.Text.Encoding.UTF8);
if (f3.Any())
{
    foreach (var item in f3)
    {
        string idoString = $"{item.VisszahozatalOraja}{item.VisszahozatalPerce}";
        TimeSpan idoIntervallum = TimeSpan.Parse(idoString);
        sw.WriteLine($"{item.Nev} : {idoIntervallum}");
        
    }
}
else
{
    Console.WriteLine("az adott hajó nem létezik azonban itt vannak azon hajók száma amelyikben ugyanannyi ember fér el mint a megadott érték");
    var megadott = kolcsonzes.Where(x => x.SzemelyekSzama == int.Parse(PlaceInput)).Count();
    Console.WriteLine(megadott);
}

