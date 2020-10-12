using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW01
{
    public class Hero
    {
        public string name;
        public EHeroClass hero_class;

        public Hero(string name, EHeroClass hero_class)
        {
            this.name = name;
            this.hero_class = hero_class;
        }
    }
}
