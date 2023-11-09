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
            commandCount = 20;
        }

        public override void Run(int i)
        {
            switch (i)
            {
                case 0: // Will be the first to be called
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true); //true = right, false = left
                    Globals.scriptManager.Talk("Okay.");
                    break;
                case 1: // Will wait for either the user to click or a timer depending on whether activeTimer == true
                    Globals.scriptManager.SetFace("Flint",Portraits.Normal, true);
                    Globals.scriptManager.Talk("I will never doubt you again.");
                    break;
                case 2:
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.Talk("How the hell did you just do that?!");
                    break;
                case 3:
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.SetFace("Syn", Portraits.Normal, false);
                    Globals.scriptManager.changeSpeaker(true); //true moves the textbox to the left
                    Globals.scriptManager.Talk("I was acting purely from instinct, but it seems that I\nproduced a shockwave " +
                        "with a high enough current to stop his heart. ");
                    break;
                case 4:
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.SetFace("Syn", Portraits.Normal, false);
                    Globals.scriptManager.Talk("I was acting purely from instinct, but it seems that I\nproduced a shockwave " +
                        "with a high enough current to stop his heart. \nAs for how I obtained such an ability, I do not know.");
                    break;
                case 5:
                    Globals.scriptManager.SetFace("Syn", Portraits.Normal, false);
                    Globals.scriptManager.changeSpeaker(false);
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.Talk("And that 'teleports behind you' move?\nY'know, the one that let you DODGE A BULLET?");
                    break;
                case 6:
                    Globals.scriptManager.SetFace("Syn", Portraits.Normal, false);
                    Globals.scriptManager.changeSpeaker(true);
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.Talk("The same ability, only the electrical energy\ninside of me must've converted itself into kinetic,\n" +
                        "which allowed me to move a short distance very quickly.");
                    break;
                case 7:
                    Globals.scriptManager.SetFace("Syn", Portraits.Normal, false);
                    Globals.scriptManager.changeSpeaker(false);
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.Talk("Alright, no need to get all physicist on me.");
                    break;
                case 8:
                    Globals.scriptManager.SetFace("Syn", Portraits.Normal, false);
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.Talk("Alright, no need to get all physicist on me.\nI get enough of that from her.");
                    break;
                case 9:
                    Globals.scriptManager.SetFace("Syn", Portraits.Normal, false);
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.Talk("But I'm happy to have you on our side.");
                    break;
                case 10:
                    Globals.scriptManager.SetFace("Sasha", Portraits.Normal, false);
                    Globals.scriptManager.changeSpeaker(true);
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.Talk("I don't know, Flint...");
                    break;
                case 11:
                    Globals.scriptManager.SetFace("Sasha", Portraits.Normal, false);
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.Talk("I don't know, Flint...\nIf she's connected to my father,\nthere's no way we can trust her.");
                    break;
                case 12:
                    Globals.scriptManager.SetFace("Sasha", Portraits.Normal, false);
                    Globals.scriptManager.changeSpeaker(false);
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.Talk("Yeah, I know we can't trust her,\nbut what choice do we have?");
                    break;
                case 13:
                    Globals.scriptManager.SetFace("Sasha", Portraits.Normal, false);
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.Talk("...");
                    break;
                case 14:
                    Globals.scriptManager.SetFace("Sasha", Portraits.Normal, false);
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.Talk("If we don't go with her, we're just\ngonna starve to death.");
                    break;
                case 15:
                    Globals.scriptManager.SetFace("Sasha", Portraits.Normal, false);
                    Globals.scriptManager.SetFace("Flint", Portraits.Normal, true);
                    Globals.scriptManager.Talk("If we don't go with her, we're just\ngonna starve to death. Or die.");
                    break;
                case 16:
                    Globals.scriptManager.SetFace("Syn", Portraits.Normal, false);
                    Globals.scriptManager.changeSpeaker(true);
                    Globals.scriptManager.Talk("...");
                    break;
                case 17:
                    Globals.scriptManager.SetFace("Syn", Portraits.Normal, false);
                    Globals.scriptManager.Talk("They don't trust me.");
                    break;
                case 18:
                    Globals.scriptManager.SetFace("Syn", Portraits.Normal, false);
                    Globals.scriptManager.Talk("They don't trust me. Understandable.");
                    break;
                case 19:
                    Globals.scriptManager.SetFace("Syn", Portraits.Normal, false);
                    Globals.scriptManager.Talk("They don't trust me. Understandable.\nBut without that trust...");
                    break;
                default:
                    ExitScript();
                    break;
            }
        }
    }
}
