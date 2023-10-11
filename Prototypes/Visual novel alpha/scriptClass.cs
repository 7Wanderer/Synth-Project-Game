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
    public class scriptClass
    {
        float timer = 0f;
        bool once = false;
        public void Message_SetFace(Actor actor, Portraits portrait, bool Reversed)
        {
            actor.SetFace(portrait, Reversed);
        }
        public void Message_Talk(Textbox textbox, string text)
        {
            textbox.Talk(text);
        }
        public void Wait(GameTime gt)
        {
            timer += (int)gt.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyUp(Keys.Enter)) once = false;
            if (timer < 1)
            {
                while (true)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !once)
                    {
                        once = true;
                        return;
                    }
                }
            }
        }
    }
}
