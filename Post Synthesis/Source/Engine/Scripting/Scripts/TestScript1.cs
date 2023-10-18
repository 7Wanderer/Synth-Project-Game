#region
using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Post_Synthesis.Source;
#endregion

namespace Post_Synthesis
{
    public class TestScript1 : Script
    {
        public TestScript1()
        {
            commandCount = 2;
        }

        public override void Run(int i)
        {
            switch (i)
            {
                case 0: // Will be the first to be called
                    Globals.scriptManager.SetFace("Syn",Portraits.Normal, true);
                    Globals.scriptManager.Talk("Lets see if this works...");
                    break;
                case 1: // Will wait for either the user to click or a timer depending on whether activeTimer == true
                    Globals.scriptManager.SetFace("Syn",Portraits.Normal, false);
                    Globals.scriptManager.Talk("It worked!");
                    break;
                default:
                    ExitScript();
                    break;
            }
        }
    }
}
