using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Synth_Project.Source.Engine.Input
{
    public class InputManager
    {
        public BaseKeyboard keyboard = new();
        public InputManager() { }

        public bool Left()
        {
            if (keyboard.GetPress("A")
                


                ) return true;
            return false;
        }
        public bool Right() 
        {
            if (keyboard.GetPress("D")



                ) return true;
            return false;
        }
        public bool Up() 
        {
            if (keyboard.GetPress("W")



                ) return true;
            return false;
        }
        public bool Down()
        {
            if (keyboard.GetPress("S")



                ) return true;
            return false;
        }
        public bool Blink()
        {
            if (keyboard.GetPress("Q")



                ) return true;
            return false;
        }
        public bool Attack()
        {
            if (keyboard.GetPress("E")



                ) return true;
            return false;
        }
    }
}
