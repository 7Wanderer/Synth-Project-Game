using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_novel_alpha
{
    public class Script
    {
        public int commandCount;
        public float timeLeft;
        public bool activeTimer = false;

        public virtual void Run(int i)
        {

        }
    }
}
