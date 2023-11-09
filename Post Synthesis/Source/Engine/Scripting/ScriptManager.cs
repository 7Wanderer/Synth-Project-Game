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
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
#endregion

namespace Post_Synthesis
{
    public class ScriptManager
    {
        List<Actor> actors = new();
        Script script;
        float timer, textTimer;
        int characterIndex = 0;
        int tempi = 0;


        Vector2 position = new(Globals.screenWidth / 2, Globals.screenHeight * 0.75f);

        Texture2D blackBackground;
        float fadein = 0;

        Texture2D Textbox;
        string text = "";


        public ScriptManager(Script script, List<Actor> actors)
        {
            timer = 0;
            textTimer = 0;
            this.script = script;
            this.actors = actors;
            blackBackground = Globals.content.Load<Texture2D>("Assets\\Misc\\blackBackground");
        }
        public void SetFace(string actorName,Portraits portrait, bool isReversed)
        {
			if(actorName != null)
			{
				foreach(Actor actor in actors) 
				{
					else if(actor.name ==  actorName)
					{
						actor.SetFace(portrait, isReversed);
					}
				}
			}
        }
        public void Talk(string text)
        {
            this.text = text;
        }

        public void changeSpeaker(bool left)
        {
            if (left)
                position.X = Globals.screenWidth / 4;
            else position.X = Globals.screenWidth / 2;
        }

        public void Update()
        {
            if(fadein != 0.5)
            {
                fadein += 0.01f;
            }

            for (int i = tempi; i <= script.commandCount;)
            {
                timer += (float)Globals.gameTime.ElapsedGameTime.TotalSeconds;
                textTimer += (float)Globals.gameTime.ElapsedGameTime.TotalMilliseconds;

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
                        textTimer = 0;
                        tempi = i + 1;
                        break;
                    }
                }
                else
                {
                    if (!Globals.inputManager.Continue())
                    {
                        tempi = i;
                        break;
                    }
                    else
                    {
                        textTimer = 0;
                        tempi = i + 1;
                        break;
                    }
                }
            }
        }
        public virtual void Draw()
        {
            Globals.spriteBatch.Draw(blackBackground, Vector2.Zero, Color.White * 0.3f);

            // Globals.spriteBatch.Draw(Textbox, position, null, Color.White, 0, 
            //                        new Vector2(Textbox.Width/2,Textbox.Height/2), new Vector2(0.5f, 1), SpriteEffects.None, 0f);
            Globals.spriteBatch.DrawString(Globals.gameFont, text, new Vector2(position.X, position.Y), Color.Black);
            text = "";
            foreach(Actor actor in actors)
            {
                actor.Draw();
                actor.portraitHidden = true;
            }
        }
    }
}
