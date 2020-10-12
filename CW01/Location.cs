using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW01
{
    public class Location
    {
        public string name;
        public List<NonPlayerCharacter> npc_list;

        public Location(string name, List<NonPlayerCharacter> npc_list)
        {
            this.name = name;
            this.npc_list = npc_list;
        } 

    }
}
