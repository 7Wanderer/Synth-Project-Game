using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_novel_alpha.Scripts
{
    public class script1 : Script
    {

        public script1()
        { 
            commandCount = 2; 
        }

        public override void Run(int i)
        {
            switch(i)
            {
                case 0: // Will be the first to be called
                    Game1.player1.SetFace(Portraits.Normal, true);
                    Game1.textbox.Talk("Lets see if this works...");
                    break;
                case 1: // Will wait for either the user to click or a timer depending on whether activeTimer == true
                    Game1.player1.SetFace(Portraits.Normal, false);
                    Game1.textbox.Talk("It worked!");
                    break;
                default:
                    // Something to let me know that there's been an error
                    break;
            }
        }
    }
}
