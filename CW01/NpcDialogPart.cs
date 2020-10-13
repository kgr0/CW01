using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW01
{
    public class NpcDialogPart : IDialogPart
    {
        public string part;
        public List<HeroDialogPart> answers;

        public string Part
        {
            get { return part; }
        }

        public NpcDialogPart(string part)
        {
            this.part = part;
            this.answers = new List<HeroDialogPart>();
        }
    }
}
