using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW01
{
    public class HeroDialogPart
    {
        public string part;
        public List<NpcDialogPart> answers;

        public HeroDialogPart(string part)
        {
            this.part = part;
            this.answers = new List<NpcDialogPart>();
        }
    }
}
