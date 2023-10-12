#region
using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
#endregion

namespace Synth_Project
{
    public class BaseKeyboard
    {

        public KeyboardState newKeyboard, oldKeyboard;

        public List<BaseKey> pressedKeys = new(), previousPressedKeys = new();

        public BaseKeyboard()
        {

        }

        public virtual void Update()
        {
            newKeyboard = Keyboard.GetState();

            GetPressedKeys();

        }

        public void UpdateOld()
        {
            oldKeyboard = newKeyboard;

            previousPressedKeys = new List<BaseKey>();
            for(int i=0;i<pressedKeys.Count;i++)
            {
                previousPressedKeys.Add(pressedKeys[i]);
            }
        }


        public bool GetPress(string KEY)
        {

            for(int i=0;i<pressedKeys.Count;i++)
            {

                if(pressedKeys[i].key == KEY)
                {
                    return true;
                }

            }
            

            return false;
        }


        public virtual void GetPressedKeys()
        {
            // bool found = false;

            pressedKeys.Clear();
            for(int i=0; i<newKeyboard.GetPressedKeys().Length; i++)
            {

                    pressedKeys.Add(new BaseKey(newKeyboard.GetPressedKeys()[i].ToString(), 1));
  
            }
        }

    }
}
