using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Visual_novel_alpha
{    

    public class ScriptManager
    {
        Script script;
        float timer;
        bool once = false;
        int tempi = 0;


        public ScriptManager(Script script) 
        { 
            this.script = script;
        }
        
        public void Update(GameTime gt)
        {
            for (int i = tempi; i<script.commandCount;)
            {
                timer += (float)gt.ElapsedGameTime.TotalSeconds;

                script.Run(i);

                if (script.activeTimer)
                {
                    if (timer <= script.timeLeft)
                    {
                        tempi = i;
                        break;
                    }
                    else
                    {
                        tempi = i + 1;
                        break;
                    }
                }
                else
                {
                    if (!Keyboard.GetState().IsKeyDown(Keys.Space) || once)
                    {
                        tempi = i;
                        break;
                    }
                    else 
                    {
                        once = true;
                        tempi = i + 1;
                        break;
                    }
                }
            }
            if(Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                once = false;
            }
        }
    }
}
