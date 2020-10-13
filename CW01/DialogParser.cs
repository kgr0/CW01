using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW01
{
    public class DialogParser
    {

        public Hero hero;

        public DialogParser(Hero hero)
        {
            this.hero = hero;
            HeroesGame.HERONAME = hero.name;
        }

        public string ParseDialog(IDialogPart dialog_part)
        {
            return dialog_part.Part;
        }

    }
}
