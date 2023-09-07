using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_3
{
    public abstract class Szereplo
    {
        protected int HP;
        protected int vedelem;
        protected int sebzes;

        protected Szereplo(int hP, int vedelem, int sebzes)
        {
            HP = hP;
            this.vedelem = vedelem;
            this.sebzes = sebzes;
        }

        public bool eletbenVan()
        {
            return HP >= 0;
        }
        public void sebzodik(Szereplo tamado)
        {
            int tenylegesSebzes = tamado.sebzes - vedelem;
            if (tenylegesSebzes > 0)
            {
                HP = HP - tenylegesSebzes;
            }
        }

    }
    public abstract class Karakter : Szereplo
    {
        public string nev;
        protected Karakter(string nev, int hP, int vedelem, int sebzes) : base(hP, vedelem, sebzes) { this.nev = nev; }

        public abstract void tamad(List<Karakter> parti, List<Ellenfel> ellenfelek);
    }
    public abstract class Ellenfel : Szereplo
    {
        protected Ellenfel(int hP, int vedelem, int sebzes) : base(hP, vedelem, sebzes) {}

        public abstract void tamad(List<Karakter> parti);
    }

    public class Harcos : Karakter
    {
        public Harcos(string nev, int hP, int vedelem, int sebzes) : base(nev, hP, vedelem, sebzes) {}
        public override void tamad(List<Karakter> parti, List<Ellenfel> ellenfelek)
        {
            int sajatIndex = 0;
            for (int i = 0; i < parti.Count; i++)
            {
                if (parti[i] == this)
                {
                    sajatIndex = i;
                }
            }
            if (sajatIndex != 0)
            {
                return;
            }
            ellenfelek[0].sebzodik(this);
        }
    }
    public class Kosza : Karakter
    {
        public Kosza(string nev, int hP, int vedelem, int sebzes) : base(nev, hP, vedelem, sebzes) { }
        public override void tamad(List<Karakter> parti, List<Ellenfel> ellenfelek)
        {
            ellenfelek[0].sebzodik(this);
        }
    }
    public class Varazslo : Karakter
    {
        public Varazslo(string nev, int hP, int vedelem, int sebzes) : base(nev, hP, vedelem, sebzes) { }
        public override void tamad(List<Karakter> parti, List<Ellenfel> ellenfelek)
        {
            ellenfelek[0].sebzodik(this);
            if(ellenfelek.Count > 1)
            {
                ellenfelek[1].sebzodik(this);
            }
        }
    }

    public class Ork : Ellenfel
    {
        public Ork(int hP, int vedelem, int sebzes) : base(hP, vedelem, sebzes) { }
        public override void tamad(List<Karakter> parti)
        {
            parti[0].sebzodik(this);
        }
    }
}
