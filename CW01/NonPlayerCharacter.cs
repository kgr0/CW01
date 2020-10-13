using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW01
{
    public class NonPlayerCharacter
    {
        public string name;
        public NpcDialogPart first_part;

        public NpcDialogPart StartTalking()
        {
            return first_part;
        }
        public NonPlayerCharacter(string name, NpcDialogPart first_part)
        {
            this.name = name;
            this.first_part = first_part;
        }


    }
}
