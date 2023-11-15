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
        public bool inactive = true;
        public Vector2 offset;


        Vector2 position = new(Globals.screenWidth / 2, Globals.screenHeight * 0.75f);

        Texture2D blackBackground;
        float fadein = 0.3f;

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
					if(actor.name ==  actorName)
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

        public void fadeIn(float fadein, float speed)
        {
            if (this.fadein > fadein) this.fadein = fadein;
            if (this.fadein == fadein) return;
            this.fadein += speed;
        }

        public void playAnim(ref Unit unit)
        {

        }

        public void moveUnit(ref Unit unit,Vector2 endPos, float speed)
        {
            if (endPos.X != unit.Position.X)
            {
                if (Math.Abs(unit.Position.X - endPos.X) < speed) speed = 1;
                if (unit.Position.X < endPos.X) unit.Position.X += speed;
                else unit.Position.X -= speed;
            }
            else
            {
                if (endPos.Y == offset.Y) return;
                else
                {
                    if (Math.Abs(offset.Y - endPos.Y) < speed) speed = 1;
                    if (offset.Y < endPos.Y) offset.Y += speed;
                    else offset.Y -= speed;
                }
            }
        }

        public void moveCamera(Vector2 endPos, float speed)
        {
            endPos = -endPos;
            if (endPos.X != offset.X)
            {
                if (Math.Abs(offset.X - endPos.X) < speed) speed = 1;
                if (offset.X < endPos.X) offset.X += speed;
                else offset.X -= speed;
            }
            else
            {
                if (endPos.Y == offset.Y) return;
                else
                {
                    if (Math.Abs(offset.Y - endPos.Y) < speed) speed = 1;
                    if (offset.Y < endPos.Y) offset.Y += speed;
                    else offset.Y -= speed;
                }
            }
        }
        public void resetCamera()
        {
            offset = Vector2.Zero;
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
            if (!inactive)
            {
                Globals.spriteBatch.Draw(blackBackground, Vector2.Zero, Color.White * fadein);

                // Globals.spriteBatch.Draw(Textbox, position, null, Color.White, 0, 
                //                        new Vector2(Textbox.Width/2,Textbox.Height/2), new Vector2(0.5f, 1), SpriteEffects.None, 0f);
                Globals.spriteBatch.DrawString(Globals.gameFont, text, new Vector2(position.X, position.Y), Color.Black);
                text = "";
                foreach (Actor actor in actors)
                {
                    actor.Draw();
                    actor.portraitHidden = true;
                }
            }
        }
    }
}
