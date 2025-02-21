using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kolcsonzo
{
    internal class Kolcsonzes
    {
        public Kolcsonzes(string r)
        {
            var v = r.Split(';');
            Nev = v[0];

            if (Nev.Contains(','))
            {
                var nevekCsoport = Nev.Split(',');
                var temping = nevekCsoport[0].Trim();
                nevekCsoport[0] = nevekCsoport[1].Trim();
                nevekCsoport[1] = temping; 
      
                Nev = $"{nevekCsoport[0]}, {nevekCsoport[1]}";
            }
          

            Id = int.Parse(v[1]);
            HajoTipus = v[2];
            SzemelyekSzama = int.Parse(v[3]);
            this.elvitelOraja = int.Parse(v[4]);
            this.elvitelPerce = int.Parse(v[5]);
            VisszahozatalOraja = int.Parse(v[6]);
            VisszahozatalPerce = int.Parse(v[7]);



        }

        public bool Letezikemar(int azonosito, string hajotipusa, int szemelyekszam)
        {
            if (azonosito == Id|| hajotipusa == HajoTipus || szemelyekszam == SzemelyekSzama)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string Nev { get; set; }
        public int Id { get; set; }
        public string HajoTipus { get; set; }
        public int SzemelyekSzama { get; set; }
        public int elvitelOraja { get; set; }
        public int elvitelPerce { get; set; }
        public int VisszahozatalOraja { get; set; }
        public int VisszahozatalPerce { get; set; }

        public override string ToString()
        {
            return $"";
        }

    }
    
}
