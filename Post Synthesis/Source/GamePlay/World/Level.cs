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
#endregion

namespace Post_Synthesis
{
    public struct Level
    {
        public Player player;
        //public NPC[] npcs;
        public Enemy[] enemies;
        public Floor floor;
        public Background background;

        public Level(Player player, Enemy[] enemies, Floor floor, Background background)
        {
            this.player = player;
            this.enemies = enemies;
            this.floor = floor;
            this.background = background;
        }

    }
}
