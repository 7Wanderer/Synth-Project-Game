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
using System.Windows.Forms;
#endregion

namespace Post_Synthesis
{
    public class Projectile2D : Basic2D
    {
        public float speed = 12.5f;
        public Vector2 direction;
        public bool done = false;
        public BaseTimer timer = new(1200);
        
        public Projectile2D(string PATH, Vector2 Position, Vector2 Dimensions, Vector2 Target)
            : base(PATH, Position, Dimensions)
        {
            direction = Target;
            direction.Normalize();
        }

        public virtual void Update(Vector2 OFFSET, List<Unit> units)
        {
            Position += direction * speed;
            timer.UpdateTimer();
            if(timer.Test())
            {
                done = true;
            }
            if(Hit(units))
            {
                done = true;
            }
        }
        public virtual bool Hit(List<Unit> units)
        {
            return false;
        }

        public override void Draw(Vector2 OFFSET) 
        {
            base.Draw(OFFSET);
        }
    }    
}
