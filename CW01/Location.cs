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

        public Location(string name)
        {
            this.name = name;
            npc_list = new List<NonPlayerCharacter>();
        } 

        public void Add_npc(NonPlayerCharacter npc)
        {
            npc_list.Add(npc);
        }
    }
}
