using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_Synthesis.Source
{
    public class Script
    {
        public int commandCount;
        public float timeLeft;
        public bool activeTimer = false;

        //When making a constructor for a script, load in any units to move.

        public void ExitScript()
        {
            Globals.scriptManager.inactive = true;
            Globals.scriptManager.resetCamera();
        }
        public virtual void Run(int i)
        {

        }
    }

}
