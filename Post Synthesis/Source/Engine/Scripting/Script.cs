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

        public void ExitScript()
        {
            Globals.scriptManager = null;
        }
        public virtual void Run(int i)
        {

        }
    }
}
