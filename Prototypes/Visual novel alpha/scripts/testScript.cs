using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_novel_alpha.scripts
{
    public class testScript : scriptClass
    {
        Actor[] actors;
        Textbox textbox;
        
        public testScript(Actor[] actors, Textbox textbox)
        {
            this.actors = actors;
            this.textbox = textbox;
        }

        public void Run(GameTime gt)
        {
            Message_SetFace(actors[0],Portraits.Normal,false);
            Message_Talk(textbox, "Fuck you");
            Wait(gt);
            Message_SetFace(actors[0], Portraits.Normal, true);
            Message_Talk(textbox, "Test Process complete.");
            Wait(gt);

        }
    }
}
