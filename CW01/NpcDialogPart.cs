using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW01
{
    public class NpcDialogPart
    {
        public string part;
        public List<HeroDialogPart> answers;

        public NpcDialogPart(string part)
        {
            this.part = part;
            this.answers = new List<HeroDialogPart>();
        }
    }
}
